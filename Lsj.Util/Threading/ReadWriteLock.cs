﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lsj.Util.Threading
{
    /// <summary>
    /// ReadWriteLock
    /// using ReaderWriterLockSlim
    /// </summary>
    public class ReadWriteLock
    {
        ReaderWriterLockSlim @lock = new ReaderWriterLockSlim();

        /// <summary>
        /// Enter Read
        /// use dispose to close
        /// </summary>
        /// <returns></returns>
        public ReadLockObject EnterRead() => new ReadLockObject(this);
        /// <summary>
        /// Enter UpgradeableRead
        /// use dispose to close
        /// </summary>
        /// <returns></returns>
        public UpgradeableReadLockObject EnterUpgradeableRead() => new UpgradeableReadLockObject(this);
        /// <summary>
        /// Enter Write
        /// use dispose to close
        /// </summary>
        /// <returns></returns>
        public WriteLockObject EnterWrite() => new WriteLockObject(this);


        /// <summary>
        /// ReadLock Object
        /// </summary>
        public class ReadLockObject : IDisposable
        {
            ReadWriteLock readWriteLock;
            internal ReadLockObject(ReadWriteLock readWriteLock)
            {
                this.readWriteLock = readWriteLock;
                readWriteLock.@lock.EnterReadLock();
            }

            /// <summary>
            /// Exit Lock
            /// </summary>
            public void Dispose()
            {
                readWriteLock.@lock.ExitReadLock();
            }
        }
        /// <summary>
        /// WriteLock Object
        /// </summary>
        public class WriteLockObject : IDisposable
        {
            ReadWriteLock readWriteLock;
            internal WriteLockObject(ReadWriteLock readWriteLock)
            {
                this.readWriteLock = readWriteLock;
                readWriteLock.@lock.EnterWriteLock();
            }

            /// <summary>
            /// Exit Lock
            /// </summary>
            public void Dispose()
            {
                readWriteLock.@lock.ExitWriteLock();
            }
        }
        /// <summary>
        /// UpgradeableReadLock Object
        /// </summary>
        public class UpgradeableReadLockObject : IDisposable
        {
            ReadWriteLock readWriteLock;
            bool hasUpgrade;
            internal UpgradeableReadLockObject(ReadWriteLock readWriteLock)
            {
                this.readWriteLock = readWriteLock;
                readWriteLock.@lock.EnterUpgradeableReadLock();
            }
            /// <summary>
            /// Upgrade Lock to WriteLock
            /// </summary>
            public void Upgrade()
            {
                readWriteLock.@lock.EnterWriteLock();
                hasUpgrade = true;
            }
            /// <summary>
            /// Exit Lock
            /// </summary>
            public void Dispose()
            {
                if (hasUpgrade)
                {
                    readWriteLock.@lock.ExitWriteLock();
                }
                readWriteLock.@lock.ExitUpgradeableReadLock();

            }
        }
    }
}
