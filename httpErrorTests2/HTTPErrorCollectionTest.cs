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
                return;
            }
            Assert.Fail("No exception was thrown.");
        }
        [TestMethod()]
        public void ReadLogOfErrorsFromFileTest()
        {
            HTTPErrorsCollection httpErrorsCollection = new HTTPErrorsCollection();
            try
            {
                httpErrorsCollection.ReadLogOfErrorsFromFile("File54.txt");
            }
            catch (FileNotFoundException e)
            {
                Assert.AreEqual(e.Message, "There is no such file.");
                return;
            }
            Assert.Fail("No exception was thrown.");
        }
        [TestMethod()]
        public void HttpErrorsGetter()
        {
           var one = new HTTPError(402,DateTime.Now);
           var two = new HTTPError(403,DateTime.Now);
           var three = new HTTPError(404,DateTime.Now);
            
           var collection = new HTTPErrorsCollection();
           collection.Add(one);
           collection.Add(two);
           collection.Add(three);
            
           Assert.IsTrue(collection.HttpErrors.Count>0);
           Assert.IsTrue(collection[0].Code==402);
           
        }
    }
}