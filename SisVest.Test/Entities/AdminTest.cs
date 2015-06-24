using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisVest.Domain.Entities;

namespace SisVest.Test.Entities
{
    [TestClass]
    public class AdminTest
    {
        public Admin admin1, admin2;

        [TestInitialize]
        public void InicializarTest()
        {
            admin1 = new Admin()
            {
                AdminId = 1,
                Email = "joao.effting@gmail.com",
                Login = "joaoeffting",
            };

        }

        [TestMethod]
        public void GarantirQue2AdminSaoIguaisQuandoTemMesmoId()
        {
            admin2 = new Admin()
            {
                AdminId = 1
            };

            Assert.AreEqual(admin1.AdminId, admin2.AdminId);
            Assert.AreEqual(admin1,admin2);
        }

        [TestMethod]
        public void GarantirQue2AdminSaoIguaisQuandoTemMesmoLogin()
        {
            admin2 = new Admin()
            {
                Login = "joaoeffting"
            };

            Assert.AreEqual(admin1.Login, admin2.Login);
            Assert.AreEqual(admin1, admin2);
        }

        [TestMethod]
        public void GarantirQue2AdminSaoIguaisQuandoTemMesmoEmail()
        {
            admin2 = new Admin()
            {
                Email = "joao.effting@gmail.com"
            };

            Assert.AreEqual(admin1.Email, admin2.Email);
            Assert.AreEqual(admin1, admin2);
        }
    }
}
