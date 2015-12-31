using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lsj.Util.Debugger
{
    static class Program
    {
        /*      public unsafe static void Main()
              {
                  byte[] src = new byte[1000000000];
                  byte[] dst = new byte[1000000000];
                  int start = Environment.TickCount;
                  Buffer.BlockCopy(src, 0, dst, 0, 1000000000);
                  Console.WriteLine(Environment.TickCount - start);

                  int start2 = Environment.TickCount;
                  fixed(byte* psrc=src , pdst=dst)
                  {
                      UnsafeHelper.Copy(psrc, pdst,1000000000);
                  }
                  Console.WriteLine(Environment.TickCount - start2);

                  int start3 = Environment.TickCount;
                  fixed (byte* psrc = src, pdst = dst)
                  {
                      Copy(psrc, pdst, 1000000000);
                  }
                  Console.WriteLine(Environment.TickCount - start3);

                  /*    foreach (var a in src)
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
              }*/
        public static void Main()
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
        }
    }
}
