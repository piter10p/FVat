using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.Models
{
    abstract class BasicEntity: IEntity, INameable
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(256), Index(IsUnique = true)]
        public string Name { get; set; }
    }
}
