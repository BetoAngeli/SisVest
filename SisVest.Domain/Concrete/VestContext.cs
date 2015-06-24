using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisVest.Domain.Entities;

namespace SisVest.Domain.Concrete
{
    public class VestContext: DbContext
    {
        public DbSet<Admin> ADMIN { get; set; }
        public DbSet<Candidato> CANDIDATO { get; set; }
        public DbSet<Curso> CURSO { get; set; }
        public DbSet<Vestibular> VESTIBULAR { get; set; }
    }
}
