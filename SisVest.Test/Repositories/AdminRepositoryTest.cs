using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisVest.Domain.Abstract;
using SisVest.Domain.Concrete;
using SisVest.Domain.Entities;
using Moq;

namespace SisVest.Test.Repositories
{
    [TestClass]
    public class AdminRepositoryTest
    {
        private IAdminRepository _adminRepository;
        private VestContext _vestContext = new VestContext();
        private Admin _inserirAdm;


        [TestInitialize]
        public void InicializarTest()
        {
            _adminRepository = new EFAdminRepository(_vestContext);
            
            _inserirAdm = new Admin()
            {
                Email = "Joao.effting@gmail.com",
                Login = "joaoeffting",
                Senha = "123",
                NomeTratamento = "João Effting"
            };
        }

        [TestMethod]
        public void PodeConsultarLinqUsandoRepositoryTest()
        {
            //Ambiente
            _adminRepository.Add(_inserirAdm);
            //Ação
            var admins = _adminRepository.Admins;
            var retorno = admins.Where(w => w.Login.Equals(_inserirAdm.Login)).FirstOrDefault();

            //Assertivas
            Assert.IsInstanceOfType(admins,typeof(IQueryable<Admin>));
            Assert.AreEqual(retorno, _inserirAdm);
        }

        [TestMethod]
        public void PodeInserirTest()
        {
            //Ambiente
           
            //Ação
            _adminRepository.Add(_inserirAdm);

            var retorno = _adminRepository.Admins.Where(w => w.Login.Equals(_inserirAdm.Login)).FirstOrDefault();
            //Assertivas
            Assert.AreEqual(retorno, _inserirAdm);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NaoPodeInserirAdminComMesmoEmailTest()
        {
            //Ambiente
            var adminInserir2 = new Admin()
            {
                Email = _inserirAdm.Email
            };
            _adminRepository.Add(_inserirAdm);
            //Ação
            _adminRepository.Add(adminInserir2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NaoPodeInserirAdminComMesmoLoginTest()
        {
            //Ambiente
            var adminInserir2 = new Admin()
            {
                Login = _inserirAdm.Login
            };
            _adminRepository.Add(_inserirAdm);
            //Ação
            _adminRepository.Add(adminInserir2);

        }

        [TestMethod]
        public void PodeAlterarTest()
        {
            //Ambiente
            var nomeTratamentoEsperado = _inserirAdm.NomeTratamento;

            _adminRepository.Add(_inserirAdm);

            var adminAlterar = _adminRepository.Admins
                .Where(w => w.AdminId.Equals(_inserirAdm.AdminId)).FirstOrDefault();

            //Ação
            adminAlterar.NomeTratamento = "João Paulo Effting";

            _adminRepository.Update(adminAlterar);

            var retorno = _adminRepository.Admins.Where(w => w.AdminId.Equals(_inserirAdm.AdminId)).FirstOrDefault();
            //Assertivas
            Assert.AreEqual(retorno.AdminId, adminAlterar.AdminId);
            Assert.AreNotEqual(retorno.NomeTratamento, nomeTratamentoEsperado);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NaoPodeAlterarAdminComMesmoEmailTest()
        {
            //Ambiente
            _adminRepository.Add(_inserirAdm);

            var adminInserir2 = new Admin()
            {
                Email = "Joao.effting@gmail.com"
            };

            _adminRepository.Add(adminInserir2);

            var adminAlterar = _adminRepository.Admins
                .Where(w => w.AdminId.Equals(_inserirAdm.AdminId)).FirstOrDefault();
            //Ação

            adminAlterar.NomeTratamento = "admin@admin.com";

            _adminRepository.Update(adminAlterar);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NaoPodeAlterarAdminComMesmoLoginTest()
        {
            //Ambiente
            _adminRepository.Add(_inserirAdm);

            var adminInserir2 = new Admin()
            {
                Login = "joaoeffting"
            };

            _adminRepository.Add(adminInserir2);

            var adminAlterar = _adminRepository.Admins
                .Where(w => w.AdminId.Equals(_inserirAdm.AdminId)).FirstOrDefault();
            //Ação

            adminAlterar.NomeTratamento = "admin";

            _adminRepository.Update(adminAlterar);

        }

        [TestMethod]
        public void PodeExcluirTest()
        {
            //Ambiente
            _adminRepository.Add(_inserirAdm);
            //Ação
            _adminRepository.Delete(_inserirAdm.AdminId);

            //Assertivas
            var resultado = _adminRepository.Admins.Where(w => w.AdminId.Equals(_inserirAdm.AdminId));
            Assert.AreEqual(0, resultado.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NaoPodeExcluirCasoIdNaoExistaTest()
        {
            //Ação
            _adminRepository.Delete(9999);         
        }

        [TestMethod]
        public void PodeRecuperarPorIdTest()
        {
            //Ambiente
            _adminRepository.Add(_inserirAdm);
            //Ação
            var retorno = _adminRepository.GetById(_inserirAdm.AdminId);

            //Assertivas
            Assert.IsNotNull(retorno);
            Assert.IsInstanceOfType(retorno,typeof(Admin));
            Assert.AreEqual(_inserirAdm, retorno);
        }

        [TestMethod]
        public void PodeRecuperarTodos()
        {
            //Ambiente
            _adminRepository.Add(_inserirAdm);
            //Ação
            var retorno = _adminRepository.GetAll();

            //Assertivas
            Assert.AreEqual(1, retorno.ToList().Count());
        }

        [TestCleanup]
        public void LimparCenario()
        {
            var adminsParaRemover = _adminRepository.Admins;

            foreach (var admin in adminsParaRemover)
            {
                _vestContext.ADMIN.Remove(admin);
                
            }
            _vestContext.SaveChanges();
        }
    
    }
}
