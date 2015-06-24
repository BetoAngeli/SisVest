using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisVest.Domain.Entities
{
    public class Candidato
    {
        [Key]
        public int CandidatoId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Senha { get; set; }
        public string Sexo { get; set; }
        public string Cpf { get; set; }
        public virtual Vestibular Vestibular { get; set; }
        public virtual Curso Curso { get; set; }
        public bool Aprovado { get; set; }

        public override bool Equals(object obj)
        {
            var candidatoParam = (Candidato) obj;

            if (this.CandidatoId == candidatoParam.CandidatoId ||
                this.Cpf == candidatoParam.Cpf ||
                this.Email == candidatoParam.Email)
            {
                return true;
            }
            return false;
        }
    }
}
