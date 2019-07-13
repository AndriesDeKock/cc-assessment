namespace POLibrary.Logic
{
    using System;

    /// <summary>
    /// Defines the <see cref="StringValidator" />
    /// </summary>
    public class StringValidator
    {
        /// <summary>
        /// The Validate
        /// </summary>
        /// <param name="value">The value<see cref="object"/></param>
        /// <returns>The <see cref="string"/></returns>
        public virtual string Validate(object value)
        {

            return value.ToString();
        }
    }

    /// <summary>
    /// Defines the <see cref="ValidateReaderString" />
    /// </summary>
    public class ValidateReaderString : StringValidator
    {
        /// <summary>
        /// The Validate
        /// </summary>
        /// <param name="value">The value<see cref="object"/></param>
        /// <returns>The <see cref="string"/></returns>
        public override string Validate(object value)
        {
            return base.Validate((value == DBNull.Value) ? string.Empty : value.ToString());
        }
    }
}
