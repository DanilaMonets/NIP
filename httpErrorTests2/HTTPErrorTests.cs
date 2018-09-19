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
        public void HTTPErrorCodeTest()
        {
            var d = DateTime.Now;
            HTTPError kek = new HTTPError(404, d);

            Assert.AreEqual(404, kek.Code);
        }
        [TestMethod()]
        public void HTTPErrorDateTest()
        {
            var d = DateTime.Now;
            HTTPError kek = new HTTPError(404, d);

            Assert.AreEqual(d, kek.Date);
        }

        [TestMethod()]
        public void HTTPErrorDescriptionTest()
        {
            HTTPError kek = new HTTPError();
            Assert.AreEqual(kek.Description, "ERROR");

            HTTPError lol = new HTTPError(404, DateTime.Now);
            Assert.AreEqual(lol.Description, "Not Found");
        }
    }
}