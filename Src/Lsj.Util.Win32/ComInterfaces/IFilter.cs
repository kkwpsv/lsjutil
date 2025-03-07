using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Scans documents for text and properties (also called attributes).
    /// It extracts chunks of text from these documents, filtering out embedded formatting and retaining information about the position of the text.
    /// It also extracts chunks of values, which are properties of an entire document or of well-defined parts of a document.
    /// <see cref="IFilter"/> provides the foundation for building higher-level applications such as document indexers and application-independent viewers.
    /// </para>
    /// <para>
    /// For introductory information about how the <see cref="IFilter"/> interface works with documents and document properties, see Properties of Documents.
    /// For a synopsis and an example of how the <see cref="IFilter"/> interface processes a document, see Property Filtering and Property Indexing.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/filter/nn-filter-ifilter"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// <see cref="IFilter"/> components for Indexing Service run in the Local Security context and should be written to manage buffers and to stack correctly.
    /// All string copies must have explicit checks to guard against buffer overruns.
    /// You should always verify the allocated size of the buffer and test the size of the data against the size of the buffer.
    /// </para>
    /// <para>
    /// Previously, data returned by <see cref="IFilter"/> was only indexed lexically.
    /// Starting with Windows 11, version 26100, data returned <see cref="IFilter"/> is also semantically indexed.
    /// For example, users searching for "pasta" might also get results for "lasagna".
    /// Also starting with Windows 11, version 26100, the <see cref="IPixelFilter"/> enables semantic indexing of images.
    /// </para>
    /// </remarks>
    public unsafe struct IFilter
    {
        IntPtr* _vTable;
    }
}
