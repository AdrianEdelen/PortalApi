using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalApi.Models
{
    public class Invitiation
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        [NotMapped]
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        [Display(Name = "Avatar")]
        public string FilePath { get; set; }

        public string FileName { get; set; }

        public byte[] FileData { get; set; }

        [NotMapped]
        public IFormFile FormFile { get; set; }
        public int HouseholdId { get; set; }
    }
}
