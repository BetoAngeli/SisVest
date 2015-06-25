using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisVest.Domain.Entities
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public string NomeTratamento { get; set; }

        [Required]
        public string Email { get; set; }
        
        public override bool Equals(object obj)
        {
            var adminParam = (Admin)obj;

            if (this.AdminId == adminParam.AdminId ||
                this.Login == adminParam.Login ||
                this.Email == adminParam.Email)
            {
                return true;
            }
            return false;
        }

    }
}
