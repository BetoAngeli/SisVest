using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisVest.Domain.Abstract;
using SisVest.Domain.Entities;

namespace SisVest.Domain.Concrete
{
    public class EFVestibularRepository: IVestibularRepository
    {
        private VestContext _vestContext ;

        public EFVestibularRepository(VestContext context)
        {
            _vestContext = context;
        }

        public IList<Entities.Vestibular> GetAll()
        {
            return _vestContext.VESTIBULAR.ToList();
        }

        public IList<Entities.Candidato> GetCandidatoByVestibular(int idVestibular)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Vestibular> Vestibulares
        {
            get { return _vestContext.VESTIBULAR.AsQueryable(); }
        }

        public Entities.Vestibular GetById(int id)
        {
            return _vestContext.VESTIBULAR.Find(id);
        }

        public void Add(Entities.Vestibular vestibular)
        {
            var validacao = this.Vestibulares.Where(w => w.Descricao.ToUpper().Equals(vestibular.Descricao.ToUpper()));
            if (validacao.Any())
            {
                throw new InvalidOperationException("Vestibular já cadastrado com essa descrição");
            }
            try
            {
                _vestContext.VESTIBULAR.Add(vestibular);
            }
            catch (DbEntityValidationException ex)
            {

                var erros = _vestContext.GetValidationErrors();
            }
            
            _vestContext.SaveChanges();
        }

        public void Update(Entities.Vestibular vestibular)
        {
            var validacao = this.Vestibulares.Where(w => w.VestibularId != vestibular.VestibularId &&
                                        w.Descricao.ToUpper().Equals(vestibular.Descricao.ToUpper()));
            if (validacao.Any())
            {
                throw new InvalidOperationException("Vestibular já cadastrado com essa descrição");
            }

            _vestContext.Entry(vestibular).State = EntityState.Modified;
            _vestContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var vestibular = _vestContext.VESTIBULAR.Where(w => w.VestibularId.Equals(id));

            if (vestibular.Count() == 0)
            {
               throw new InvalidOperationException("Vestibular não cadastrado");
            }

            _vestContext.VESTIBULAR.Remove(vestibular.FirstOrDefault());
            _vestContext.SaveChanges();
        }

        public void Aprovar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
