using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisVest.Domain.Entities;

namespace SisVest.Domain.Abstract
{
    public interface IVestibularRepository
    {
        IList<Vestibular> GetAll();

        IList<Candidato> GetCandidatoByVestibular(int idVestibular);
        
        IQueryable<Vestibular> Vestibulares { get; }

        Vestibular GetById(int id);

        void Add(Vestibular vestibular);

        void Update(Vestibular vestibular);

        void Delete(int id);

        void Aprovar(int id);
    }
}
