using Microsoft.VisualStudio.TestTools.UnitTesting;
using HttpError;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpError.Tests
{
    [TestClass()]
    public class HTTPErrorTests
    {
        [TestMethod()]
        public void HTTPErrorTestCode()
        {
            var d = DateTime.Now;
            HTTPError kek = new HTTPError(404, d);

            Assert.AreEqual(404, kek.Code);
        }
        [TestMethod()]
        public void HTTPErrorTestDate()
        {
            var d = DateTime.Now;
            HTTPError kek = new HTTPError(404, d);

            Assert.AreEqual(d, kek.Date);
        }

        //[TestMethod()]
        //public void HTTPErrorTest
    }
}