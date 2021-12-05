#if NET40
namespace System
{
    /// <summary>
    /// A poor Span implementation just for .net 4.0 compatible.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct Span<T>
    {
        private T[] _buffer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ref T this[int index] => ref _buffer[index];

        /// <summary>
        /// 
        /// </summary>
        public int Length => _buffer.Length;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        public Span(T[] array)
        {
            _buffer = array;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Span(T[] array, int start, int length)
        {
            if (start < 0 || length < 0 || start + length > array.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            _buffer = new T[length];

            Array.Copy(array, start, _buffer, 0, length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Span<T> Slice(int start)
        {
            if (start < 0 || start > Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            return Slice(start, Length - start);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Span<T> Slice(int start, int length)
        {
            if (start < 0 || length < 0 || start + length > Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            return new Span<T>(_buffer, start, length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T[] ToArray()
        {
            var result = new T[_buffer.Length];
            Array.Copy(_buffer, result, _buffer.Length);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ref T GetPinnableReference() => ref this[0];
    }

    /// <summary>
    /// 
    /// </summary>
    public static class MemoryExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static Span<T> AsSpan<T>(this T[] array, int start, int length) => new Span<T>(array, start, length);
    }
}
#endif