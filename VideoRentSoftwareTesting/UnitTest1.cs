using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoRentSoftware;

namespace VideoRentSoftwareTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckConnection()
        {
            DataOperation operation = new DataOperation();
            Assert.AreEqual(operation.CheckConnectionState(), true);
        }

        [TestMethod]
        public void CheckPhoneValidation()
        {
            string invalid_phone = "ABCD123456";
            Assert.AreEqual(Validator.CheckPhone(invalid_phone), false);
                
        }
    }
}
