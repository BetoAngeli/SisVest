using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisVest.Domain.Entities;

namespace SisVest.Test.Entities
{
    [TestClass]
    public class CursoTest
    {
        public Curso curso1, curso2;

        [TestInitialize]
        public void InicializarTest()
        {
            curso1 = new Curso()
            {
                CursoId = 1,
                Descricao = "Computação"
            };

        }

        [TestMethod]
        public void GarantirQue2CursosSaoIguaisQuandoTemMesmoId()
        {
            curso2 = new Curso()
            {
                CursoId = 1
            };

            Assert.AreEqual(curso1.CursoId, curso2.CursoId);
            Assert.AreEqual(curso1, curso2);
        }

        [TestMethod]
        public void GarantirQue2CursosSaoIguaisQuandoTemMesmaDescricao()
        {
            curso2 = new Curso()
            {
                Descricao = "Computação"
            };

            Assert.AreEqual(curso1.Descricao, curso2.Descricao);
            Assert.AreEqual(curso1, curso2);
        }
    }
}
