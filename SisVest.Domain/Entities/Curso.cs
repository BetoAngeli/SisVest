using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;

namespace SisVest.Domain.Entities
{
    public class Curso
    {
        [Key]
        public int CursoId { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public int Vagas { get; set; }
        public virtual ICollection<Candidato> Candidatos  { get; set; }

        public override bool Equals(object obj)
        {
            var cursoParam = (Curso)obj;

            if (this.CursoId == cursoParam.CursoId ||
                this.Descricao == cursoParam.Descricao)
            {
                return true;
            }
            return false;
        }
    }
}
