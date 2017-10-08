using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Office.Word
{
    /// <summary>
    /// BuiltinStyle
    /// </summary>
    public enum BuiltinStyle
    {
        /// <summary>
        /// 
        /// </summary>
        TocHeading = -267,
        /// <summary>
        /// 
        /// </summary>
        Bibliography = -266,
        /// <summary>
        /// 
        /// </summary>
        BookTitle = -265,
        /// <summary>
        /// 
        /// </summary>
        IntenseReference = -264,
        /// <summary>
        /// 
        /// </summary>
        SubtleReference = -263,
        /// <summary>
        /// 
        /// </summary>
        IntenseEmphasis = -262,
        /// <summary>
        /// 
        /// </summary>
        SubtleEmphasis = -261,
        /// <summary>
        /// 
        /// </summary>
        IntenseQuote = -182,
        /// <summary>
        /// 
        /// </summary>
        Quote = -181,
        /// <summary>
        /// 
        /// </summary>
        ListParagraph = -180,
        /// <summary>
        /// 
        /// </summary>
        TableMediumList1Accent1 = -178,
        /// <summary>
        /// 
        /// </summary>
        TableMediumShading2Accent1 = -177,
        /// <summary>
        /// 
        /// </summary>
        TableMediumShading1Accent1 = -176,
        /// <summary>
        /// 
        /// </summary>
        TableLightGridAccent1 = -175,
        /// <summary>
        /// 
        /// </summary>
        TableLightListAccent1 = -174,
        /// <summary>
        /// 
        /// </summary>
        TableLightShadingAccent1 = -173,
        /// <summary>
        /// 
        /// </summary>
        TableColorfulGrid = -172,
        /// <summary>
        /// 
        /// </summary>
        TableColorfulList = -171,
        /// <summary>
        /// 
        /// </summary>
        TableColorfulShading = -170,
        /// <summary>
        /// 
        /// </summary>
        TableDarkList = -169,
        /// <summary>
        /// 
        /// </summary>
        TableMediumGrid3 = -168,
        /// <summary>
        /// 
        /// </summary>
        TableMediumGrid2 = -167,
        /// <summary>
        /// 
        /// </summary>
        TableMediumGrid1 = -166,
        /// <summary>
        /// 
        /// </summary>
        TableMediumList2 = -165,
        /// <summary>
        /// 
        /// </summary>
        TableMediumList1 = -164,
        /// <summary>
        /// 
        /// </summary>
        TableMediumShading2 = -163,
        /// <summary>
        /// 
        /// </summary>
        TableMediumShading1 = -162,
        /// <summary>
        /// 
        /// </summary>
        TableLightGrid = -161,
        /// <summary>
        /// 
        /// </summary>
        TableLightList = -160,
        /// <summary>
        /// 
        /// </summary>
        TableLightShading = -159,
        /// <summary>
        /// 
        /// </summary>
        NormalObject = -158,
        /// <summary>
        /// 
        /// </summary>
        NormalTable = -106,
        /// <summary>
        /// 
        /// </summary>
        HtmlVar = -105,
        /// <summary>
        /// 
        /// </summary>
        HtmlTt = -104,
        /// <summary>
        /// 
        /// </summary>
        HtmlSamp = -103,
        /// <summary>
        /// 
        /// </summary>
        HtmlPre = -102,
        /// <summary>
        /// 
        /// </summary>
        HtmlKbd = -101,
        /// <summary>
        /// 
        /// </summary>
        HtmlDfn = -100,
        /// <summary>
        /// 
        /// </summary>
        HtmlCode = -99,
        /// <summary>
        /// 
        /// </summary>
        HtmlCite = -98,
        /// <summary>
        /// 
        /// </summary>
        HtmlAddress = -97,
        /// <summary>
        /// 
        /// </summary>
        HtmlAcronym = -96,
        /// <summary>
        /// 
        /// </summary>
        HtmlNormal = -95,
        /// <summary>
        /// 
        /// </summary>
        PlainText = -91,
        /// <summary>
        /// 
        /// </summary>
        NavPane = -90,
        /// <summary>
        /// 
        /// </summary>
        Emphasis = -89,
        /// <summary>
        /// 
        /// </summary>
        Strong = -88,
        /// <summary>
        /// 
        /// </summary>
        HyperlinkFollowed = -87,
        /// <summary>
        /// 
        /// </summary>
        Hyperlink = -86,
        /// <summary>
        /// 
        /// </summary>
        BlockQuotation = -85,
        /// <summary>
        /// 
        /// </summary>
        BodyTextIndent3 = -84,
        /// <summary>
        /// 
        /// </summary>
        BodyTextIndent2 = -83,
        /// <summary>
        /// 
        /// </summary>
        BodyText3 = -82,
        /// <summary>
        /// 
        /// </summary>
        BodyText2 = -81,
        /// <summary>
        /// 
        /// </summary>
        NoteHeading = -80,
        /// <summary>
        /// 
        /// </summary>
        BodyTextFirstIndent2 = -79,
        /// <summary>
        /// 
        /// </summary>
        BodyTextFirstIndent = -78,
        /// <summary>
        /// 
        /// </summary>
        Date = -77,
        /// <summary>
        /// 
        /// </summary>
        Salutation = -76,
        /// <summary>
        /// 
        /// </summary>
        Subtitle = -75,
        /// <summary>
        /// 
        /// </summary>
        MessageHeader = -74,
        /// <summary>
        /// 
        /// </summary>
        ListContinue5 = -73,
        /// <summary>
        /// 
        /// </summary>
        ListContinue4 = -72,
        /// <summary>
        /// 
        /// </summary>
        ListContinue3 = -71,
        /// <summary>
        /// 
        /// </summary>
        ListContinue2 = -70,
        /// <summary>
        /// 
        /// </summary>
        ListContinue = -69,
        /// <summary>
        /// 
        /// </summary>
        BodyTextIndent = -68,
        /// <summary>
        /// 
        /// </summary>
        BodyText = -67,
        /// <summary>
        /// 
        /// </summary>
        DefaultParagraphFont = -66,
        /// <summary>
        /// 
        /// </summary>
        Signature = -65,
        /// <summary>
        /// 
        /// </summary>
        Closing = -64,
        /// <summary>
        /// 
        /// </summary>
        Title = -63,
        /// <summary>
        /// 
        /// </summary>
        ListNumber5 = -62,
        /// <summary>
        /// 
        /// </summary>
        ListNumber4 = -61,
        /// <summary>
        /// 
        /// </summary>
        ListNumber3 = -60,
        /// <summary>
        /// 
        /// </summary>
        ListNumber2 = -59,
        /// <summary>
        /// 
        /// </summary>
        ListBullet5 = -58,
        /// <summary>
        /// 
        /// </summary>
        ListBullet4 = -57,
        /// <summary>
        /// 
        /// </summary>
        ListBullet3 = -56,
        /// <summary>
        /// 
        /// </summary>
        ListBullet2 = -55,
        /// <summary>
        /// 
        /// </summary>
        List5 = -54,
        /// <summary>
        /// 
        /// </summary>
        List4 = -53,
        /// <summary>
        /// 
        /// </summary>
        List3 = -52,
        /// <summary>
        /// 
        /// </summary>
        List2 = -51,
        /// <summary>
        /// 
        /// </summary>
        ListNumber = -50,
        /// <summary>
        /// 
        /// </summary>
        ListBullet = -49,
        /// <summary>
        /// 
        /// </summary>
        List = -48,
        /// <summary>
        /// 
        /// </summary>
        TOAHeading = -47,
        /// <summary>
        /// 
        /// </summary>
        MacroText = -46,
        /// <summary>
        /// 
        /// </summary>
        TableOfAuthorities = -45,
        /// <summary>
        /// 
        /// </summary>
        EndnoteText = -44,
        /// <summary>
        /// 
        /// </summary>
        EndnoteReference = -43,
        /// <summary>
        /// 
        /// </summary>
        PageNumber = -42,
        /// <summary>
        /// 
        /// </summary>
        LineNumber = -41,
        /// <summary>
        /// 
        /// </summary>
        CommentReference = -40,
        /// <summary>
        /// 
        /// </summary>
        FootnoteReference = -39,
        /// <summary>
        /// 
        /// </summary>
        EnvelopeReturn = -38,
        /// <summary>
        /// 
        /// </summary>
        EnvelopeAddress = -37,
        /// <summary>
        /// 
        /// </summary>
        TableOfFigures = -36,
        /// <summary>
        /// 
        /// </summary>
        Caption = -35,
        /// <summary>
        /// 
        /// </summary>
        IndexHeading = -34,
        /// <summary>
        /// 
        /// </summary>
        Footer = -33,
        /// <summary>
        /// 
        /// </summary>
        Header = -32,
        /// <summary>
        /// 
        /// </summary>
        CommentText = -31,
        /// <summary>
        /// 
        /// </summary>
        FootnoteText = -30,
        /// <summary>
        /// 
        /// </summary>
        NormalIndent = -29,
        /// <summary>
        /// 
        /// </summary>
        TOC9 = -28,
        /// <summary>
        /// 
        /// </summary>
        TOC8 = -27,
        /// <summary>
        /// 
        /// </summary>
        TOC7 = -26,
        /// <summary>
        /// 
        /// </summary>
        TOC6 = -25,
        /// <summary>
        /// 
        /// </summary>
        TOC5 = -24,
        /// <summary>
        /// 
        /// </summary>
        TOC4 = -23,
        /// <summary>
        /// 
        /// </summary>
        TOC3 = -22,
        /// <summary>
        /// 
        /// </summary>
        TOC2 = -21,
        /// <summary>
        /// 
        /// </summary>
        TOC1 = -20,
        /// <summary>
        /// 
        /// </summary>
        Index9 = -19,
        /// <summary>
        /// 
        /// </summary>
        Index8 = -18,
        /// <summary>
        /// 
        /// </summary>
        Index7 = -17,
        /// <summary>
        /// 
        /// </summary>
        Index6 = -16,
        /// <summary>
        /// 
        /// </summary>
        Index5 = -15,
        /// <summary>
        /// 
        /// </summary>
        Index4 = -14,
        /// <summary>
        /// 
        /// </summary>
        Index3 = -13,
        /// <summary>
        /// 
        /// </summary>
        Index2 = -12,
        /// <summary>
        /// 
        /// </summary>
        Index1 = -11,
        /// <summary>
        /// 
        /// </summary>
        Heading9 = -10,
        /// <summary>
        /// 
        /// </summary>
        Heading8 = -9,
        /// <summary>
        /// 
        /// </summary>
        Heading7 = -8,
        /// <summary>
        /// 
        /// </summary>
        Heading6 = -7,
        /// <summary>
        /// 
        /// </summary>
        Heading5 = -6,
        /// <summary>
        /// 
        /// </summary>,
        Heading4 = -5,
        /// <summary>
        /// 
        /// </summary>,
        Heading3 = -4,
        /// <summary>
        /// 
        /// </summary>
        Heading2 = -3,
        /// <summary>
        /// 
        /// </summary>
        Heading1 = -2,
        /// <summary>
        /// 
        /// </summary>
        Normal = -1
    }
}
