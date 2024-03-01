using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetanqueProSuite.Domain.Competition
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<League> Leagues { get; set; }
    }
}
