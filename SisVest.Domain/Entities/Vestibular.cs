using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SisVest.Domain.Entities
{
    public class Vestibular
    {
        [Key]
        public int VestibularId { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public DateTime DataInicioInscricao { get; set; }

        [Required]
        public DateTime DataFimInscricao { get; set; }

        [Required]
        public DateTime DataProva { get; set; }
        public virtual ICollection<Candidato> Candidatos { get; set; }


        public override bool Equals(object obj)
        {
            var vestibularParam = (Vestibular)obj;

            if (this.VestibularId == vestibularParam.VestibularId ||
                this.Descricao == vestibularParam.Descricao)
            {
                return true;
            }
            return false;
        }
    }
}
