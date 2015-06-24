using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisVest.Domain.Abstract;
using SisVest.Domain.Entities;

namespace SisVest.Domain.Concrete
{
    public class EFAdminRepository : IAdminRepository
    {
        private VestContext _vestContext ;

        public EFAdminRepository(VestContext context)
        {
            _vestContext = context;
        }

        public IList<Admin> GetAll()
        {
            return _vestContext.ADMIN.ToList();
        }

        public IQueryable<Admin> Admins
        {
            get { return _vestContext.ADMIN.AsQueryable(); }
        }

        public Admin GetById(int id)
        {
            return _vestContext.ADMIN.Find(id);
        }

        public void Add(Admin admin)
        {
            var validacao = this.Admins.Where(w => w.Login.ToUpper().Equals(admin.Login.ToUpper()) || 
                                                   w.Email.ToUpper().Equals(admin.Email.ToUpper()));
            if (validacao.Any())
            {
                throw  new InvalidOperationException("Administrador já cadastrado com esse login ou e-mail");
            }
            _vestContext.ADMIN.Add(admin);
            _vestContext.SaveChanges();
        }

        public void Update(Admin admin)
        {
            var validaca = this.Admins.Where(w => w.AdminId != admin.AdminId && 
                                                  (w.Login.ToUpper().Equals(admin.Login.ToUpper()) ||
                                                   w.Email.ToUpper().Equals(admin.Email.ToUpper())));

            if (validaca.Any())
            {
                throw new InvalidOperationException("Administrador já cadastrado com esse login ou e-mail");
            }

            _vestContext.Entry(admin).State = EntityState.Modified;
            _vestContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var admin = _vestContext.ADMIN.Where(w => w.AdminId.Equals(id));
            
            if (admin.Count() == 0)
            {
                throw new InvalidOperationException("Administrador não cadastrado");
            }
            _vestContext.ADMIN.Remove(admin.FirstOrDefault());
            _vestContext.SaveChanges();
        }

        public void Aprovar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
