using System;

namespace httpError
{
    /// <summary>
    /// Represent a pair of two string values.
    /// </summary>
    public struct MyTextPair
    {
        private string oldText;
        private string newText;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:httpError.MyTextPair"/> struct.
        /// </summary>
        /// <param name="oldText">Old text.</param>
        /// <param name="newText">New text.</param>
        public MyTextPair(string oldText, string newText)
        {
            this.oldText = oldText;
            this.newText = newText;
        }

        /// <summary>
        /// Gets the old text.
        /// </summary>
        /// <value>The old text.</value>
        public string OldText
        {
            get
            {
                return this.oldText;
            }
        }

        /// <summary>
        /// Gets the new text.
        /// </summary>
        /// <value>The new text.</value>
        public string NewText
        {
            get
            {
                return this.newText;
            }
        }
    }
}