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
        public void HttpErrorsGetterTest()
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
        [TestMethod()]
        public void HttpErrorsRemoveTest()
        {
           var one = new HTTPError(402,DateTime.Now);
           var two = new HTTPError(403,DateTime.Now);
           var three = new HTTPError(404,DateTime.Now);
            
           var collection = new HTTPErrorsCollection();
           collection.Add(one);
           collection.Add(two);
           collection.Add(three);
           collection.Remove(one);
           Assert.IsTrue(collection.HttpErrors.Count==2);
           collection.RemoveAt(1);
           Assert.IsTrue(collection[0].Code==403);
          
        }
        [TestMethod()]
        public void HttpErrorCollectionClearTest()
        {
           var one = new HTTPError(402,DateTime.Now);
           var two = new HTTPError(403,DateTime.Now);
           var three = new HTTPError(404,DateTime.Now);
            
           var collection = new HTTPErrorsCollection();
            collection.Add(one);
            collection.Add(two);
            collection.Add(three);
           collection.Clear();
           Assert.IsTrue(collection.HttpErrors.Count==0);
        }
        [TestMethod()]
        public void HttpErrorCollectionContainsTest()
        {
           var one = new HTTPError(402,DateTime.Now);
           
           var collection = new HTTPErrorsCollection();
           collection.Add(one);
           Assert.IsTrue(collection.HttpErrors.Contains(one));
        }
    }
}