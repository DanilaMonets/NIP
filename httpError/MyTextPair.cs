using System;

namespace httpError
{
    public struct MyTextPair
    {
        private string oldText;
        private string newText;

        public MyTextPair(string oldText, string newText)
        {
            this.oldText = oldText;
            this.newText = newText;
        }

        public string OldText
        {
            get
            {
                return this.oldText;
            }
        }

        public string NewText
        {
            get
            {
                return this.newText;
            }
        }
    }
}