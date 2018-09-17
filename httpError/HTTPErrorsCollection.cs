using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
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

        public void ReadLogOfErrorsFromFile(string path)
        {
            using (var streamReader = new StreamReader(path))
            {
                char[] separators = {' ', '#' };
                while (!streamReader.EndOfStream)
                {
                    var str = streamReader.ReadLine();
                    var strs = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    var date = strs[1];
                    var time = strs[2];
                    var code = strs[0];
                    this.httpErrors.Add(new HTTPError(int.Parse(code), DateTime.Parse($"{date} {time}")));

                }
            }
        }

        public MyTextPair ReadTextFromFile(string path)
        {
            using (var streamReader = new StreamReader(path))
            {
                var str = streamReader.ReadToEnd();
                char[] separators = {' ', '-', '.', '(', ')', ',', ':', '\n', '\t', '?', '!', ';'};
                this.httpErrors = (from t in str.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                    where t.StartsWith("#")
                    select new HTTPError(int.Parse(t.Substring(1)), DateTime.Now)).ToList<HTTPError>();
                var newStr = new StringBuilder(str);
                foreach (var httpError in httpErrors)
                {
                    newStr.Replace(httpError.Code.ToString(),
                        $"['{HTTPError.getDescriptionOf(httpError.Code)}', {httpError.Date.ToString(CultureInfo.CurrentCulture)}]");
                }
                return new MyTextPair(str,newStr.ToString());     
            }
           
        }
    }
}
