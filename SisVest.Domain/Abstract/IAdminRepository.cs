using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisVest.Domain.Entities;

namespace SisVest.Domain.Abstract
{
    public interface IAdminRepository
    {
        IList<Admin> GetAll();

        IQueryable<Admin> Admins { get; }

        Admin GetById(int id);

        void Add(Admin admin);

        void Update(Admin admin);

        void Delete(int id);

        void Aprovar(int id);
    }
}
