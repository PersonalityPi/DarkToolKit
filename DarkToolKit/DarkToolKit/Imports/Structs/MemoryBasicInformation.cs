using System;
using System.Runtime.InteropServices;
using Ernegien.HaloOnline.Utilities.Imports.Types;

namespace Ernegien.HaloOnline.Utilities.Imports.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MemoryBasicInformation
    {
        public UIntPtr BaseAddress;
        public UIntPtr AllocationBase;
        public MemoryProtect AllocationProtect;
        public IntPtr RegionSize;
        public uint State;  // TODO: declare type
        public MemoryProtect Protect;
        public uint Type;  // TODO: declare type
    }
}
