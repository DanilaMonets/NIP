
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace httpError
{
    public class HTTPError : IComparable
    {
        private int code;
        private string description;
        private DateTime date;
        private static SortedList<int, string> listOfErrors;

        static HTTPError()
        {
            listOfErrors = new SortedList<int, string>();
            listOfErrors.Add(400, "Bad Request");
            listOfErrors.Add(401, "Unauthorized");
            listOfErrors.Add(403, "Forbidden");
        }
        public HTTPError()
        {
            this.code = 0;
            this.description = "ERROR";
            this.date = new DateTime();

        }
        public HTTPError(int code, DateTime date)
        {
            this.code = code;
            if (listOfErrors.TryGetValue(this.code, out this.description) == false)
            {
                this.description = "This error haven`t description yet.";
            }
            this.date = date;
        }

        public int Code
        {
            get
            {
                return code;
            }
          private  set
            {
                code = value;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
         private   set
            {
                description = value;
            }
        }
        public DateTime Date
        {
            get
            {
                return date;
            }
         private   set
            {
                date = value;
            }
        }


        public static string getDescriptionOf(int key){
            string str;
            if (listOfErrors.TryGetValue(key, out str) == false)
            {
                str = "This error haven`t description yet.";
            }
            return str;
        }

        public override bool Equals(object obj)
        {

            return code == (obj as HTTPError).Code && description.CompareTo((obj as HTTPError).description) == 0 ? true : false;
        }
        public int CompareTo(object obj)
        {
            if (!(obj is HTTPError)) // perevirka ce is
            {
                throw new Exception("об`єкт не є HTTPEror!");
            }
            int result = 0;
            if (this.Equals(obj))
            {
                result = 0;
            }
            else
            {
                if (code > (obj as HTTPError).code)
                {
                    result = -1;
                }
                else
                {
                    if (code < (obj as HTTPError).code)
                    {
                        result = 1;
                    }
                    else
                    {
                        if (!date.Equals((obj as HTTPError).date))
                        {
                            throw new Exception("exception with different throws!");
                        }



                        throw new Exception("Неоднозначний код помилки"); // два дескрипшини не спывпали
                    }

                }

            }
            return result;
        }
        public override string ToString()
        {
            return string.Format($"CODE: {this.code} DESCRIPTION: {this.description} DATE: {this.date}\n");
        }
        public void Read(string s)
        {
            // string s = sr.ReadLine();
            string[] arr = s.Split('|');
            int.TryParse(arr[0], out code);
            description = arr[1];
            string[] arrDate = arr[2].Split('.');

            date = new DateTime(int.Parse(arrDate[0]), int.Parse(arrDate[1]), int.Parse(arrDate[2]));

        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

    }
}
