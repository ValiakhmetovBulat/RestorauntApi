using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestorauntApi.Models.Entities
{
    public class MenuPosition
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        public string? Decription { get; set; }
        public string? Photo { get; set; }
        public int SectionId { get; set; }
        public virtual Section? Section { get; set; }
        public int PositionTypeId { get; set; }
        public virtual PositionType? PositionType { get; set; }
    }
}
