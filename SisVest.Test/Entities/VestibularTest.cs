using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisVest.Domain.Entities;

namespace SisVest.Test.Entities
{
    [TestClass]
    public class VestibularTest
    {
        public Vestibular vestibular1, vestibular2;

        [TestInitialize]
        public void InicializarTest()
        {
            vestibular1 = new Vestibular()
            {
                VestibularId = 1,
                Descricao = "2015/2"
            };

        }


        [TestMethod]
        public void GarantirQue2VestibularesSaoIguaisQuandoTemMesmoId()
        {
            vestibular2 = new Vestibular()
            {
                VestibularId = 1
            };

            Assert.AreEqual(vestibular1.VestibularId, vestibular2.VestibularId);
            Assert.AreEqual(vestibular1, vestibular2);
        }

        [TestMethod]
        public void GarantirQue2VestibularesSaoIguaisQuandoTemMesmaDescricao()
        {
            vestibular2 = new Vestibular()
            {
                Descricao = "2015/2"
            };

            Assert.AreEqual(vestibular1.Descricao, vestibular2.Descricao);
            Assert.AreEqual(vestibular1, vestibular2);
        }
    }
}
