using System;

namespace Lsj.Util.Protobuf
{
    /// <summary>
    /// Field Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Protobuf.FieldAttribute"/> class
        /// </summary>
        /// <param name="FieldNumber"></param>
        /// <param name="FieldType"></param>
        public FieldAttribute(int FieldNumber, FieldType FieldType = FieldType.Varint)
        {
            if (FieldNumber < 1 || FieldNumber > 2047)
            {
                throw new ArgumentOutOfRangeException("FieldNumber Out Of Range");
            }
            this.FieldNumber = FieldNumber;
            this.FieldType = FieldType;
        }
        /// <summary>
        /// Field Number
        /// </summary>
        public int FieldNumber
        {
            get;
        }
        /// <summary>
        /// Field Type
        /// </summary>
        public FieldType FieldType
        {
            get;
        } = FieldType.Varint;

        /// <summary>
        /// IsRequired
        /// </summary>
        public bool IsRequired
        {
            get;
            set;
        }

    }
}
