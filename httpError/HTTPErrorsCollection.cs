using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace httpError
{
    class HTTPErrorsCollection
    {
        private List<HTTPError> httpErrors;
         
        public HTTPErrorsCollection()
        {
            httpErrors = new List<HTTPError>();
        }

        public List<HTTPError> HttpErrors
        {
            get
            {
                return this.httpErrors;
            }
        }

        public HTTPError this[int index]
        {
            get
            {
                return this.httpErrors[index];
            }
        }

        public void Add(HTTPError error)
        {
            if(!this.httpErrors.Contains(error))
            {
                this.httpErrors.Add(error);
            }
        }

        public bool Remove(HTTPError error)
        { 
            if(this.httpErrors.Contains(error))
            {
                return this.httpErrors.Remove(error);
            }
            return false;
        }

        public bool Contains(HTTPError error)
        {
            return this.httpErrors.Contains(error);
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.httpErrors.Count)
            {
                throw new ArgumentOutOfRangeException("index", $"Index must be in range [0 ; {this.httpErrors.Count - 1}].");
            }
            this.httpErrors.Remove(this.httpErrors[index]);
        }

        public void Clear()
        {
            this.httpErrors.Clear();
        }

        public override string ToString()
        {
            string[] str = new string[this.httpErrors.Count];
            for (int i = 0; i < this.httpErrors.Count; i++)
            {
                str[i] = this.httpErrors[i].ToString();
            }
            return string.Join("\n", str);
        }
    }
}
