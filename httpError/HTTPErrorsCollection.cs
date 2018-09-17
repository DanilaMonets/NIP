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
    /// <summary>
    /// Represents classs for HTTPError collection
    /// </summary>
    class HTTPErrorsCollection
    {
        /// <summary>
        /// List of HTTP errors
        /// </summary>
        private List<HTTPError> httpErrors;
         
        /// <summary>
        /// Basic constructor
        /// </summary>
        public HTTPErrorsCollection()
        {
            httpErrors = new List<HTTPError>();
        }

        /// <summary>
        /// Gets variable httpErrors
        /// </summary>
        public List<HTTPError> HttpErrors
        {
            get
            {
                return this.httpErrors;
            }
        }

        /// <summary>
        /// Gets the <see cref="T:httpError.HTTPErrorsCollection"/> at the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public HTTPError this[int index]
        {
            get
            {
                return this.httpErrors[index];
            }
        }

        /// <summary>
        /// Adds new HTTP error to the list 
        /// </summary>
        /// <param name="error"></param>
        public void Add(HTTPError error)
        {
            if(!this.httpErrors.Contains(error))
            {
                this.httpErrors.Add(error);
            }
        }

        /// <summary>
        /// Removes  specified HTTP error from the list
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool Remove(HTTPError error)
        { 
            if(this.httpErrors.Contains(error))
            {
                return this.httpErrors.Remove(error);
            }
            return false;
        }
        /// <summary>
        /// Checks if list contains specified HTTP error
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool Contains(HTTPError error)
        {
            return this.httpErrors.Contains(error);
        }

        /// <summary>
        /// Removes specified HTTP error chosen by index
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.httpErrors.Count)
            {
                throw new ArgumentOutOfRangeException("index", $"Index must be in range [0 ; {this.httpErrors.Count - 1}].");
            }
            this.httpErrors.Remove(this.httpErrors[index]);
        }
        /// <summary>
        /// Clears list of HTTP errors
        /// </summary>
        public void Clear()
        {
            this.httpErrors.Clear();
        }
        /// <summary>
        /// Represents instance in string format
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string[] str = new string[this.httpErrors.Count];
            for (int i = 0; i < this.httpErrors.Count; i++)
            {
                str[i] = this.httpErrors[i].ToString();
            }
            return string.Join("\n", str);
        }

        /// <summary>
        /// Reads list of HTTP errors from file
        /// </summary>
        /// <param name="path"></param>
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
        /// <summary>
        /// Reads text from file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
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
