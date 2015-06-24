using SisVest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisVest.Domain.Abstract
{
    public interface ICandidatoRepository
    {
        IList<Candidato> GetAll { get; }

        IQueryable<Candidato> Candidatos { get; }

        IList<Candidato> RetornarPorVestibularPorCurso(int vestibularId, int cursoId);

        Candidato GetById(int id);

        void Add(Candidato candidato);

        void Update(Candidato candidato);

        void Delete(int id);

        void Aprovar(int id);
    }
}
