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
    }
}
