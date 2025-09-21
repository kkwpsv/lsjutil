using Lsj.Util.IL;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Threading;
using static Lsj.Util.Win32.BaseTypes.MMRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.WaveFormats;
using static Lsj.Util.Win32.Enums.WinmmCallbackTypes;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.Winmm;

namespace Lsj.Util.Win32.Extensions.Winmm
{
    /// <summary>
    /// Wave out player
    /// </summary>
    public class WaveOutPlayer : IDisposable
    {
        private bool _disposedValue;
        private HWAVEOUT _waveOut;
        private ConcurrentQueue<AudioBuffer> _audioBuffers = new ConcurrentQueue<AudioBuffer>();
        private Thread _thread;
        private readonly int _channels;
        private readonly int _samplesPerSecond;
        private readonly int _bitsPerSample;
        private readonly int _bytesPerSecond;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channels"></param>
        /// <param name="samplesPerSecond"></param>
        /// <param name="bitsPerSample"></param>
        public WaveOutPlayer(int channels, int samplesPerSecond, int bitsPerSample)
        {
            _channels = channels;
            _samplesPerSecond = samplesPerSecond;
            _bitsPerSample = bitsPerSample;
            _bytesPerSecond = channels * samplesPerSecond * bitsPerSample / 8;

            var format = new WAVEFORMATEX
            {
                cbSize = 0,
                wFormatTag = WAVE_FORMAT_PCM,
                nChannels = (ushort)_channels,
                nSamplesPerSec = (uint)_samplesPerSecond,
                wBitsPerSample = (ushort)_bitsPerSample,
                nBlockAlign = (ushort)(_channels * _bitsPerSample / 8),
                nAvgBytesPerSec = (uint)(_bytesPerSecond),
            };
            var result = waveOutOpen(out _waveOut, WAVE_MAPPER, format, NULL, NULL, (uint)CALLBACK_NULL);
            if (result != MMSYSERR_NOERROR)
            {
                throw new Exception("waveOutOpen failed with error code: " + result);
            }

            waveOutPause(_waveOut);
            _thread = new Thread(PlayThread);
            _thread.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        ~WaveOutPlayer()
        {
            Dispose(disposing: false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                Reset();

                waveOutReset(_waveOut);
                waveOutClose(_waveOut);
                _disposedValue = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="length"></param>
        /// <param name="timeNs"></param>
        public void EnqueueAudio(IntPtr data, int length, long timeNs)
        {
            var dataCopied = Marshal.AllocHGlobal(length);
            unsafe
            {
                Unsafe.CopyBlock((void*)dataCopied, (void*)data, (uint)length);
            }
            _audioBuffers.Enqueue(new AudioBuffer
            {
                Data = dataCopied,
                Length = length,
                timeNs = timeNs,
            });
        }

        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            waveOutRestart(_waveOut);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeNs"></param>
        public void SyncCurrentTime(long timeNs)
        {
            _currentPlayTimeNs = timeNs;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            _sentBytes = 0;
            _currentPlayTimeNs = null;
            while (_audioBuffers.TryDequeue(out var buffer))
            {
                Marshal.FreeHGlobal(buffer.Data);
            }
        }

        private long _sentBytes = 0;
        private long? _currentPlayTimeNs = null;


        private unsafe void PlayThread()
        {
            DWORD index = 0;
            var handle = Avrt.AvSetMmThreadCharacteristics("Pro Audio", ref index);

            var headerCount = 3;

            var headers = new WAVEHDR[headerCount];

            while (true)
            {
                if (_disposedValue)
                {
                    break;
                }
                if (_audioBuffers.TryDequeue(out var buffer))
                {
                    if (_currentPlayTimeNs != null)
                    {
                        var audioMs = GetMillisecondsFromDataLength(_sentBytes);
                        var elapsedMs = _currentPlayTimeNs / 1000000;
                        if (elapsedMs - audioMs > 200)
                        {
                            _sentBytes += buffer.Length;
                            Marshal.FreeHGlobal(buffer.Data);
                            buffer.Data = NULL;
                            continue;
                        }
                    }

                    ref WAVEHDR header = ref NullRef<WAVEHDR>();
                    while (true)
                    {
                        if (_disposedValue)
                        {
                            break;
                        }
                        bool foundHeader = false;
                        for (var i = 0; i < headerCount; i++)
                        {
                            header = ref headers[i];
                            if (header.dwFlags.HasFlag(WaveHeaderFlags.WHDR_DONE))
                            {
                                waveOutUnprepareHeader(_waveOut, header, SizeOf<WAVEHDR>());
                                Marshal.FreeHGlobal(header.lpData);
                                header.lpData = NULL;
                                foundHeader = true;
                                break;
                            }
                            else if (header.dwBufferLength == 0)
                            {
                                foundHeader = true;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        if (foundHeader)
                        {
                            break;
                        }
                        Thread.Sleep(10);
                    }

                    if (_disposedValue)
                    {
                        Marshal.FreeHGlobal(buffer.Data);
                        buffer.Data = NULL;
                        break;
                    }
                    header.lpData = buffer.Data;
                    header.dwBufferLength = buffer.Length;
                    _sentBytes += buffer.Length;
                    waveOutPrepareHeader(_waveOut, header, SizeOf<WAVEHDR>());
                    waveOutWrite(_waveOut, header, SizeOf<WAVEHDR>());
                }
            }

            for (int i = 0; i < headerCount; i++)
            {
                if (headers[i].lpData != NULL)
                {
                    Marshal.FreeHGlobal(headers[i].lpData);
                }
            }
            Avrt.AvRevertMmThreadCharacteristics(handle);
        }

        private long GetMillisecondsFromDataLength(long bytes)
        {
            return bytes * 1000 / _bytesPerSecond;
        }

        public struct AudioBuffer
        {
            public IntPtr Data { get; set; }

            public int Length { get; set; }

            public long timeNs { get; set; }
        }
    }
}
