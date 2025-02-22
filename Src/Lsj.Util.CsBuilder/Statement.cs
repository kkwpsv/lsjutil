namespace Lsj.Util.CsBuilder
{
    /// <summary>
    /// Statement
    /// </summary>
    public abstract class Statement
    {
        /// <inheritdoc/>
        public override string ToString() => ToString(0);

        /// <summary>
        /// ToString
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public abstract string ToString(int level);
    }
}
