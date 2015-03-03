using System;
using System.Collections.Generic;
using System.Text;

namespace IBS.Data.Csv
{
    [Flags]
    public enum ValueTrimmingOptions
    {
        None = 0,
        UnquotedOnly = 1,
        QuotedOnly = 2,
        All = UnquotedOnly | QuotedOnly
    }

    /// <summary>
    /// Specifies the action to take when a parsing error has occured.
    /// </summary>
    public enum ParseErrorAction
    {
        /// <summary>
        /// Raises the <see cref="M:CsvReader.ParseError"/> event.
        /// </summary>
        RaiseEvent = 0,

        /// <summary>
        /// Tries to advance to next line.
        /// </summary>
        AdvanceToNextLine = 1,

        /// <summary>
        /// Throws an exception.
        /// </summary>
        ThrowException = 2,
    }

    /// <summary>
    /// Specifies the action to take when a field is missing.
    /// </summary>
    public enum MissingFieldAction
    {
        /// <summary>
        /// Treat as a parsing error.
        /// </summary>
        ParseError = 0,

        /// <summary>
        /// Replaces by an empty value.
        /// </summary>
        ReplaceByEmpty = 1,

        /// <summary>
        /// Replaces by a null value (<see langword="null"/>).
        /// </summary>
        ReplaceByNull = 2,
    }

    /// <summary>
    /// Defines the data reader validations.
    /// </summary>
    [Flags]
    public enum DataReaderValidations
    {
        /// <summary>
        /// No validation.
        /// </summary>
        None = 0,

        /// <summary>
        /// Validate that the data reader is initialized.
        /// </summary>
        IsInitialized = 1,

        /// <summary>
        /// Validate that the data reader is not closed.
        /// </summary>
        IsNotClosed = 2
    }
}
