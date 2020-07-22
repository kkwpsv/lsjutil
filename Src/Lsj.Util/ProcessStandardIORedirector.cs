using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Lsj.Util
{
    /// <summary>
    /// Process Standard IO Redirector
    /// </summary>
    public class ProcessStandardIORedirector
    {
        private Process _process;
        private StreamWriter _input;
        private StreamReader _output;
        private ProcessStartInfo _startInfo;

        /// <summary>
        /// Start Process
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="arguments"></param>
        /// <param name="workingDirectory"></param>
        public bool StartProcess(string filename, string arguments = null, string workingDirectory = null)
        {
            if (_process != null && !_process.HasExited)
            {
                throw new InvalidOperationException($"Process has started. Process ID: {_process.Id}");
            }
            _startInfo = new ProcessStartInfo
            {
                CreateNoWindow = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                FileName = filename,
                Arguments = arguments,
                UseShellExecute = false,
                WorkingDirectory = workingDirectory,
            };
            DoStartProcess();
            return IsRunning;
        }

        /// <summary>
        /// Restart Process
        /// </summary>
        /// <returns></returns>

        public bool RestartProcess()
        {
            if (_process != null && !_process.HasExited)
            {
                throw new InvalidOperationException($"Process has started. Process ID: {_process.Id}");
            }
            DoStartProcess();
            return IsRunning;
        }

        private void DoStartProcess()
        {
            _process = Process.Start(_startInfo);
            _input = _process.StandardInput;
            _output = _process.StandardOutput;
        }

        /// <summary>
        /// IsRunning
        /// </summary>
        public bool IsRunning => _process != null & !_process.HasExited;

        /// <summary>
        /// Kill Process
        /// </summary>
        public void KillProcess()
        {
            if (_process == null)
            {
                throw new InvalidOperationException($"Process has not started");
            }
            if (_process.HasExited)
            {
                throw new InvalidOperationException($"Process has exited.");
            }
            _process.Kill();
        }

        /// <summary>
        /// Write Line To Standard Input
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public async Task WriteLine(string line)
        {
            if (_process == null)
            {
                throw new InvalidOperationException($"Process has not started");
            }
            if (!_process.HasExited)
            {
                await _input.WriteLineAsync(line);
            }
            else
            {
                throw new InvalidOperationException($"Process has exited. Exit code: {_process.ExitCode}");
            }
        }

        /// <summary>
        /// Write Line To Standard Input
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public async Task WriteLine(object o) => await WriteLine(o.ToString());

        /// <summary>
        /// Read Line To Standard Ouput
        /// </summary>
        /// <returns></returns>
        public async Task<string> Readline()
        {
            if (_process == null)
            {
                throw new InvalidOperationException($"Process has not started");
            }
            if (!_process.HasExited)
            {
                return await _output.ReadLineAsync();
            }
            else
            {
                throw new InvalidOperationException($"Process has exited. Exit code: {_process.ExitCode}");
            }
        }
    }
}
