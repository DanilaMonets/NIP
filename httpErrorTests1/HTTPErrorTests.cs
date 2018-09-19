using HttpError;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void HTTPErrorTest()
        {
            var kek = DateTime.Now;
            HTTPError hTTPError = new HTTPError(404, kek);

            Assert.AreEqual(kek, hTTPError.Date);
            Assert.AreEqual(404, hTTPError.Code);
        }
    }

}