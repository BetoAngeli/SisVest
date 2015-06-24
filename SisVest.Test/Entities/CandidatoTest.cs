using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisVest.Domain.Entities;

namespace SisVest.Test.Entities
{
    [TestClass]
    public class CandidatoTest
    {
        public Candidato candidato1, candidato2;

        [TestInitialize]
        public void InicializarTest()
        {
            candidato1 = new Candidato()
            {
                CandidatoId = 1,
                Email = "joao.effting@gmail.com",
                Cpf = "06625987921",
            };

        }

        [TestMethod]
        public void GarantirQue2CandidatosSaoIguaisQuandoTemMesmoId()
        {
            candidato2 = new Candidato()
            {
                CandidatoId = 1,
            };

            Assert.AreEqual(candidato1.CandidatoId, candidato2.CandidatoId);
            Assert.AreEqual(candidato1, candidato2);
        }

        [TestMethod]
        public void GarantirQue2CandidatosSaoIguaisQuandoTemMesmoCpf()
        {
            candidato2 = new Candidato()
            {
                Aprovado = true,
                Cpf = "06625987921",
            };

            Assert.AreEqual(candidato1.Cpf, candidato2.Cpf);
            Assert.AreEqual(candidato1, candidato2);
        }

        [TestMethod]
        public void GarantirQue2CandidatosSaoIguaisQuandoTemMesmoEmail()
        {
            candidato2 = new Candidato()
            {
                Email = "joao.effting@gmail.com",
            };

            Assert.AreEqual(candidato1.Email, candidato2.Email);
            Assert.AreEqual(candidato1, candidato2);
        }
    }
}
