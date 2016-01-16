using Lsj.Util.Net;
using Lsj.Util.Net.Web.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lsj.Util.Debugger
{
    class Program
    {
        public Version HttpVersion
        {
            get;
            private set;
        }
        public eHttpMethod Method
        {
            get;
            private set;
        }
        public URI Uri
        {
            get;
            private set;
        }

        /*        public unsafe static void Main()
       {
           byte[] src = new byte[] { 1,2,3,4,5,6,7,8,9,0};
           byte[] dst = new byte[10];
          // int start = Environment.TickCount;
          // Buffer.BlockCopy(src, 0, dst, 0, 1000000000);
          // Console.WriteLine(Environment.TickCount - start);
          //
          // int start2 = Environment.TickCount;
          // fixed(byte* psrc=src , pdst=dst)
          // {
          //     UnsafeHelper.Copy(psrc, pdst,1000000000);
          // }
          // Console.WriteLine(Environment.TickCount - start2);

         //  int start3 = Environment.TickCount;
          // fixed (byte* psrc = src, pdst = dst)
         //  {
               UnsafeHelper.Copy(src, dst, 9);
         //  }
        //   Console.WriteLine(Environment.TickCount - start3);

             foreach (var a in src)
                   Console.Write(a);
               Console.WriteLine();
               foreach (var a in dst)
                   Console.Write(a);
           Console.ReadLine();
       }
       public unsafe static void Copy(byte* src, byte* dst, int length)
       {
           while (length >= 1)
           {
               copybyte(src, dst);
               length--;
           }
       }
       unsafe static void copybyte(void* src, void* dst)
       {
           *((byte*)dst) = *((byte*)src);
       }
/*    public static void Main()
 {
     var a = new A();
     a.x = 100;
     X(a);
     Console.Write(a.x);
     Console.Read();
 }
 static void X(A a)
 {
     a.x = 200;
 }
 class A
 {
     public int x;
 }*/
        public unsafe static void Main()
        {
            Program a = new Program();
            string temp = "GET / HTTP/1.1";
            var bytes = temp.ConvertToBytes();
            fixed(byte* ptr = bytes)
            {
                a.ParseFirstLine(ptr,temp.Length);
            }
            Console.ReadKey();

        }


        private unsafe bool ParseFirstLine(byte* ptr, int length)
        {
            var left = length;
            #region ParseMethod
            if (left >= 7)
            {
                if (*ptr == ASCIIChar.G && *(++ptr) == ASCIIChar.E && *(++ptr) == ASCIIChar.T)
                {
                    this.Method = eHttpMethod.GET;
                    left -= 3;
                }
                else if (*ptr == ASCIIChar.H && *(++ptr) == ASCIIChar.E && *(++ptr) == ASCIIChar.A && *(++ptr) == ASCIIChar.D)
                {
                    this.Method = eHttpMethod.HEAD;
                    left -= 4;
                }
                else if (*ptr == ASCIIChar.P)
                {
                    if (*(++ptr) == ASCIIChar.O && *(++ptr) == ASCIIChar.S && *(++ptr) == ASCIIChar.T)
                    {
                        this.Method = eHttpMethod.POST;
                        left -= 4;
                    }
                    else if (*(++ptr) == ASCIIChar.U && *(++ptr) == ASCIIChar.T)
                    {
                        this.Method = eHttpMethod.PUT;
                        left -= 3;
                    }
                }
                else if (*ptr == ASCIIChar.T && *(++ptr) == ASCIIChar.R && *(++ptr) == ASCIIChar.A && *(++ptr) == ASCIIChar.C && *(++ptr) == ASCIIChar.E)
                {
                    this.Method = eHttpMethod.TRACE;
                    left -= 5;
                }
                else if (*ptr == ASCIIChar.O && *(++ptr) == ASCIIChar.P && *(++ptr) == ASCIIChar.T && *(++ptr) == ASCIIChar.I && *(++ptr) == ASCIIChar.O && *(++ptr) == ASCIIChar.N && *(++ptr) == ASCIIChar.S)
                {

                    this.Method = eHttpMethod.OPTIONS;
                    left -= 7;
                }
                else if (*ptr == ASCIIChar.D && *(++ptr) == ASCIIChar.E && *(++ptr) == ASCIIChar.L && *(++ptr) == ASCIIChar.E && *(++ptr) == ASCIIChar.T && *(++ptr) == ASCIIChar.E)
                {
                    this.Method = eHttpMethod.DELETE;
                    left -= 6;
                }
            }
            #endregion
            if (this.Method != eHttpMethod.UnParsed && left > 1 && *(++ptr) == ASCIIChar.SPACE)
            {
                var uriptr = ++ptr;
                for (int i = 0; left > 0; i++,ptr++)
                {
                    left--;
                    if (*ptr == ASCIIChar.SPACE)
                    {
                        this.Uri = new URI(StringHelper.ReadStringFromBytePoint(uriptr, i));
                        if (left == 9)
                        {
                            #region ParseVersion
                            if (*(++ptr) == ASCIIChar.H && *(++ptr) == ASCIIChar.T && *(++ptr) == ASCIIChar.T && *(++ptr) == ASCIIChar.P && *(++ptr) == ASCIIChar.BackSlash)
                            {
                                var major = *(++ptr);
                                if (ASCIIChar.IsNumber(major))
                                {
                                    major -= 48;
                                    if (*(++ptr) == ASCIIChar.Point)
                                    {
                                        var minor = *(++ptr);
                                        if (ASCIIChar.IsNumber(minor))
                                        {
                                            minor -= 48;
                                            {
                                                this.HttpVersion = new Version(major, minor);
                                                return true;
                                            }
                                        }
                                    }
                                }
                            }
                            #endregion ParseVersion
                        }
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
