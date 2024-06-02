using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.Domain
{
    public class License
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime DayOfBirth { get; set; }

        public string FullName { 
            get { return FirstName + " " + LastName; } 
        }

        [Required]
        public Club Club { get; set; }
        public int ClubId { get; set; }
    }
}
