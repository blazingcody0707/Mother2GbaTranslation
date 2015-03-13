﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptTool
{
    public static class Extensions
    {
        public static int ReadInt(this byte[] rom, int address)
        {
            int value = rom[address] |
                (rom[address + 1] << 8) |
                (rom[address + 2] << 16) |
                (rom[address + 3] << 24);
            return value;
        }

        public static int ReadSnesPointer(this byte[] rom, int address)
        {
            int offset = rom.ReadInt(address);
            if (offset == 0) return 0;
            return offset - 0xC00000;
        }

        public static int ReadGbaPointer(this byte[] rom, int address)
        {
            int offset = rom.ReadInt(address);
            if (offset == 0) return 0;
            return offset & 0x1FFFFFF;
        }
    }
}
