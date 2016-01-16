using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util
{
    public static class HexHelper
    {
        public static string ToHexDump(string description, byte[] dump)
        {
            return ToHexDump(description, dump, 0, dump.Length);
        }
        public static string ToHexDump(string description, byte[] dump, int start, int count)
        {
            StringBuilder hexDump = new StringBuilder();
            if (description != null)
            {
                hexDump.Append(description).Append("\n");
            }
            int end = start + count;
            for (int i = start; i < end; i += 16)
            {
                StringBuilder text = new StringBuilder();
                StringBuilder hex = new StringBuilder();
                hex.Append(i.ToString("X4"));
                hex.Append(": ");
                for (int j = 0; j < 16; j++)
                {
                    if (j + i < end)
                    {
                        byte val = dump[j + i];
                        hex.Append(dump[j + i].ToString("X2"));
                        hex.Append(" ");
                        if (val >= 32 && val <= 127)
                        {
                            text.Append((char)val);
                        }
                        else
                        {
                            text.Append(".");
                        }
                    }
                    else
                    {
                        hex.Append("   ");
                        text.Append(" ");
                    }
                }
                hex.Append("  ");
                hex.Append(text.ToString());
                hex.Append('\n');
                hexDump.Append(hex.ToString());
            }
            return hexDump.ToString();
        }
    }
}
