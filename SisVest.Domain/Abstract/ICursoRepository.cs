using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisVest.Domain.Entities;

namespace SisVest.Domain.Abstract
{
    public interface ICursoRepository
    {
        IList<Curso> GetAll();

        IQueryable<Curso> Cursos { get; }

        Curso GetById(int id);

        void Add(Curso curso);

        void Update(Curso curso);

        void Delete(int id);

        void Aprovar(int id);
    }
}
