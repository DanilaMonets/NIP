using Microsoft.VisualStudio.TestTools.UnitTesting;
using HttpError;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpError.Tests
{
    [TestClass()]
    public class HTTPErrorCollectionTests
    {
        [TestMethod()]
        public void ReadTextFromFile()
        {
            HTTPErrorsCollection httpErrorsCollection = new HTTPErrorsCollection();
            try
            {
                httpErrorsCollection.ReadTextFromFile("File1.txt");
            }
            catch (FileNotFoundException e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}