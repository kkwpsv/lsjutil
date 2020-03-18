using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace Lsj.Util.AspNetCore.Utils
{
    public static class CheckCodeHelper
    {
        private static string GetRandomString(int length = 4)
        {
            var result = "";
            var chars = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N,P,P,Q,R,S,T,U,V,W,X,Y,Z".Split(',');
            var random = new Random();
            for (int i = 0; i < length; i++)
            {
                result += chars[random.Next(0, chars.Length)];
            }
            return result;
        }

        /// <summary>
        /// Get CheckCode Image with jpeg format
        /// </summary>
        /// <param name="code">code</param>
        /// <returns></returns>
        public static byte[] GetCheckCodeImage(out string code) => GetCheckCodeImage(ImageFormat.Jpeg, out code);

        public static byte[] GetCheckCodeImage(ImageFormat format, out string code)
        {
            code = GetRandomString();

            Random random = new Random();
            Color[] colors = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
            string[] fonts = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };


            using var bitmap = new Bitmap(code.Length * 18, 32);
            using var graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);

            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(bitmap.Width);
                int y = random.Next(bitmap.Height);
                graphics.DrawRectangle(new Pen(Color.LightGray, 0), x, y, 1, 1);
            }

            for (int i = 0; i < code.Length; i++)
            {
                int cindex = random.Next(colors.Length);
                int findex = random.Next(fonts.Length);
                Font f = new Font(fonts[findex], 15, FontStyle.Bold);
                Brush b = new SolidBrush(colors[cindex]);
                int ii = 4;
                if ((i + 1) % 2 == 0)
                {
                    ii = 2;
                }
                graphics.DrawString(code.Substring(i, 1), f, b, 3 + (i * 12), ii);
            }
            using var ms = new MemoryStream();
            bitmap.Save(ms, format);
            return ms.ToArray();
        }
    }
}
