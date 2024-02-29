using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetanqueProSuite.Domain.Competition
{
    public class League
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [JsonIgnore]
        public Category Category { get; set; }

        public int? CategoryId { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        public ICollection<Division> Divisions { get; set; }
    }
}
