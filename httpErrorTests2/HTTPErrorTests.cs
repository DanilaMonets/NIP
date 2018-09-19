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

        [TestMethod()]
        public void HTTPErrorGetDescriptionOfTest()
        {
            Assert.AreEqual(HTTPError.GetDescriptionOf(400), "Bad Request");
            Assert.AreEqual(HTTPError.GetDescriptionOf(401), "Unauthorized");
            Assert.AreEqual(HTTPError.GetDescriptionOf(403), "Forbidden");
            Assert.AreEqual(HTTPError.GetDescriptionOf(402), "Payment Required");
            Assert.AreEqual(HTTPError.GetDescriptionOf(404), "Not Found");
        }

        [TestMethod()]
        public void HTTPErrorEqualsTest()
        {
            var d = DateTime.Now;
            HTTPError kek = new HTTPError(401, d);
            HTTPError lol = new HTTPError(401, d);

            HTTPError yo = new HTTPError(403, d);
            HTTPError ye = new HTTPError(403, d);

            HTTPError kekez = new HTTPError(404, d);
            HTTPError lolez = new HTTPError(404, d);
            if (kek.Equals(lol) && yo.Equals(ye) && kekez.Equals(lolez))
            {
                return;
            }
        }
    }
}