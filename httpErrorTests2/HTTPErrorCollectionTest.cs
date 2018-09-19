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
        public void ReadTextFromFileTest()
        {
            HTTPErrorsCollection httpErrorsCollection = new HTTPErrorsCollection();
            try
            {
                httpErrorsCollection.ReadTextFromFile("File54.txt");
            }
            catch (FileNotFoundException e)
            {
                Assert.AreEqual(e.Message, "There is no such file.");
            }
            Assert.Fail("No exception was thrown.");
        }
    }
}