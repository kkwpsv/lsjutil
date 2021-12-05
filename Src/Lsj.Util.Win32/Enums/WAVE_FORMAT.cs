namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// WAVE_FORMAT
    /// </summary>
    public enum WAVE_FORMAT : ushort
    {
        /// <summary>
        /// WAVE_FORMAT_PCM
        /// </summary>
        WAVE_FORMAT_PCM = 1,

        /// <summary>
        /// WAVE_FORMAT_UNKNOWN
        /// </summary>
        WAVE_FORMAT_UNKNOWN = 0x0000,

        /// <summary>
        /// WAVE_FORMAT_ADPCM
        /// </summary>
        WAVE_FORMAT_ADPCM = 0x0002,

        /// <summary>
        /// WAVE_FORMAT_IEEE_FLOAT
        /// </summary>
        WAVE_FORMAT_IEEE_FLOAT = 0x0003,

        /// <summary>
        /// WAVE_FORMAT_VSELP
        /// </summary>
        WAVE_FORMAT_VSELP = 0x0004,

        /// <summary>
        /// WAVE_FORMAT_IBM_CVSD
        /// </summary>
        WAVE_FORMAT_IBM_CVSD = 0x0005,

        /// <summary>
        /// WAVE_FORMAT_ALAW
        /// </summary>
        WAVE_FORMAT_ALAW = 0x0006,

        /// <summary>
        /// WAVE_FORMAT_MULAW
        /// </summary>
        WAVE_FORMAT_MULAW = 0x0007,

        /// <summary>
        /// WAVE_FORMAT_DTS
        /// </summary>
        WAVE_FORMAT_DTS = 0x0008,

        /// <summary>
        /// WAVE_FORMAT_DRM
        /// </summary>
        WAVE_FORMAT_DRM = 0x0009,

        /// <summary>
        /// WAVE_FORMAT_WMAVOICE9
        /// </summary>
        WAVE_FORMAT_WMAVOICE9 = 0x000A,

        /// <summary>
        /// WAVE_FORMAT_WMAVOICE10
        /// </summary>
        WAVE_FORMAT_WMAVOICE10 = 0x000B,

        /// <summary>
        /// WAVE_FORMAT_OKI_ADPCM
        /// </summary>
        WAVE_FORMAT_OKI_ADPCM = 0x0010,

        /// <summary>
        /// WAVE_FORMAT_DVI_ADPCM
        /// </summary>
        WAVE_FORMAT_DVI_ADPCM = 0x0011,

        /// <summary>
        /// WAVE_FORMAT_IMA_ADPCM
        /// </summary>
        WAVE_FORMAT_IMA_ADPCM = (WAVE_FORMAT_DVI_ADPCM),

        /// <summary>
        /// WAVE_FORMAT_MEDIASPACE_ADPCM
        /// </summary>
        WAVE_FORMAT_MEDIASPACE_ADPCM = 0x0012,

        /// <summary>
        /// WAVE_FORMAT_SIERRA_ADPCM
        /// </summary>
        WAVE_FORMAT_SIERRA_ADPCM = 0x0013,

        /// <summary>
        /// WAVE_FORMAT_G723_ADPCM
        /// </summary>
        WAVE_FORMAT_G723_ADPCM = 0x0014,

        /// <summary>
        /// WAVE_FORMAT_DIGISTD
        /// </summary>
        WAVE_FORMAT_DIGISTD = 0x0015,

        /// <summary>
        /// WAVE_FORMAT_DIGIFIX
        /// </summary>
        WAVE_FORMAT_DIGIFIX = 0x0016,

        /// <summary>
        /// WAVE_FORMAT_DIALOGIC_OKI_ADPCM
        /// </summary>
        WAVE_FORMAT_DIALOGIC_OKI_ADPCM = 0x0017,

        /// <summary>
        /// WAVE_FORMAT_MEDIAVISION_ADPCM
        /// </summary>
        WAVE_FORMAT_MEDIAVISION_ADPCM = 0x0018,

        /// <summary>
        /// WAVE_FORMAT_CU_CODEC
        /// </summary>
        WAVE_FORMAT_CU_CODEC = 0x0019,

        /// <summary>
        /// WAVE_FORMAT_HP_DYN_VOICE
        /// </summary>
        WAVE_FORMAT_HP_DYN_VOICE = 0x001A,

        /// <summary>
        /// WAVE_FORMAT_YAMAHA_ADPCM
        /// </summary>
        WAVE_FORMAT_YAMAHA_ADPCM = 0x0020,

        /// <summary>
        /// WAVE_FORMAT_SONARC
        /// </summary>
        WAVE_FORMAT_SONARC = 0x0021,

        /// <summary>
        /// WAVE_FORMAT_DSPGROUP_TRUESPEECH
        /// </summary>
        WAVE_FORMAT_DSPGROUP_TRUESPEECH = 0x0022,

        /// <summary>
        /// WAVE_FORMAT_ECHOSC1
        /// </summary>
        WAVE_FORMAT_ECHOSC1 = 0x0023,

        /// <summary>
        /// WAVE_FORMAT_AUDIOFILE_AF36
        /// </summary>
        WAVE_FORMAT_AUDIOFILE_AF36 = 0x0024,

        /// <summary>
        /// WAVE_FORMAT_APTX
        /// </summary>
        WAVE_FORMAT_APTX = 0x0025,

        /// <summary>
        /// WAVE_FORMAT_AUDIOFILE_AF10
        /// </summary>
        WAVE_FORMAT_AUDIOFILE_AF10 = 0x0026,

        /// <summary>
        /// WAVE_FORMAT_PROSODY_1612
        /// </summary>
        WAVE_FORMAT_PROSODY_1612 = 0x0027,

        /// <summary>
        /// WAVE_FORMAT_LRC
        /// </summary>
        WAVE_FORMAT_LRC = 0x0028,

        /// <summary>
        /// WAVE_FORMAT_DOLBY_AC2
        /// </summary>
        WAVE_FORMAT_DOLBY_AC2 = 0x0030,

        /// <summary>
        /// WAVE_FORMAT_GSM610
        /// </summary>
        WAVE_FORMAT_GSM610 = 0x0031,

        /// <summary>
        /// WAVE_FORMAT_MSNAUDIO
        /// </summary>
        WAVE_FORMAT_MSNAUDIO = 0x0032,

        /// <summary>
        /// WAVE_FORMAT_ANTEX_ADPCME
        /// </summary>
        WAVE_FORMAT_ANTEX_ADPCME = 0x0033,

        /// <summary>
        /// WAVE_FORMAT_CONTROL_RES_VQLPC
        /// </summary>
        WAVE_FORMAT_CONTROL_RES_VQLPC = 0x0034,

        /// <summary>
        /// WAVE_FORMAT_DIGIREAL
        /// </summary>
        WAVE_FORMAT_DIGIREAL = 0x0035,

        /// <summary>
        /// WAVE_FORMAT_DIGIADPCM
        /// </summary>
        WAVE_FORMAT_DIGIADPCM = 0x0036,

        /// <summary>
        /// WAVE_FORMAT_CONTROL_RES_CR10
        /// </summary>
        WAVE_FORMAT_CONTROL_RES_CR10 = 0x0037,

        /// <summary>
        /// WAVE_FORMAT_NMS_VBXADPCM
        /// </summary>
        WAVE_FORMAT_NMS_VBXADPCM = 0x0038,

        /// <summary>
        /// WAVE_FORMAT_CS_IMAADPCM
        /// </summary>
        WAVE_FORMAT_CS_IMAADPCM = 0x0039,

        /// <summary>
        /// WAVE_FORMAT_ECHOSC3
        /// </summary>
        WAVE_FORMAT_ECHOSC3 = 0x003A,

        /// <summary>
        /// WAVE_FORMAT_ROCKWELL_ADPCM
        /// </summary>
        WAVE_FORMAT_ROCKWELL_ADPCM = 0x003B,

        /// <summary>
        /// WAVE_FORMAT_ROCKWELL_DIGITALK
        /// </summary>
        WAVE_FORMAT_ROCKWELL_DIGITALK = 0x003C,

        /// <summary>
        /// WAVE_FORMAT_XEBEC
        /// </summary>
        WAVE_FORMAT_XEBEC = 0x003D,

        /// <summary>
        /// WAVE_FORMAT_G721_ADPCM
        /// </summary>
        WAVE_FORMAT_G721_ADPCM = 0x0040,

        /// <summary>
        /// WAVE_FORMAT_G728_CELP
        /// </summary>
        WAVE_FORMAT_G728_CELP = 0x0041,

        /// <summary>
        /// WAVE_FORMAT_MSG723
        /// </summary>
        WAVE_FORMAT_MSG723 = 0x0042,

        /// <summary>
        /// WAVE_FORMAT_INTEL_G723_1
        /// </summary>
        WAVE_FORMAT_INTEL_G723_1 = 0x0043,

        /// <summary>
        /// WAVE_FORMAT_INTEL_G729
        /// </summary>
        WAVE_FORMAT_INTEL_G729 = 0x0044,

        /// <summary>
        /// WAVE_FORMAT_SHARP_G726
        /// </summary>
        WAVE_FORMAT_SHARP_G726 = 0x0045,

        /// <summary>
        /// WAVE_FORMAT_MPEG
        /// </summary>
        WAVE_FORMAT_MPEG = 0x0050,

        /// <summary>
        /// WAVE_FORMAT_RT24
        /// </summary>
        WAVE_FORMAT_RT24 = 0x0052,

        /// <summary>
        /// WAVE_FORMAT_PAC
        /// </summary>
        WAVE_FORMAT_PAC = 0x0053,

        /// <summary>
        /// WAVE_FORMAT_MPEGLAYER3
        /// </summary>
        WAVE_FORMAT_MPEGLAYER3 = 0x0055,

        /// <summary>
        /// WAVE_FORMAT_LUCENT_G723
        /// </summary>
        WAVE_FORMAT_LUCENT_G723 = 0x0059,

        /// <summary>
        /// WAVE_FORMAT_CIRRUS
        /// </summary>
        WAVE_FORMAT_CIRRUS = 0x0060,

        /// <summary>
        /// WAVE_FORMAT_ESPCM
        /// </summary>
        WAVE_FORMAT_ESPCM = 0x0061,

        /// <summary>
        /// WAVE_FORMAT_VOXWARE
        /// </summary>
        WAVE_FORMAT_VOXWARE = 0x0062,

        /// <summary>
        /// WAVE_FORMAT_CANOPUS_ATRAC
        /// </summary>
        WAVE_FORMAT_CANOPUS_ATRAC = 0x0063,

        /// <summary>
        /// WAVE_FORMAT_G726_ADPCM
        /// </summary>
        WAVE_FORMAT_G726_ADPCM = 0x0064,

        /// <summary>
        /// WAVE_FORMAT_G722_ADPCM
        /// </summary>
        WAVE_FORMAT_G722_ADPCM = 0x0065,

        /// <summary>
        /// WAVE_FORMAT_DSAT
        /// </summary>
        WAVE_FORMAT_DSAT = 0x0066,

        /// <summary>
        /// WAVE_FORMAT_DSAT_DISPLAY
        /// </summary>
        WAVE_FORMAT_DSAT_DISPLAY = 0x0067,

        /// <summary>
        /// WAVE_FORMAT_VOXWARE_BYTE_ALIGNED
        /// </summary>
        WAVE_FORMAT_VOXWARE_BYTE_ALIGNED = 0x0069,

        /// <summary>
        /// WAVE_FORMAT_VOXWARE_AC8
        /// </summary>
        WAVE_FORMAT_VOXWARE_AC8 = 0x0070,

        /// <summary>
        /// WAVE_FORMAT_VOXWARE_AC10
        /// </summary>
        WAVE_FORMAT_VOXWARE_AC10 = 0x0071,

        /// <summary>
        /// WAVE_FORMAT_VOXWARE_AC16
        /// </summary>
        WAVE_FORMAT_VOXWARE_AC16 = 0x0072,

        /// <summary>
        /// WAVE_FORMAT_VOXWARE_AC20
        /// </summary>
        WAVE_FORMAT_VOXWARE_AC20 = 0x0073,

        /// <summary>
        /// WAVE_FORMAT_VOXWARE_RT24
        /// </summary>
        WAVE_FORMAT_VOXWARE_RT24 = 0x0074,

        /// <summary>
        /// WAVE_FORMAT_VOXWARE_RT29
        /// </summary>
        WAVE_FORMAT_VOXWARE_RT29 = 0x0075,

        /// <summary>
        /// WAVE_FORMAT_VOXWARE_RT29HW
        /// </summary>
        WAVE_FORMAT_VOXWARE_RT29HW = 0x0076,

        /// <summary>
        /// WAVE_FORMAT_VOXWARE_VR12
        /// </summary>
        WAVE_FORMAT_VOXWARE_VR12 = 0x0077,

        /// <summary>
        /// WAVE_FORMAT_VOXWARE_VR18
        /// </summary>
        WAVE_FORMAT_VOXWARE_VR18 = 0x0078,

        /// <summary>
        /// WAVE_FORMAT_VOXWARE_TQ40
        /// </summary>
        WAVE_FORMAT_VOXWARE_TQ40 = 0x0079,

        /// <summary>
        /// WAVE_FORMAT_VOXWARE_SC3
        /// </summary>
        WAVE_FORMAT_VOXWARE_SC3 = 0x007A,

        /// <summary>
        /// WAVE_FORMAT_VOXWARE_SC3_1
        /// </summary>
        WAVE_FORMAT_VOXWARE_SC3_1 = 0x007B,

        /// <summary>
        /// WAVE_FORMAT_SOFTSOUND
        /// </summary>
        WAVE_FORMAT_SOFTSOUND = 0x0080,

        /// <summary>
        /// WAVE_FORMAT_VOXWARE_TQ60
        /// </summary>
        WAVE_FORMAT_VOXWARE_TQ60 = 0x0081,

        /// <summary>
        /// WAVE_FORMAT_MSRT24
        /// </summary>
        WAVE_FORMAT_MSRT24 = 0x0082,

        /// <summary>
        /// WAVE_FORMAT_G729A
        /// </summary>
        WAVE_FORMAT_G729A = 0x0083,

        /// <summary>
        /// WAVE_FORMAT_MVI_MVI2
        /// </summary>
        WAVE_FORMAT_MVI_MVI2 = 0x0084,

        /// <summary>
        /// WAVE_FORMAT_DF_G726
        /// </summary>
        WAVE_FORMAT_DF_G726 = 0x0085,

        /// <summary>
        /// WAVE_FORMAT_DF_GSM610
        /// </summary>
        WAVE_FORMAT_DF_GSM610 = 0x0086,

        /// <summary>
        /// WAVE_FORMAT_ISIAUDIO
        /// </summary>
        WAVE_FORMAT_ISIAUDIO = 0x0088,

        /// <summary>
        /// WAVE_FORMAT_ONLIVE
        /// </summary>
        WAVE_FORMAT_ONLIVE = 0x0089,

        /// <summary>
        /// WAVE_FORMAT_MULTITUDE_FT_SX20
        /// </summary>
        WAVE_FORMAT_MULTITUDE_FT_SX20 = 0x008A,

        /// <summary>
        /// WAVE_FORMAT_INFOCOM_ITS_G721_ADPCM
        /// </summary>
        WAVE_FORMAT_INFOCOM_ITS_G721_ADPCM = 0x008B,

        /// <summary>
        /// WAVE_FORMAT_CONVEDIA_G729
        /// </summary>
        WAVE_FORMAT_CONVEDIA_G729 = 0x008C,

        /// <summary>
        /// WAVE_FORMAT_CONGRUENCY
        /// </summary>
        WAVE_FORMAT_CONGRUENCY = 0x008D,

        /// <summary>
        /// WAVE_FORMAT_SBC24
        /// </summary>
        WAVE_FORMAT_SBC24 = 0x0091,

        /// <summary>
        /// WAVE_FORMAT_DOLBY_AC3_SPDIF
        /// </summary>
        WAVE_FORMAT_DOLBY_AC3_SPDIF = 0x0092,

        /// <summary>
        /// WAVE_FORMAT_MEDIASONIC_G723
        /// </summary>
        WAVE_FORMAT_MEDIASONIC_G723 = 0x0093,

        /// <summary>
        /// WAVE_FORMAT_PROSODY_8KBPS
        /// </summary>
        WAVE_FORMAT_PROSODY_8KBPS = 0x0094,

        /// <summary>
        /// WAVE_FORMAT_ZYXEL_ADPCM
        /// </summary>
        WAVE_FORMAT_ZYXEL_ADPCM = 0x0097,

        /// <summary>
        /// WAVE_FORMAT_PHILIPS_LPCBB
        /// </summary>
        WAVE_FORMAT_PHILIPS_LPCBB = 0x0098,

        /// <summary>
        /// WAVE_FORMAT_PACKED
        /// </summary>
        WAVE_FORMAT_PACKED = 0x0099,

        /// <summary>
        /// WAVE_FORMAT_MALDEN_PHONYTALK
        /// </summary>
        WAVE_FORMAT_MALDEN_PHONYTALK = 0x00A0,

        /// <summary>
        /// WAVE_FORMAT_RACAL_RECORDER_GSM
        /// </summary>
        WAVE_FORMAT_RACAL_RECORDER_GSM = 0x00A1,

        /// <summary>
        /// WAVE_FORMAT_RACAL_RECORDER_G720_A
        /// </summary>
        WAVE_FORMAT_RACAL_RECORDER_G720_A = 0x00A2,

        /// <summary>
        /// WAVE_FORMAT_RACAL_RECORDER_G723_1
        /// </summary>
        WAVE_FORMAT_RACAL_RECORDER_G723_1 = 0x00A3,

        /// <summary>
        /// WAVE_FORMAT_RACAL_RECORDER_TETRA_ACELP
        /// </summary>
        WAVE_FORMAT_RACAL_RECORDER_TETRA_ACELP = 0x00A4,

        /// <summary>
        /// WAVE_FORMAT_NEC_AAC
        /// </summary>
        WAVE_FORMAT_NEC_AAC = 0x00B0,

        /// <summary>
        /// WAVE_FORMAT_RAW_AAC1
        /// </summary>
        WAVE_FORMAT_RAW_AAC1 = 0x00FF,

        /// <summary>
        /// WAVE_FORMAT_RHETOREX_ADPCM
        /// </summary>
        WAVE_FORMAT_RHETOREX_ADPCM = 0x0100,

        /// <summary>
        /// WAVE_FORMAT_IRAT
        /// </summary>
        WAVE_FORMAT_IRAT = 0x0101,

        /// <summary>
        /// WAVE_FORMAT_VIVO_G723
        /// </summary>
        WAVE_FORMAT_VIVO_G723 = 0x0111,

        /// <summary>
        /// WAVE_FORMAT_VIVO_SIREN
        /// </summary>
        WAVE_FORMAT_VIVO_SIREN = 0x0112,

        /// <summary>
        /// WAVE_FORMAT_PHILIPS_CELP
        /// </summary>
        WAVE_FORMAT_PHILIPS_CELP = 0x0120,

        /// <summary>
        /// WAVE_FORMAT_PHILIPS_GRUNDIG
        /// </summary>
        WAVE_FORMAT_PHILIPS_GRUNDIG = 0x0121,

        /// <summary>
        /// WAVE_FORMAT_DIGITAL_G723
        /// </summary>
        WAVE_FORMAT_DIGITAL_G723 = 0x0123,

        /// <summary>
        /// WAVE_FORMAT_SANYO_LD_ADPCM
        /// </summary>
        WAVE_FORMAT_SANYO_LD_ADPCM = 0x0125,

        /// <summary>
        /// WAVE_FORMAT_SIPROLAB_ACEPLNET
        /// </summary>
        WAVE_FORMAT_SIPROLAB_ACEPLNET = 0x0130,

        /// <summary>
        /// WAVE_FORMAT_SIPROLAB_ACELP4800
        /// </summary>
        WAVE_FORMAT_SIPROLAB_ACELP4800 = 0x0131,

        /// <summary>
        /// WAVE_FORMAT_SIPROLAB_ACELP8V3
        /// </summary>
        WAVE_FORMAT_SIPROLAB_ACELP8V3 = 0x0132,

        /// <summary>
        /// WAVE_FORMAT_SIPROLAB_G729
        /// </summary>
        WAVE_FORMAT_SIPROLAB_G729 = 0x0133,

        /// <summary>
        /// WAVE_FORMAT_SIPROLAB_G729A
        /// </summary>
        WAVE_FORMAT_SIPROLAB_G729A = 0x0134,

        /// <summary>
        /// WAVE_FORMAT_SIPROLAB_KELVIN
        /// </summary>
        WAVE_FORMAT_SIPROLAB_KELVIN = 0x0135,

        /// <summary>
        /// WAVE_FORMAT_VOICEAGE_AMR
        /// </summary>
        WAVE_FORMAT_VOICEAGE_AMR = 0x0136,

        /// <summary>
        /// WAVE_FORMAT_G726ADPCM
        /// </summary>
        WAVE_FORMAT_G726ADPCM = 0x0140,

        /// <summary>
        /// WAVE_FORMAT_DICTAPHONE_CELP68
        /// </summary>
        WAVE_FORMAT_DICTAPHONE_CELP68 = 0x0141,

        /// <summary>
        /// /WAVE_FORMAT_DICTAPHONE_CELP54
        /// </summary>
        WAVE_FORMAT_DICTAPHONE_CELP54 = 0x0142,

        /// <summary>
        /// WAVE_FORMAT_QUALCOMM_PUREVOICE
        /// </summary>
        WAVE_FORMAT_QUALCOMM_PUREVOICE = 0x0150,

        /// <summary>
        /// WAVE_FORMAT_QUALCOMM_HALFRATE
        /// </summary>
        WAVE_FORMAT_QUALCOMM_HALFRATE = 0x0151,

        /// <summary>
        /// WAVE_FORMAT_TUBGSM
        /// </summary>
        WAVE_FORMAT_TUBGSM = 0x0155,

        /// <summary>
        /// WAVE_FORMAT_MSAUDIO1
        /// </summary>
        WAVE_FORMAT_MSAUDIO1 = 0x0160,

        /// <summary>
        /// WAVE_FORMAT_WMAUDIO2
        /// </summary>
        WAVE_FORMAT_WMAUDIO2 = 0x0161,

        /// <summary>
        /// WAVE_FORMAT_WMAUDIO3
        /// </summary>
        WAVE_FORMAT_WMAUDIO3 = 0x0162,

        /// <summary>
        /// WAVE_FORMAT_WMAUDIO_LOSSLESS
        /// </summary>
        WAVE_FORMAT_WMAUDIO_LOSSLESS = 0x0163,

        /// <summary>
        /// WAVE_FORMAT_WMASPDIF
        /// </summary>
        WAVE_FORMAT_WMASPDIF = 0x0164,

        /// <summary>
        /// WAVE_FORMAT_UNISYS_NAP_ADPCM
        /// </summary>
        WAVE_FORMAT_UNISYS_NAP_ADPCM = 0x0170,

        /// <summary>
        /// WAVE_FORMAT_UNISYS_NAP_ULAW
        /// </summary>
        WAVE_FORMAT_UNISYS_NAP_ULAW = 0x0171,

        /// <summary>
        /// WAVE_FORMAT_UNISYS_NAP_ALAW
        /// </summary>
        WAVE_FORMAT_UNISYS_NAP_ALAW = 0x0172,

        /// <summary>
        /// WAVE_FORMAT_UNISYS_NAP_16K
        /// </summary>
        WAVE_FORMAT_UNISYS_NAP_16K = 0x0173,

        /// <summary>
        /// WAVE_FORMAT_SYCOM_ACM_SYC008
        /// </summary>
        WAVE_FORMAT_SYCOM_ACM_SYC008 = 0x0174,

        /// <summary>
        /// WAVE_FORMAT_SYCOM_ACM_SYC701_G726L
        /// </summary>
        WAVE_FORMAT_SYCOM_ACM_SYC701_G726L = 0x0175,

        /// <summary>
        /// WAVE_FORMAT_SYCOM_ACM_SYC701_CELP54
        /// </summary>
        WAVE_FORMAT_SYCOM_ACM_SYC701_CELP54 = 0x0176,

        /// <summary>
        /// WAVE_FORMAT_SYCOM_ACM_SYC701_CELP68
        /// </summary>
        WAVE_FORMAT_SYCOM_ACM_SYC701_CELP68 = 0x0177,

        /// <summary>
        /// WAVE_FORMAT_KNOWLEDGE_ADVENTURE_ADPCM
        /// </summary>
        WAVE_FORMAT_KNOWLEDGE_ADVENTURE_ADPCM = 0x0178,

        /// <summary>
        /// WAVE_FORMAT_FRAUNHOFER_IIS_MPEG2_AAC
        /// </summary>
        WAVE_FORMAT_FRAUNHOFER_IIS_MPEG2_AAC = 0x0180,

        /// <summary>
        /// WAVE_FORMAT_DTS_DS
        /// </summary>
        WAVE_FORMAT_DTS_DS = 0x0190,

        /// <summary>
        /// WAVE_FORMAT_CREATIVE_ADPCM
        /// </summary>
        WAVE_FORMAT_CREATIVE_ADPCM = 0x0200,

        /// <summary>
        /// WAVE_FORMAT_CREATIVE_FASTSPEECH8
        /// </summary>
        WAVE_FORMAT_CREATIVE_FASTSPEECH8 = 0x0202,

        /// <summary>
        /// WAVE_FORMAT_CREATIVE_FASTSPEECH10
        /// </summary>
        WAVE_FORMAT_CREATIVE_FASTSPEECH10 = 0x0203,

        /// <summary>
        /// WAVE_FORMAT_UHER_ADPCM
        /// </summary>
        WAVE_FORMAT_UHER_ADPCM = 0x0210,

        /// <summary>
        /// WAVE_FORMAT_ULEAD_DV_AUDIO
        /// </summary>
        WAVE_FORMAT_ULEAD_DV_AUDIO = 0x0215,

        /// <summary>
        /// WAVE_FORMAT_ULEAD_DV_AUDIO_1
        /// </summary>
        WAVE_FORMAT_ULEAD_DV_AUDIO_1 = 0x0216,

        /// <summary>
        /// WAVE_FORMAT_QUARTERDECK
        /// </summary>
        WAVE_FORMAT_QUARTERDECK = 0x0220,

        /// <summary>
        /// WAVE_FORMAT_ILINK_VC
        /// </summary>
        WAVE_FORMAT_ILINK_VC = 0x0230,

        /// <summary>
        /// WAVE_FORMAT_RAW_SPORT
        /// </summary>
        WAVE_FORMAT_RAW_SPORT = 0x0240,

        /// <summary>
        /// WAVE_FORMAT_ESST_AC3
        /// </summary>
        WAVE_FORMAT_ESST_AC3 = 0x0241,

        /// <summary>
        /// WAVE_FORMAT_GENERIC_PASSTHRU
        /// </summary>
        WAVE_FORMAT_GENERIC_PASSTHRU = 0x0249,

        /// <summary>
        /// WAVE_FORMAT_IPI_HSX
        /// </summary>
        WAVE_FORMAT_IPI_HSX = 0x0250,

        /// <summary>
        /// WAVE_FORMAT_IPI_RPELP
        /// </summary>
        WAVE_FORMAT_IPI_RPELP = 0x0251,

        /// <summary>
        /// WAVE_FORMAT_CS2
        /// </summary>
        WAVE_FORMAT_CS2 = 0x0260,

        /// <summary>
        /// WAVE_FORMAT_SONY_SCX
        /// </summary>
        WAVE_FORMAT_SONY_SCX = 0x0270,

        /// <summary>
        /// WAVE_FORMAT_SONY_SCY
        /// </summary>
        WAVE_FORMAT_SONY_SCY = 0x0271,

        /// <summary>
        /// WAVE_FORMAT_SONY_ATRAC3
        /// </summary>
        WAVE_FORMAT_SONY_ATRAC3 = 0x0272,

        /// <summary>
        /// WAVE_FORMAT_SONY_SPC
        /// </summary>
        WAVE_FORMAT_SONY_SPC = 0x0273,

        /// <summary>
        /// WAVE_FORMAT_TELUM_AUDIO
        /// </summary>
        WAVE_FORMAT_TELUM_AUDIO = 0x0280,

        /// <summary>
        /// WAVE_FORMAT_TELUM_IA_AUDIO
        /// </summary>
        WAVE_FORMAT_TELUM_IA_AUDIO = 0x0281,

        /// <summary>
        /// WAVE_FORMAT_NORCOM_VOICE_SYSTEMS_ADPCM
        /// </summary>
        WAVE_FORMAT_NORCOM_VOICE_SYSTEMS_ADPCM = 0x0285,

        /// <summary>
        /// WAVE_FORMAT_FM_TOWNS_SND
        /// </summary>
        WAVE_FORMAT_FM_TOWNS_SND = 0x0300,

        /// <summary>
        /// WAVE_FORMAT_MICRONAS
        /// </summary>
        WAVE_FORMAT_MICRONAS = 0x0350,

        /// <summary>
        /// WAVE_FORMAT_MICRONAS_CELP833
        /// </summary>
        WAVE_FORMAT_MICRONAS_CELP833 = 0x0351,

        /// <summary>
        /// WAVE_FORMAT_BTV_DIGITAL
        /// </summary>
        WAVE_FORMAT_BTV_DIGITAL = 0x0400,

        /// <summary>
        /// WAVE_FORMAT_INTEL_MUSIC_CODER
        /// </summary>
        WAVE_FORMAT_INTEL_MUSIC_CODER = 0x0401,

        /// <summary>
        /// WAVE_FORMAT_INDEO_AUDIO
        /// </summary>
        WAVE_FORMAT_INDEO_AUDIO = 0x0402,

        /// <summary>
        /// WAVE_FORMAT_QDESIGN_MUSIC
        /// </summary>
        WAVE_FORMAT_QDESIGN_MUSIC = 0x0450,

        /// <summary>
        /// WAVE_FORMAT_ON2_VP7_AUDIO
        /// </summary>
        WAVE_FORMAT_ON2_VP7_AUDIO = 0x0500,

        /// <summary>
        /// WAVE_FORMAT_ON2_VP6_AUDIO
        /// </summary>
        WAVE_FORMAT_ON2_VP6_AUDIO = 0x0501,

        /// <summary>
        /// WAVE_FORMAT_VME_VMPCM
        /// </summary>
        WAVE_FORMAT_VME_VMPCM = 0x0680,

        /// <summary>
        /// WAVE_FORMAT_TPC
        /// </summary>
        WAVE_FORMAT_TPC = 0x0681,

        /// <summary>
        /// WAVE_FORMAT_LIGHTWAVE_LOSSLESS
        /// </summary>
        WAVE_FORMAT_LIGHTWAVE_LOSSLESS = 0x08AE,

        /// <summary>
        /// WAVE_FORMAT_OLIGSM
        /// </summary>
        WAVE_FORMAT_OLIGSM = 0x1000,

        /// <summary>
        /// WAVE_FORMAT_OLIADPCM
        /// </summary>
        WAVE_FORMAT_OLIADPCM = 0x1001,

        /// <summary>
        /// WAVE_FORMAT_OLICELP
        /// </summary>
        WAVE_FORMAT_OLICELP = 0x1002,

        /// <summary>
        /// WAVE_FORMAT_OLISBC
        /// </summary>
        WAVE_FORMAT_OLISBC = 0x1003,

        /// <summary>
        /// WAVE_FORMAT_OLIOPR
        /// </summary>
        WAVE_FORMAT_OLIOPR = 0x1004,

        /// <summary>
        /// WAVE_FORMAT_LH_CODEC
        /// </summary>
        WAVE_FORMAT_LH_CODEC = 0x1100,

        /// <summary>
        /// WAVE_FORMAT_LH_CODEC_CELP
        /// </summary>
        WAVE_FORMAT_LH_CODEC_CELP = 0x1101,

        /// <summary>
        /// WAVE_FORMAT_LH_CODEC_SBC8
        /// </summary>
        WAVE_FORMAT_LH_CODEC_SBC8 = 0x1102,

        /// <summary>
        /// WAVE_FORMAT_LH_CODEC_SBC12
        /// </summary>
        WAVE_FORMAT_LH_CODEC_SBC12 = 0x1103,

        /// <summary>
        /// WAVE_FORMAT_LH_CODEC_SBC16
        /// </summary>
        WAVE_FORMAT_LH_CODEC_SBC16 = 0x1104,

        /// <summary>
        /// WAVE_FORMAT_NORRIS
        /// </summary>
        WAVE_FORMAT_NORRIS = 0x1400,

        /// <summary>
        /// WAVE_FORMAT_ISIAUDIO_2
        /// </summary>
        WAVE_FORMAT_ISIAUDIO_2 = 0x1401,

        /// <summary>
        /// WAVE_FORMAT_SOUNDSPACE_MUSICOMPRESS
        /// </summary>
        WAVE_FORMAT_SOUNDSPACE_MUSICOMPRESS = 0x1500,

        /// <summary>
        /// WAVE_FORMAT_MPEG_ADTS_AAC
        /// </summary>
        WAVE_FORMAT_MPEG_ADTS_AAC = 0x1600,

        /// <summary>
        /// WAVE_FORMAT_MPEG_RAW_AAC
        /// </summary>
        WAVE_FORMAT_MPEG_RAW_AAC = 0x1601,

        /// <summary>
        /// WAVE_FORMAT_MPEG_LOAS
        /// </summary>
        WAVE_FORMAT_MPEG_LOAS = 0x1602,

        /// <summary>
        /// WAVE_FORMAT_NOKIA_MPEG_ADTS_AAC
        /// </summary>
        WAVE_FORMAT_NOKIA_MPEG_ADTS_AAC = 0x1608,

        /// <summary>
        /// WAVE_FORMAT_NOKIA_MPEG_RAW_AAC
        /// </summary>
        WAVE_FORMAT_NOKIA_MPEG_RAW_AAC = 0x1609,

        /// <summary>
        /// WAVE_FORMAT_VODAFONE_MPEG_ADTS_AAC
        /// </summary>
        WAVE_FORMAT_VODAFONE_MPEG_ADTS_AAC = 0x160A,

        /// <summary>
        /// WAVE_FORMAT_VODAFONE_MPEG_RAW_AAC
        /// </summary>
        WAVE_FORMAT_VODAFONE_MPEG_RAW_AAC = 0x160B,

        /// <summary>
        /// WAVE_FORMAT_MPEG_HEAAC
        /// </summary>
        WAVE_FORMAT_MPEG_HEAAC = 0x1610,

        /// <summary>
        /// WAVE_FORMAT_VOXWARE_RT24_SPEECH
        /// </summary>
        WAVE_FORMAT_VOXWARE_RT24_SPEECH = 0x181C,

        /// <summary>
        /// WAVE_FORMAT_SONICFOUNDRY_LOSSLESS
        /// </summary>
        WAVE_FORMAT_SONICFOUNDRY_LOSSLESS = 0x1971,

        /// <summary>
        /// WAVE_FORMAT_INNINGS_TELECOM_ADPCM
        /// </summary>
        WAVE_FORMAT_INNINGS_TELECOM_ADPCM = 0x1979,

        /// <summary>
        /// WAVE_FORMAT_LUCENT_SX8300P
        /// </summary>
        WAVE_FORMAT_LUCENT_SX8300P = 0x1C07,

        /// <summary>
        /// WAVE_FORMAT_LUCENT_SX5363S
        /// </summary>
        WAVE_FORMAT_LUCENT_SX5363S = 0x1C0C,

        /// <summary>
        /// WAVE_FORMAT_CUSEEME
        /// </summary>
        WAVE_FORMAT_CUSEEME = 0x1F03,

        /// <summary>
        /// WAVE_FORMAT_NTCSOFT_ALF2CM_ACM
        /// </summary>
        WAVE_FORMAT_NTCSOFT_ALF2CM_ACM = 0x1FC4,

        /// <summary>
        /// WAVE_FORMAT_DVM
        /// </summary>
        WAVE_FORMAT_DVM = 0x2000,

        /// <summary>
        /// WAVE_FORMAT_DTS2
        /// </summary>
        WAVE_FORMAT_DTS2 = 0x2001,

        /// <summary>
        /// WAVE_FORMAT_MAKEAVIS
        /// </summary>
        WAVE_FORMAT_MAKEAVIS = 0x3313,

        /// <summary>
        /// WAVE_FORMAT_DIVIO_MPEG4_AAC
        /// </summary>
        WAVE_FORMAT_DIVIO_MPEG4_AAC = 0x4143,

        /// <summary>
        /// WAVE_FORMAT_NOKIA_ADAPTIVE_MULTIRATE
        /// </summary>
        WAVE_FORMAT_NOKIA_ADAPTIVE_MULTIRATE = 0x4201,

        /// <summary>
        /// WAVE_FORMAT_DIVIO_G726
        /// </summary>
        WAVE_FORMAT_DIVIO_G726 = 0x4243,

        /// <summary>
        /// WAVE_FORMAT_LEAD_SPEECH
        /// </summary>
        WAVE_FORMAT_LEAD_SPEECH = 0x434C,

        /// <summary>
        /// WAVE_FORMAT_LEAD_VORBIS
        /// </summary>
        WAVE_FORMAT_LEAD_VORBIS = 0x564C,

        /// <summary>
        /// WAVE_FORMAT_WAVPACK_AUDIO
        /// </summary>
        WAVE_FORMAT_WAVPACK_AUDIO = 0x5756,

        /// <summary>
        /// WAVE_FORMAT_ALAC
        /// </summary>
        WAVE_FORMAT_ALAC = 0x6C61,

        /// <summary>
        /// WAVE_FORMAT_OGG_VORBIS_MODE_1
        /// </summary>
        WAVE_FORMAT_OGG_VORBIS_MODE_1 = 0x674F,

        /// <summary>
        /// WAVE_FORMAT_OGG_VORBIS_MODE_2
        /// </summary>
        WAVE_FORMAT_OGG_VORBIS_MODE_2 = 0x6750,

        /// <summary>
        /// WAVE_FORMAT_OGG_VORBIS_MODE_3
        /// </summary>
        WAVE_FORMAT_OGG_VORBIS_MODE_3 = 0x6751,

        /// <summary>
        /// WAVE_FORMAT_OGG_VORBIS_MODE_1_PLUS
        /// </summary>
        WAVE_FORMAT_OGG_VORBIS_MODE_1_PLUS = 0x676F,

        /// <summary>
        /// WAVE_FORMAT_OGG_VORBIS_MODE_2_PLUS
        /// </summary>
        WAVE_FORMAT_OGG_VORBIS_MODE_2_PLUS = 0x6770,

        /// <summary>
        /// WAVE_FORMAT_OGG_VORBIS_MODE_3_PLUS
        /// </summary>
        WAVE_FORMAT_OGG_VORBIS_MODE_3_PLUS = 0x6771,

        /// <summary>
        /// /WAVE_FORMAT_3COM_NBX
        /// </summary>
        WAVE_FORMAT_3COM_NBX = 0x7000,

        /// <summary>
        /// WAVE_FORMAT_OPUS
        /// </summary>
        WAVE_FORMAT_OPUS = 0x704F,

        /// <summary>
        /// WAVE_FORMAT_FAAD_AAC
        /// </summary>
        WAVE_FORMAT_FAAD_AAC = 0x706D,

        /// <summary>
        /// WAVE_FORMAT_AMR_NB
        /// </summary>
        WAVE_FORMAT_AMR_NB = 0x7361,

        /// <summary>
        /// WAVE_FORMAT_AMR_WB
        /// </summary>
        WAVE_FORMAT_AMR_WB = 0x7362,

        /// <summary>
        /// WAVE_FORMAT_AMR_WP
        /// </summary>
        WAVE_FORMAT_AMR_WP = 0x7363,

        /// <summary>
        /// WAVE_FORMAT_GSM_AMR_CBR
        /// </summary>
        WAVE_FORMAT_GSM_AMR_CBR = 0x7A21,

        /// <summary>
        /// WAVE_FORMAT_GSM_AMR_VBR_SID
        /// </summary>
        WAVE_FORMAT_GSM_AMR_VBR_SID = 0x7A22,

        /// <summary>
        /// WAVE_FORMAT_COMVERSE_INFOSYS_G723_1
        /// </summary>
        WAVE_FORMAT_COMVERSE_INFOSYS_G723_1 = 0xA100,

        /// <summary>
        /// WAVE_FORMAT_COMVERSE_INFOSYS_AVQSBC
        /// </summary>
        WAVE_FORMAT_COMVERSE_INFOSYS_AVQSBC = 0xA101,

        /// <summary>
        /// WAVE_FORMAT_COMVERSE_INFOSYS_SBC
        /// </summary>
        WAVE_FORMAT_COMVERSE_INFOSYS_SBC = 0xA102,

        /// <summary>
        /// WAVE_FORMAT_SYMBOL_G729_A
        /// </summary>
        WAVE_FORMAT_SYMBOL_G729_A = 0xA103,

        /// <summary>
        /// WAVE_FORMAT_VOICEAGE_AMR_WB
        /// </summary>
        WAVE_FORMAT_VOICEAGE_AMR_WB = 0xA104,

        /// <summary>
        /// WAVE_FORMAT_INGENIENT_G726
        /// </summary>
        WAVE_FORMAT_INGENIENT_G726 = 0xA105,

        /// <summary>
        /// WAVE_FORMAT_MPEG4_AAC
        /// </summary>
        WAVE_FORMAT_MPEG4_AAC = 0xA106,

        /// <summary>
        /// WAVE_FORMAT_ENCORE_G726
        /// </summary>
        WAVE_FORMAT_ENCORE_G726 = 0xA107,

        /// <summary>
        /// WAVE_FORMAT_ZOLL_ASAO
        /// </summary>
        WAVE_FORMAT_ZOLL_ASAO = 0xA108,

        /// <summary>
        /// WAVE_FORMAT_SPEEX_VOICE
        /// </summary>
        WAVE_FORMAT_SPEEX_VOICE = 0xA109,

        /// <summary>
        /// WAVE_FORMAT_VIANIX_MASC
        /// </summary>
        WAVE_FORMAT_VIANIX_MASC = 0xA10A,

        /// <summary>
        /// WAVE_FORMAT_WM9_SPECTRUM_ANALYZER
        /// </summary>
        WAVE_FORMAT_WM9_SPECTRUM_ANALYZER = 0xA10B,

        /// <summary>
        /// WAVE_FORMAT_WMF_SPECTRUM_ANAYZER
        /// </summary>
        WAVE_FORMAT_WMF_SPECTRUM_ANAYZER = 0xA10C,

        /// <summary>
        /// WAVE_FORMAT_GSM_610
        /// </summary>
        WAVE_FORMAT_GSM_610 = 0xA10D,

        /// <summary>
        /// WAVE_FORMAT_GSM_620
        /// </summary>
        WAVE_FORMAT_GSM_620 = 0xA10E,

        /// <summary>
        /// WAVE_FORMAT_GSM_660
        /// </summary>
        WAVE_FORMAT_GSM_660 = 0xA10F,

        /// <summary>
        /// WAVE_FORMAT_GSM_690
        /// </summary>
        WAVE_FORMAT_GSM_690 = 0xA110,

        /// <summary>
        /// WAVE_FORMAT_GSM_ADAPTIVE_MULTIRATE_WB
        /// </summary>
        WAVE_FORMAT_GSM_ADAPTIVE_MULTIRATE_WB = 0xA111,

        /// <summary>
        /// WAVE_FORMAT_POLYCOM_G722
        /// </summary>
        WAVE_FORMAT_POLYCOM_G722 = 0xA112,

        /// <summary>
        /// WAVE_FORMAT_POLYCOM_G728
        /// </summary>
        WAVE_FORMAT_POLYCOM_G728 = 0xA113,

        /// <summary>
        /// WAVE_FORMAT_POLYCOM_G729_A
        /// </summary>
        WAVE_FORMAT_POLYCOM_G729_A = 0xA114,

        /// <summary>
        /// WAVE_FORMAT_POLYCOM_SIREN
        /// </summary>
        WAVE_FORMAT_POLYCOM_SIREN = 0xA115,

        /// <summary>
        /// WAVE_FORMAT_GLOBAL_IP_ILBC
        /// </summary>
        WAVE_FORMAT_GLOBAL_IP_ILBC = 0xA116,

        /// <summary>
        /// WAVE_FORMAT_RADIOTIME_TIME_SHIFT_RADIO
        /// </summary>
        WAVE_FORMAT_RADIOTIME_TIME_SHIFT_RADIO = 0xA117,

        /// <summary>
        /// WAVE_FORMAT_NICE_ACA
        /// </summary>
        WAVE_FORMAT_NICE_ACA = 0xA118,

        /// <summary>
        /// WAVE_FORMAT_NICE_ADPCM
        /// </summary>
        WAVE_FORMAT_NICE_ADPCM = 0xA119,

        /// <summary>
        /// WAVE_FORMAT_VOCORD_G721
        /// </summary>
        WAVE_FORMAT_VOCORD_G721 = 0xA11A,

        /// <summary>
        /// WAVE_FORMAT_VOCORD_G726
        /// </summary>
        WAVE_FORMAT_VOCORD_G726 = 0xA11B,

        /// <summary>
        /// WAVE_FORMAT_VOCORD_G722_1
        /// </summary>
        WAVE_FORMAT_VOCORD_G722_1 = 0xA11C,

        /// <summary>
        /// WAVE_FORMAT_VOCORD_G728
        /// </summary>
        WAVE_FORMAT_VOCORD_G728 = 0xA11D,

        /// <summary>
        /// WAVE_FORMAT_VOCORD_G729
        /// </summary>
        WAVE_FORMAT_VOCORD_G729 = 0xA11E,

        /// <summary>
        /// WAVE_FORMAT_VOCORD_G729_A
        /// </summary>
        WAVE_FORMAT_VOCORD_G729_A = 0xA11F,

        /// <summary>
        /// WAVE_FORMAT_VOCORD_G723_1
        /// </summary>
        WAVE_FORMAT_VOCORD_G723_1 = 0xA120,

        /// <summary>
        /// WAVE_FORMAT_VOCORD_LBC
        /// </summary>
        WAVE_FORMAT_VOCORD_LBC = 0xA121,

        /// <summary>
        /// WAVE_FORMAT_NICE_G728
        /// </summary>
        WAVE_FORMAT_NICE_G728 = 0xA122,

        /// <summary>
        /// WAVE_FORMAT_FRACE_TELECOM_G729
        /// </summary>
        WAVE_FORMAT_FRACE_TELECOM_G729 = 0xA123,

        /// <summary>
        /// WAVE_FORMAT_CODIAN
        /// </summary>
        WAVE_FORMAT_CODIAN = 0xA124,

        /// <summary>
        /// WAVE_FORMAT_FLAC
        /// </summary>
        WAVE_FORMAT_FLAC = 0xF1AC,

        /// <summary>
        /// WAVE_FORMAT_EXTENSIBLE
        /// </summary>
        WAVE_FORMAT_EXTENSIBLE = 0xFFFE,

        /// <summary>
        /// WAVE_FORMAT_DEVELOPMENT
        /// </summary>
        WAVE_FORMAT_DEVELOPMENT = 0xFFFF,
    }
}
