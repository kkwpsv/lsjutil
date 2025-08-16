using Lsj.Util.IL;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.Extensions.Gdi
{
    /// <summary>
    /// Image helper
    /// </summary>
    public static class ImageHelper
    {
        /// <summary>
        /// Get RGB data form HBitmap (B8G8R8X8 format)
        /// </summary>
        /// <param name="hBitmap"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="stride"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static unsafe byte[] GetRGBDataFromHBitmap(HBITMAP hBitmap, out int width, out int height, out int stride)
        {
            BITMAP bitmap;
            var count = SizeOf<BITMAP>();
            if (Gdi32.GetObject(hBitmap, count, &bitmap) == count)
            {
                var dc = User32.GetDC(NULL);
                width = bitmap.bmWidth;
                height = bitmap.bmHeight;
                stride = width * 4;
                var data = new byte[stride * height];
                fixed (byte* dataPtr = data)
                {
                    var bitmapInfo = new BITMAPINFO();
                    bitmapInfo.bmiHeader.biSize = SizeOf<BITMAPINFOHEADER>();
                    bitmapInfo.bmiHeader.biWidth = width;
                    bitmapInfo.bmiHeader.biHeight = -height;
                    bitmapInfo.bmiHeader.biPlanes = 1;
                    bitmapInfo.bmiHeader.biBitCount = 32;
                    bitmapInfo.bmiHeader.biCompression = BitmapCompressions.BI_RGB;
                    if (Gdi32.GetDIBits(dc, hBitmap, 0, (uint)height, dataPtr, bitmapInfo, (uint)DIBColorTableUsages.DIB_RGB_COLORS) == height)
                    {
                        Gdi32.DeleteDC(dc);
                        return data;
                    }
                    else
                    {
                        Gdi32.DeleteDC(dc);
                        throw new Exception("GetDIBits failed.");
                    }
                }
            }
            else
            {
                throw new Exception("GetObject failed.");
            }
        }

        /// <summary>
        /// Convert RGB data to bmp file (RGB data should be B8G8R8X8 format now)
        /// </summary>
        /// <param name="rgbData"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="srcStride"></param>
        /// <returns></returns>
        public unsafe static byte[] RGBDataToBmp(byte[] rgbData, int width, int height, int? srcStride = null)
        {
            fixed (byte* rgbDataPtr = rgbData)
            {
                return RGBDataToBmp((IntPtr)rgbDataPtr, width, height, srcStride);
            }
        }

        /// <summary>
        /// Convert RGB data to bmp file (RGB data should be B8G8R8X8 format now)
        /// </summary>
        /// <param name="rgbDataPtr"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="srcStride"></param>
        /// <returns></returns>
        public unsafe static byte[] RGBDataToBmp(IntPtr rgbDataPtr, int width, int height, int? srcStride = null)
        {
            if (srcStride <= 0)
            {
                throw new ArgumentException(nameof(srcStride));
            }
            if (width <= 0)
            {
                throw new ArgumentException(nameof(width));
            }
            if (height <= 0)
            {
                throw new ArgumentException(nameof(height));
            }
            srcStride ??= width * 4;
            var stride = width * 4;
            var dataSize = stride * height;

            var bmpFileHeader = new BITMAPFILEHEADER
            {
                bfType = 0x4d42,
                bfSize = SizeOf<BITMAPFILEHEADER>() + SizeOf<BITMAPINFOHEADER>() + dataSize,
                bfOffBits = SizeOf<BITMAPFILEHEADER>() + SizeOf<BITMAPINFOHEADER>(),
            };

            var bitmapInfoHeader = new BITMAPINFOHEADER
            {
                biSize = SizeOf<BITMAPINFOHEADER>(),
                biWidth = (int)width,
                biHeight = -(int)height,
                biPlanes = 1,
                biBitCount = 32,
                biCompression = BitmapCompressions.BI_RGB,
                biSizeImage = 0,
                biXPelsPerMeter = 0,
                biYPelsPerMeter = 0,
                biClrUsed = 0,
                biClrImportant = 0,
            };

            byte[] bmpData = new byte[bmpFileHeader.bfSize];
            fixed (byte* bmpDataPtr = bmpData)
            {
                Unsafe.CopyBlockUnaligned(bmpDataPtr, (byte*)&bmpFileHeader, (uint)SizeOf<BITMAPFILEHEADER>());
                Unsafe.CopyBlockUnaligned(bmpDataPtr + SizeOf<BITMAPFILEHEADER>(), (byte*)&bitmapInfoHeader, (uint)SizeOf<BITMAPINFOHEADER>());

                var src = (byte*)rgbDataPtr;
                var dst = bmpDataPtr + bmpFileHeader.bfOffBits;
                if (stride == srcStride.Value)
                {
                    Unsafe.CopyBlockUnaligned(dst, src, (uint)dataSize);
                }
                else
                {
                    for (int i = 0; i < height; i++)
                    {
                        Unsafe.CopyBlockUnaligned(dst, src, (uint)stride);
                        src += srcStride.Value;
                        dst += stride;
                    }
                }
            }
            return bmpData;
        }
    }
}
