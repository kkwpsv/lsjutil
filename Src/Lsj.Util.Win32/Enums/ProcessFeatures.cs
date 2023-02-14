using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Process Features
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-isprocessorfeaturepresent"/>
    /// </para>
    /// </summary>
    public enum ProcessFeatures : uint
    {
        /// <summary>
        /// The 64-bit load/store atomic instructions are available. 
        /// </summary>
        PF_ARM_64BIT_LOADSTORE_ATOMIC = 25,

        /// <summary>
        /// The divide instructions are available. 
        /// </summary>
        PF_ARM_DIVIDE_INSTRUCTION_AVAILABLE = 24,

        /// <summary>
        /// The external cache is available. 
        /// </summary>
        PF_ARM_EXTERNAL_CACHE_AVAILABLE = 26,

        /// <summary>
        /// The floating-point multiply-accumulate instruction is available. 
        /// </summary>
        PF_ARM_FMAC_INSTRUCTIONS_AVAILABLE = 27,

        /// <summary>
        /// The VFP/Neon: 32 x 64bit register bank is present.
        /// This flag has the same meaning as PF_ARM_VFP_EXTENDED_REGISTERS. 
        /// </summary>
        PF_ARM_VFP_32_REGISTERS_AVAILABLE = 18,

        /// <summary>
        /// The 3D-Now instruction set is available. 
        /// </summary>
        PF_3DNOW_INSTRUCTIONS_AVAILABLE = 7,

        /// <summary>
        /// The processor channels are enabled. 
        /// </summary>
        PF_CHANNELS_ENABLED = 16,

        /// <summary>
        /// The atomic compare and exchange operation (cmpxchg) is available. 
        /// </summary>
        PF_COMPARE_EXCHANGE_DOUBLE = 2,

        /// <summary>
        /// The atomic compare and exchange 128-bit operation (cmpxchg16b) is available.
        /// Windows Server 2003 and Windows XP/2000: This feature is not supported.
        /// </summary>
        PF_COMPARE_EXCHANGE128 = 14,

        /// <summary>
        /// The atomic compare 64 and exchange 128-bit operation (cmp8xchg16) is available.
        /// Windows Server 2003 and Windows XP/2000: This feature is not supported.
        /// </summary>
        PF_COMPARE64_EXCHANGE128 = 15,

        /// <summary>
        /// _fastfail() is available. 
        /// </summary>
        PF_FASTFAIL_AVAILABLE = 23,

        /// <summary>
        /// Floating-point operations are emulated using a software emulator.
        /// This function returns a nonzero value if floating-point operations are emulated; otherwise, it returns zero.
        /// </summary>
        PF_FLOATING_POINT_EMULATED = 1,

        /// <summary>
        /// On a Pentium, a floating-point precision error can occur in rare circumstances. 
        /// </summary>
        PF_FLOATING_POINT_PRECISION_ERRATA = 0,

        /// <summary>
        /// The MMX instruction set is available. 
        /// </summary>
        PF_MMX_INSTRUCTIONS_AVAILABLE = 3,

        /// <summary>
        /// Data execution prevention is enabled.
        /// Windows XP/2000: This feature is not supported until Windows XP with SP2 and Windows Server 2003 with SP1.
        /// </summary>
        PF_NX_ENABLED = 12,

        /// <summary>
        /// The processor is PAE-enabled.
        /// For more information, see Physical Address Extension.
        /// All x64 processors always return a nonzero value for this feature.
        /// </summary>
        PF_PAE_ENABLED = 9,

        /// <summary>
        /// The RDTSC instruction is available. 
        /// </summary>
        PF_RDTSC_INSTRUCTION_AVAILABLE = 8,

        /// <summary>
        /// RDFSBASE, RDGSBASE, WRFSBASE, and WRGSBASE instructions are available. 
        /// </summary>
        PF_RDWRFSGSBASE_AVAILABLE = 22,

        /// <summary>
        /// Second Level Address Translation is supported by the hardware. 
        /// </summary>
        PF_SECOND_LEVEL_ADDRESS_TRANSLATION = 20,

        /// <summary>
        /// The SSE3 instruction set is available.
        /// Windows Server 2003 and Windows XP/2000: This feature is not supported.
        /// </summary>
        PF_SSE3_INSTRUCTIONS_AVAILABLE = 13,

        /// <summary>
        /// Virtualization is enabled in the firmware. 
        /// </summary>
        PF_VIRT_FIRMWARE_ENABLED = 21,

        /// <summary>
        /// The SSE instruction set is available. 
        /// </summary>
        PF_XMMI_INSTRUCTIONS_AVAILABLE = 6,

        /// <summary>
        /// The SSE2 instruction set is available.
        /// Windows 2000: This feature is not supported.
        /// </summary>
        PF_XMMI64_INSTRUCTIONS_AVAILABLE = 10,

        /// <summary>
        /// The processor implements the XSAVE and XRSTOR instructions.
        /// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP/2000:
        /// This feature is not supported until Windows 7 and Windows Server 2008 R2.
        /// </summary>
        PF_XSAVE_ENABLED = 17,

        /// <summary>
        /// This ARM processor implements the the ARM v8 instructions set. 
        /// </summary>
        PF_ARM_V8_INSTRUCTIONS_AVAILABLE = 29,

        /// <summary>
        /// This ARM processor implements the ARM v8 extra cryptographic instructions (i.e. AES, SHA1 and SHA2). 
        /// </summary>
        PF_ARM_V8_CRYPTO_INSTRUCTIONS_AVAILABLE = 30,

        /// <summary>
        /// This ARM processor implements the ARM v8 extra CRC32 instructions. 
        /// </summary>
        PF_ARM_V8_CRC32_INSTRUCTIONS_AVAILABLE = 31,

        /// <summary>
        /// This ARM processor implements the ARM v8.1 atomic instructions (e.g. CAS, SWP). 
        /// </summary>
        PF_ARM_V81_ATOMIC_INSTRUCTIONS_AVAILABLE = 34,
    }
}
