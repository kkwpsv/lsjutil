using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using Lsj.Util.Win32.Marshals;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.Dxgidebug;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// This interface controls the debug information queue, and can only be used if the debug layer is turned on.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nn-dxgidebug-idxgiinfoqueue"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This interface is obtained by calling the <see cref="DXGIGetDebugInterface"/> function.
    /// </para>
    /// <para>
    /// For more info about the debug layer, see Debug Layer.
    /// </para>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows8)]
    [ComInterface(IID = "D67441C7-672A-476f-9E82-CD55B44949CE", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 38, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IDXGIInfoQueue
    {
        IntPtr* _vTable;

        /// <summary>
        /// Sets the maximum number of messages that can be added to the message queue.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that sets the limit on the number of messages.
        /// </param>
        /// <param name="MessageCountLimit">
        /// The maximum number of messages that can be added to the queue.
        /// –1 means no limit.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public HRESULT SetMessageCountLimit([In] DXGI_DEBUG_ID Producer, [In] UINT64 MessageCountLimit)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, UINT64, HRESULT>)_vTable[3])(thisPtr, Producer, MessageCountLimit);
            }
        }

        /// <summary>
        /// Clears all messages from the message queue.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that clears the messages.
        /// </param>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public void ClearStoredMessages([In] DXGI_DEBUG_ID Producer)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, void>)_vTable[4])(thisPtr, Producer);
            }
        }

        /// <summary>
        /// Gets a message from the message queue.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that gets the message.
        /// </param>
        /// <param name="MessageIndex">
        /// An index into the message queue after an optional retrieval filter has been applied.
        /// This can be between 0 and the number of messages in the message queue that pass through the retrieval filter.
        /// Call <see cref="GetNumStoredMessagesAllowedByRetrievalFilters"/> to obtain this number.
        /// 0 is the message at the beginning of the message queue.
        /// </param>
        /// <param name="pMessage">
        /// A pointer to a <see cref="DXGI_INFO_QUEUE_MESSAGE"/> structure that describes the message.
        /// </param>
        /// <param name="pMessageByteLength">
        /// A pointer to a variable that receives the size, in bytes,
        /// of the message description that <paramref name="pMessage"/> points to.
        /// This size includes the size of the <see cref="DXGI_INFO_QUEUE_MESSAGE"/> structure in bytes.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method doesn't remove any messages from the message queue.
        /// </para>
        /// <para>
        /// This method gets a message from the message queue after an optional retrieval filter has been applied.
        /// </para>
        /// <para>
        /// Call this method twice to retrieve a message,
        /// first to obtain the size of the message and second to get the message.
        /// Here is a typical example:
        /// </para>
        /// <code>
        /// // Get the size of the message.
        /// SIZE_T messageLength = 0;
        /// HRESULT hr = pInfoQueue->GetMessage(DXGI_DEBUG_ALL, 0, NULL, &amp;messageLength);
        /// if(hr == S_FALSE){
        /// 
        ///     // Allocate space and get the message.
        ///     DXGI_INFO_QUEUE_MESSAGE * pMessage = (DXGI_INFO_QUEUE_MESSAGE*)malloc(messageLength);
        ///     hr = pInfoQueue->GetMessage(DXGI_DEBUG_ALL, 0, pMessage, &amp;messageLength);
        ///     
        ///     // Do something with the message and free it
        ///     if(hr == S_OK){
        ///     
        ///         // ...
        ///         // ...
        ///         // ...
        ///         free(pMessage);
        ///     }
        /// }
        /// </code>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public HRESULT GetMessage([In] DXGI_DEBUG_ID Producer, [In] UINT64 MessageIndex, [In][Out] ref DXGI_INFO_QUEUE_MESSAGE pMessage, [In][Out] ref SIZE_T pMessageByteLength)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, UINT64, ref DXGI_INFO_QUEUE_MESSAGE, ref SIZE_T, HRESULT>)_vTable[5])
                    (thisPtr, Producer, MessageIndex, ref pMessage, ref pMessageByteLength);
            }
        }

        /// <summary>
        /// Gets the number of messages that can pass through a retrieval filter.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that gets the number.
        /// </param>
        /// <returns>
        /// Returns the number of messages that can pass through a retrieval filter.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public UINT64 GetNumStoredMessagesAllowedByRetrievalFilters([In] DXGI_DEBUG_ID Producer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, UINT64>)_vTable[6])(thisPtr, Producer);
            }
        }

        /// <summary>
        /// Gets the number of messages currently stored in the message queue.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that clears the messages.
        /// </param>
        /// <returns>
        /// Returns the number of messages that can pass through a retrieval filter.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public UINT64 GetNumStoredMessages([In] DXGI_DEBUG_ID Producer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, UINT64>)_vTable[7])(thisPtr, Producer);
            }
        }

        /// <summary>
        /// Gets the number of messages that were discarded due to the message count limit.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that gets the number.
        /// </param>
        /// <returns>
        /// Returns the number of messages that were discarded.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Get and set the message count limit
        /// with <see cref="GetMessageCountLimit"/> and <see cref="SetMessageCountLimit"/>, respectively.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public UINT64 GetNumMessagesDiscardedByMessageCountLimit([In] DXGI_DEBUG_ID Producer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, UINT64>)_vTable[8])(thisPtr, Producer);
            }
        }

        /// <summary>
        /// Gets the maximum number of messages that can be added to the message queue.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that gets the number.
        /// </param>
        /// <returns>
        /// Returns the maximum number of messages that can be added to the queue.
        /// –1 means no limit.
        /// </returns>
        /// <remarks>
        /// <para>
        /// When the number of messages in the message queue reaches the maximum limit,
        /// new messages coming in push old messages out.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public UINT64 GetMessageCountLimit([In] DXGI_DEBUG_ID Producer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, UINT64>)_vTable[9])(thisPtr, Producer);
            }
        }

        /// <summary>
        /// Gets the number of messages that a storage filter allowed to pass through.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that gets the number.
        /// </param>
        /// <returns>
        /// Returns the number of messages allowed by a storage filter.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public UINT64 GetNumMessagesAllowedByStorageFilter([In] DXGI_DEBUG_ID Producer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, UINT64>)_vTable[10])(thisPtr, Producer);
            }
        }

        /// <summary>
        /// Gets the number of messages that were denied passage through a storage filter.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that gets the number.
        /// </param>
        /// <returns>
        /// Returns the number of messages denied by a storage filter.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public UINT64 GetNumMessagesDeniedByStorageFilter([In] DXGI_DEBUG_ID Producer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, UINT64>)_vTable[11])(thisPtr, Producer);
            }
        }

        /// <summary>
        /// Adds storage filters to the top of the storage-filter stack.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that produced the filters.
        /// </param>
        /// <param name="pFilter">
        /// An array of <see cref="DXGI_INFO_QUEUE_FILTER"/> structures that describe the filters.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public HRESULT AddStorageFilterEntries([In] DXGI_DEBUG_ID Producer, [In] DXGI_INFO_QUEUE_FILTER[] pFilter)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (DXGI_INFO_QUEUE_FILTER* pFilterPtr = pFilter)
                {
                    return ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, DXGI_INFO_QUEUE_FILTER*, HRESULT>)_vTable[12])(thisPtr, Producer, pFilterPtr);
                }
            }
        }

        /// <summary>
        /// Gets the storage filter at the top of the storage-filter stack.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that gets the filter.
        /// </param>
        /// <param name="pFilter">
        /// A pointer to a <see cref="DXGI_INFO_QUEUE_FILTER"/> structure that describes the filter.
        /// </param>
        /// <param name="pFilterByteLength">
        /// A pointer to a variable that receives the size, in bytes,
        /// of the filter description to which <paramref name="pFilter"/> points.
        /// If <paramref name="pFilter"/> is <see cref="NullRef{DXGI_INFO_QUEUE_FILTER}"/>,
        /// <see cref="GetStorageFilter"/> outputs the size of the storage filter.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public HRESULT GetStorageFilter([In] DXGI_DEBUG_ID Producer, [In][Out] ref DXGI_INFO_QUEUE_FILTER pFilter, [In][Out] ref SIZE_T pFilterByteLength)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, ref DXGI_INFO_QUEUE_FILTER, ref SIZE_T, HRESULT>)_vTable[13])
                    (thisPtr, Producer, ref pFilter, ref pFilterByteLength);
            }
        }

        /// <summary>
        /// Removes a storage filter from the top of the storage-filter stack.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that removes the filter.
        /// </param>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public void ClearStorageFilter([In] DXGI_DEBUG_ID Producer)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, void>)_vTable[14])(thisPtr, Producer);
            }
        }

        /// <summary>
        /// Pushes an empty storage filter onto the storage-filter stack.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that pushes the empty storage filter.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// An empty storage filter allows all messages to pass through.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public HRESULT PushEmptyStorageFilter([In] DXGI_DEBUG_ID Producer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, HRESULT>)_vTable[15])(thisPtr, Producer);
            }
        }

        /// <summary>
        /// Pushes a deny-all storage filter onto the storage-filter stack.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that pushes the filter.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// A deny-all storage filter prevents all messages from passing through.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public HRESULT PushDenyAllStorageFilter([In] DXGI_DEBUG_ID Producer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, HRESULT>)_vTable[16])(thisPtr, Producer);
            }
        }

        /// <summary>
        /// Pushes a copy of the storage filter that is currently on the top of the storage-filter stack onto the storage-filter stack.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that pushes the copy of the storage filter.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public HRESULT PushCopyOfStorageFilter([In] DXGI_DEBUG_ID Producer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, HRESULT>)_vTable[17])(thisPtr, Producer);
            }
        }

        /// <summary>
        /// Pushes a storage filter onto the storage-filter stack.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that pushes the filter.
        /// </param>
        /// <param name="pFilter">
        /// A pointer to a <see cref="DXGI_INFO_QUEUE_FILTER"/> structure that describes the filter.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public HRESULT PushStorageFilter([In] DXGI_DEBUG_ID Producer, [In] in DXGI_INFO_QUEUE_FILTER pFilter)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, in DXGI_INFO_QUEUE_FILTER, HRESULT>)_vTable[18])(thisPtr, Producer, pFilter);
            }
        }

        /// <summary>
        /// Pops a storage filter from the top of the storage-filter stack.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that pops the filter.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public void PopStorageFilter([In] DXGI_DEBUG_ID Producer)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, void>)_vTable[19])(thisPtr, Producer);
            }
        }

        /// <summary>
        /// Gets the size of the storage-filter stack in bytes.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that gets the size.
        /// </param>
        /// <returns>
        /// Returns the size of the storage-filter stack in bytes.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public UINT GetStorageFilterStackSize([In] DXGI_DEBUG_ID Producer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, UINT>)_vTable[20])(thisPtr, Producer);
            }
        }

        /// <summary>
        /// Adds retrieval filters to the top of the retrieval-filter stack.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that produced the filters.
        /// </param>
        /// <param name="pFilter">
        /// An array of <see cref="DXGI_INFO_QUEUE_FILTER"/> structures that describe the filters.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public HRESULT AddRetrievalFilterEntries([In] DXGI_DEBUG_ID Producer, [In] DXGI_INFO_QUEUE_FILTER[] pFilter)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (DXGI_INFO_QUEUE_FILTER* pFilterPtr = pFilter)
                {
                    return ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, DXGI_INFO_QUEUE_FILTER*, HRESULT>)_vTable[21])(thisPtr, Producer, pFilterPtr);
                }
            }
        }

        /// <summary>
        /// Removes a retrieval filter from the top of the retrieval-filter stack.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that removes the filter.
        /// </param>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public void ClearRetrievalFilter([In] DXGI_DEBUG_ID Producer)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, void>)_vTable[22])(thisPtr, Producer);
            }
        }

        /// <summary>
        /// Pushes an empty retrieval filter onto the retrieval-filter stack.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that pushes the empty retrieval filter.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// An empty retrieval filter allows all messages to pass through.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public HRESULT PushEmptyRetrievalFilter([In] DXGI_DEBUG_ID Producer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, HRESULT>)_vTable[23])(thisPtr, Producer);
            }
        }

        /// <summary>
        /// Pushes a deny-all retrieval filter onto the retrieval-filter stack.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that pushes the deny-all retrieval filter.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// A deny-all retrieval filter prevents all messages from passing through.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public HRESULT PushDenyAllRetrievalFilter([In] DXGI_DEBUG_ID Producer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, HRESULT>)_vTable[24])(thisPtr, Producer);
            }
        }

        /// <summary>
        /// Pushes a copy of the retrieval filter that is currently on the top of the retrieval-filter stack onto the retrieval-filter stack.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that pushes the copy of the retrieval filter.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public HRESULT PushCopyOfRetrievalFilter([In] DXGI_DEBUG_ID Producer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, HRESULT>)_vTable[25])(thisPtr, Producer);
            }
        }

        /// <summary>
        /// Pushes a retrieval filter onto the retrieval-filter stack.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that pushes the filter.
        /// </param>
        /// <param name="pFilter">
        /// A pointer to a <see cref="DXGI_INFO_QUEUE_FILTER"/> structure that describes the filter.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public HRESULT PushRetrievalFilter([In] DXGI_DEBUG_ID Producer, [In] in DXGI_INFO_QUEUE_FILTER pFilter)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, in DXGI_INFO_QUEUE_FILTER, HRESULT>)_vTable[26])(thisPtr, Producer, pFilter);
            }
        }

        /// <summary>
        /// Pops a retrieval filter from the top of the retrieval-filter stack.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that pops the filter.
        /// </param>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public void PopRetrievalFilter([In] DXGI_DEBUG_ID Producer)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, void>)_vTable[27])(thisPtr, Producer);
            }
        }

        /// <summary>
        /// Gets the size of the retrieval-filter stack in bytes.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that gets the size.
        /// </param>
        /// <returns>
        /// Returns the size of the retrieval-filter stack in bytes.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public UINT GetRetrievalFilterStackSize([In] DXGI_DEBUG_ID Producer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, UINT>)_vTable[28])(thisPtr, Producer);
            }
        }

        /// <summary>
        /// Adds a debug message to the message queue and sends that message to the debug output.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that produced the message.
        /// </param>
        /// <param name="Category">
        /// A <see cref="DXGI_INFO_QUEUE_MESSAGE_CATEGORY"/>-typed value that specifies the category of the message.
        /// </param>
        /// <param name="Severity">
        /// A <see cref="DXGI_INFO_QUEUE_MESSAGE_SEVERITY"/>-typed value that specifies the severity of the message.
        /// </param>
        /// <param name="ID">
        /// An integer that uniquely identifies the message.
        /// </param>
        /// <param name="pDescription">
        /// The message string.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public HRESULT AddMessage([In] DXGI_DEBUG_ID Producer, [In] DXGI_INFO_QUEUE_MESSAGE_CATEGORY Category,
            [In] DXGI_INFO_QUEUE_MESSAGE_SEVERITY Severity, [In] DXGI_INFO_QUEUE_MESSAGE_ID ID, [In] LPCWSTR pDescription)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, DXGI_INFO_QUEUE_MESSAGE_CATEGORY,
                    DXGI_INFO_QUEUE_MESSAGE_SEVERITY, DXGI_INFO_QUEUE_MESSAGE_ID, IntPtr, HRESULT>)_vTable[29])
                    (thisPtr, Producer, Category, Severity, ID, pDescription.ToIntPtr());
            }
        }

        /// <summary>
        /// Adds a user-defined message to the message queue and sends that message to the debug output.
        /// </summary>
        /// <param name="Severity">
        /// A <see cref="DXGI_INFO_QUEUE_MESSAGE_SEVERITY"/>-typed value that specifies the severity of the message.
        /// </param>
        /// <param name="pDescription">
        /// The message string.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public HRESULT AddApplicationMessage([In] DXGI_INFO_QUEUE_MESSAGE_SEVERITY Severity, [In] LPCWSTR pDescription)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_INFO_QUEUE_MESSAGE_SEVERITY, IntPtr, HRESULT>)_vTable[30])
                    (thisPtr, Severity, pDescription.ToIntPtr());
            }
        }

        /// <summary>
        /// Sets a message category to break on when a message with that category passes through the storage filter.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that sets the breaking condition.
        /// </param>
        /// <param name="Category">
        /// A <see cref="DXGI_INFO_QUEUE_MESSAGE_CATEGORY"/>-typed value that specifies the category of the message.
        /// </param>
        /// <param name="bEnable">
        /// A Boolean value that specifies whether <see cref="SetBreakOnCategory"/> turns on or off this breaking condition
        /// (<see cref="TRUE"/> for on, <see cref="FALSE"/> for off).
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public HRESULT SetBreakOnCategory([In] DXGI_DEBUG_ID Producer, [In] DXGI_INFO_QUEUE_MESSAGE_CATEGORY Category, [In] BOOL bEnable)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, DXGI_INFO_QUEUE_MESSAGE_CATEGORY, BOOL, HRESULT>)_vTable[31])
                    (thisPtr, Producer, Category, bEnable);
            }
        }

        /// <summary>
        /// Sets a message severity level to break on when a message with that severity level passes through the storage filter.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that sets the breaking condition.
        /// </param>
        /// <param name="Severity">
        /// A <see cref="DXGI_INFO_QUEUE_MESSAGE_SEVERITY"/>-typed value that specifies the severity of the message.
        /// </param>
        /// <param name="bEnable">
        /// A Boolean value that specifies whether <see cref="SetBreakOnSeverity"/> turns on or off this breaking condition
        /// (<see cref="TRUE"/> for on, <see cref="FALSE"/> for off).
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public HRESULT SetBreakOnSeverity([In] DXGI_DEBUG_ID Producer, [In] DXGI_INFO_QUEUE_MESSAGE_SEVERITY Severity, [In] BOOL bEnable)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, DXGI_INFO_QUEUE_MESSAGE_SEVERITY, BOOL, HRESULT>)_vTable[32])
                    (thisPtr, Producer, Severity, bEnable);
            }
        }

        /// <summary>
        /// Sets a message identifier to break on when a message with that identifier passes through the storage filter.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that sets the breaking condition.
        /// </param>
        /// <param name="ID">
        /// An integer value that specifies the identifier of the message.
        /// </param>
        /// <param name="bEnable">
        /// A Boolean value that specifies whether <see cref="SetBreakOnID"/> turns on or off this breaking condition
        /// (<see cref="TRUE"/> for on, <see cref="FALSE"/> for off).
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public HRESULT SetBreakOnID([In] DXGI_DEBUG_ID Producer, [In] DXGI_INFO_QUEUE_MESSAGE_ID ID, [In] BOOL bEnable)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, DXGI_INFO_QUEUE_MESSAGE_ID, BOOL, HRESULT>)_vTable[33])(thisPtr, Producer, ID, bEnable);
            }
        }

        /// <summary>
        /// Determines whether the break on a message category is turned on or off.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that gets the breaking status.
        /// </param>
        /// <param name="Category">
        /// A <see cref="DXGI_INFO_QUEUE_MESSAGE_CATEGORY"/>-typed value that specifies the category of the message.
        /// </param>
        /// <returns>
        /// Returns a Boolean value that specifies whether this category of breaking condition is turned on or off
        /// (<see cref="TRUE"/> for on, <see cref="FALSE"/> for off).
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public BOOL GetBreakOnCategory([In] DXGI_DEBUG_ID Producer, [In] DXGI_INFO_QUEUE_MESSAGE_CATEGORY Category)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, DXGI_INFO_QUEUE_MESSAGE_CATEGORY, BOOL>)_vTable[34])(thisPtr, Producer, Category);
            }
        }

        /// <summary>
        /// Determines whether the break on a message severity level is turned on or off.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that gets the breaking status.
        /// </param>
        /// <param name="Severity">
        /// A <see cref="DXGI_INFO_QUEUE_MESSAGE_SEVERITY"/>-typed value that specifies the severity of the message.
        /// </param>
        /// <returns>
        /// Returns a Boolean value that specifies whether this severity of breaking condition is turned on or off
        /// (<see cref="TRUE"/> for on, <see cref="FALSE"/> for off).
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public BOOL GetBreakOnSeverity([In] DXGI_DEBUG_ID Producer, [In] DXGI_INFO_QUEUE_MESSAGE_SEVERITY Severity)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, DXGI_INFO_QUEUE_MESSAGE_SEVERITY, BOOL>)_vTable[35])(thisPtr, Producer, Severity);
            }
        }

        /// <summary>
        /// Determines whether the break on a message identifier is turned on or off.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that gets the breaking status.
        /// </param>
        /// <param name="ID">
        /// An integer value that specifies the identifier of the message.
        /// </param>
        /// <returns>
        /// Returns a Boolean value that specifies whether this break on a message identifier is turned on or off
        /// (<see cref="TRUE"/> for on, <see cref="FALSE"/> for off).
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public BOOL GetBreakOnID([In] DXGI_DEBUG_ID Producer, [In] DXGI_INFO_QUEUE_MESSAGE_ID ID)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, DXGI_INFO_QUEUE_MESSAGE_ID, BOOL>)_vTable[36])(thisPtr, Producer, ID);
            }
        }

        /// <summary>
        /// Turns the debug output on or off.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that gets the mute status.
        /// </param>
        /// <param name="bEnable">
        /// A Boolean value that specifies whether to turn the debug output on or off (<see cref="TRUE"/> for on, <see cref="FALSE"/> for off).
        /// </param>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public void SetMuteDebugOutput([In] DXGI_DEBUG_ID Producer, [In] BOOL bEnable)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, BOOL, void>)_vTable[37])(thisPtr, Producer, bEnable);
            }
        }

        /// <summary>
        /// Determines whether the debug output is turned on or off.
        /// </summary>
        /// <param name="Producer">
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that gets the mute status.
        /// </param>
        /// <returns>
        /// Returns a Boolean value that specifies whether the debug output is turned on or off
        /// (<see cref="TRUE"/> for on, <see cref="FALSE"/> for off).
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        public BOOL GetMuteDebugOutput([In] DXGI_DEBUG_ID Producer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_DEBUG_ID, BOOL>)_vTable[38])(thisPtr, Producer);
            }
        }
    }
}
