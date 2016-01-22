using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util
{
    /// <summary>
    /// ASCIIChar
    /// </summary>
    public static class ASCIIChar
    {
        /// <summary>
        /// LF
        /// </summary>
        public const byte LF = 10;
        /// <summary>
        /// CR
        /// </summary>
        public const byte CR = 13;
        /// <summary>
        /// SPACE
        /// </summary>
        public const byte SPACE = 32;
        /// <summary>
        /// .
        /// </summary>
        public const byte Point = 46;
        /// <summary>
        /// /
        /// </summary>
        public const byte BackSlash = 47;
        /// <summary>
        /// 0
        /// </summary>
        public const byte N0 = 48;
        /// <summary>
        /// 1
        /// </summary>
        public const byte N1 = 49;
        /// <summary>
        /// 2
        /// </summary>
        public const byte N2 = 50;
        /// <summary>
        /// 3
        /// </summary>
        public const byte N3 = 51;
        /// <summary>
        /// 4
        /// </summary>
        public const byte N4 = 52;
        /// <summary>
        /// 5
        /// </summary>
        public const byte N5 = 53;
        /// <summary>
        /// 6
        /// </summary>
        public const byte N6 = 54;
        /// <summary>
        /// 7
        /// </summary>
        public const byte N7 = 55;
        /// <summary>
        /// 8
        /// </summary>
        public const byte N8 = 56;
        /// <summary>
        /// 9
        /// </summary>
        public const byte N9 = 57;
        /// <summary>
        /// :
        /// </summary>
        public const byte Colon = 58;
        /// <summary>
        /// A
        /// </summary>
        public const byte A = 65;
        /// <summary>
        /// B
        /// </summary>
        public const byte B = 66;
        /// <summary>
        /// C
        /// </summary>
        public const byte C = 67;
        /// <summary>
        /// D
        /// </summary>
        public const byte D = 68;
        /// <summary>
        /// E
        /// </summary>
        public const byte E = 69;
        /// <summary>
        /// F
        /// </summary>
        public const byte F = 70;
        /// <summary>
        /// G
        /// </summary>
        public const byte G = 71;
        /// <summary>
        /// H
        /// </summary>
        public const byte H = 72;
        /// <summary>
        /// I
        /// </summary>
        public const byte I = 73;
        /// <summary>
        /// J
        /// </summary>
        public const byte J = 74;
        /// <summary>
        /// K
        /// </summary>
        public const byte K = 75;
        /// <summary>
        /// L
        /// </summary>
        public const byte L = 76;
        /// <summary>
        /// M
        /// </summary>
        public const byte M = 77;
        /// <summary>
        /// N
        /// </summary>
        public const byte N = 78;
        /// <summary>
        /// O
        /// </summary>
        public const byte O = 79;
        /// <summary>
        /// P
        /// </summary>
        public const byte P = 80;
        /// <summary>
        /// Q
        /// </summary>
        public const byte Q = 81;
        /// <summary>
        /// R
        /// </summary>
        public const byte R = 82;
        /// <summary>
        /// S
        /// </summary>
        public const byte S = 83;
        /// <summary>
        /// T
        /// </summary>
        public const byte T = 84;
        /// <summary>
        /// U
        /// </summary>
        public const byte U = 85;
        /// <summary>
        /// V
        /// </summary>
        public const byte V = 86;
        /// <summary>
        /// W
        /// </summary>
        public const byte W = 87;
        /// <summary>
        /// X
        /// </summary>
        public const byte X = 88;
        /// <summary>
        /// Y
        /// </summary>
        public const byte Y = 89;
        /// <summary>
        /// Z
        /// </summary>
        public const byte Z = 90;
        /// <summary>
        /// \
        /// </summary>
        public const byte Slash = 90;
        /// <summary>
        /// a
        /// </summary>
        public const byte a = 97;
        /// <summary>
        /// b
        /// </summary>
        public const byte b = 98;
        /// <summary>
        /// c
        /// </summary>
        public const byte c = 99;
        /// <summary>
        /// d
        /// </summary>
        public const byte d = 100;
        /// <summary>
        /// e
        /// </summary>
        public const byte e = 101;
        /// <summary>
        /// f
        /// </summary>
        public const byte f = 102;
        /// <summary>
        /// g
        /// </summary>
        public const byte g = 103;
        /// <summary>
        /// h
        /// </summary>
        public const byte h = 104;
        /// <summary>
        /// i
        /// </summary>
        public const byte i = 105;
        /// <summary>
        /// j
        /// </summary>
        public const byte j = 106;
        /// <summary>
        /// k
        /// </summary>
        public const byte k = 107;
        /// <summary>
        /// l
        /// </summary>
        public const byte l = 108;
        /// <summary>
        /// m
        /// </summary>
        public const byte m = 109;
        /// <summary>
        /// n
        /// </summary>
        public const byte n = 110;
        /// <summary>
        /// o
        /// </summary>
        public const byte o = 111;
        /// <summary>
        /// p
        /// </summary>
        public const byte p = 112;
        /// <summary>
        /// q
        /// </summary>
        public const byte q = 113;
        /// <summary>
        /// r
        /// </summary>
        public const byte r = 114;
        /// <summary>
        /// s
        /// </summary>
        public const byte s = 115;
        /// <summary>
        /// t
        /// </summary>
        public const byte t = 116;
        /// <summary>
        /// u
        /// </summary>
        public const byte u = 117;
        /// <summary>
        /// v
        /// </summary>
        public const byte v = 118;
        /// <summary>
        /// w
        /// </summary>
        public const byte w = 119;
        /// <summary>
        /// x
        /// </summary>
        public const byte x = 120;
        /// <summary>
        /// y
        /// </summary>
        public const byte y = 121;
        /// <summary>
        /// z
        /// </summary>
        public const byte z = 122;





        /// <summary>
        /// IsNumber
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool IsNumber(byte i)
        {
            return i >= 48 && i <= 57;
        }
    }

}
