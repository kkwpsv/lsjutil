using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Text
{
	/// <summary>
	/// 
	/// </summary>
	public unsafe sealed class VariableString : DisposableClass, IDisposable, ICloneable, IComparable, IComparable<VariableString>, IEnumerable<char>
	{

		internal class VariableStringEnumerator : IEnumerator<char>
		{
			VariableString str;
			int length;
			int current;
			internal VariableStringEnumerator(VariableString str)
			{
				this.str = str;
				this.length = str.Length;
				this.current = 0;
			}

			public char Current => str[current];

			object IEnumerator.Current => Current;

			public void Dispose()
			{

			}
			public bool MoveNext()
			{
				if (current < length)
				{
					current++;
					return true;
				}
				else
				{
					return false;
				}
			}
			public void Reset()
			{
				current = 0;
			}
		}



		char* handle;
		int bufferlength;
		int stringlength;

		/// <summary>
		/// 
		/// </summary>
		public VariableString()
		{
			this.stringlength = 0;
			this.bufferlength = 10;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="src"></param>
		public VariableString(VariableString src)
		{
			this.stringlength = src.stringlength;
			this.bufferlength = src.bufferlength;
			Alloc();
			UnsafeHelper.Copy(src.handle, this.handle, this.bufferlength);
		}
		/// <summary>
		/// 
		/// </summary>
		public VariableString(string value)
		{
			var chars = value.ToCharArray();
			this.stringlength = chars.Length;
			this.bufferlength = this.stringlength < 10 ? 10 : this.stringlength;
			Alloc();
			fixed (char* src = chars)
			{
				UnsafeHelper.Copy(src, handle, stringlength);
			}
		}


		private void Alloc()
		{
			this.handle = (char*)Marshal.AllocHGlobal(bufferlength).ToPointer();
		}
		/// <summary>
		/// 
		/// </summary>
		protected override void CleanUpUnmanagedResources()
		{
			Marshal.FreeHGlobal((IntPtr)handle);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			var chars = new char[this.stringlength];
			fixed (char* src = chars)
			{
				UnsafeHelper.Copy(handle, src, stringlength);
			}
			return new string(chars);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public object Clone() => new VariableString(this);

		/// <summary>
		/// 
		/// </summary>
		public int Length => stringlength;


		/// <summary>
		/// 
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		public char this[int i]
		{
			get
			{
				if (i >= stringlength)
				{
					throw new ArgumentOutOfRangeException();
				}
				else
				{
					return *(handle + i);
				}
			}
		}


		int IComparable.CompareTo(object obj)
		{
			if (obj is string)
			{
				using (var x = new VariableString(obj as string))
				{
					return CompareTo(x);
				}
			}
			else if (obj is VariableString)
			{
				return CompareTo(obj as VariableString);
			}
			else
			{
				throw new InvalidOperationException();
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public int CompareTo(VariableString other)
		{
			if (other == null)
			{
				return 1;
			}
			else if (this.Length > other.Length)
			{
				return 1;
			}
			else if (this.Length < other.Length)
			{
				return -1;
			}
			else
			{
				for (int i = 0; i < this.Length; i++)
				{
					if (*(this.handle + i) != *(other.handle + i))
					{
						return *(this.handle + i) - *(other.handle + i) > 0 ? 1 : -1;
					}
				}
				return 0;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public IEnumerator<char> GetEnumerator() => new VariableStringEnumerator(this);
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		/// <summary>
		/// 
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public bool Contains(char x) => IndexOf(x) >= 0;
		private int IndexOf(char x)
		{
			for (int i = 0; i < stringlength; i++)
			{
				if (x == *(handle + i))
				{
					return i;
				}
			}
			return -1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public bool Contains(VariableString x) => IndexOf(x) >= 0;
		private int IndexOf(VariableString x)
		{
			throw new NotImplementedException();
		}
	}
}
