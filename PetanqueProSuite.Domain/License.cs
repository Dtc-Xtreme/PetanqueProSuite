using PetanqueProSuite.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace PetanqueProSuite.Domain
{
    public class License
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1,99999)]
        public int Number { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime DayOfBirth { get; set; }

        [Required]
        public Club Club { get; set; }
        public int ClubId { get; set; }

        [Required]
        public DateTime ValidDate { get; set; }

        [Required]
        public Sex Sex { get; set; }

        public byte[] Image { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}