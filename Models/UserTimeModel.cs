using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RaceTimesApplication.Models
{
    public class UserTimeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "decimal(16,2)")]
        public decimal Time { get; set; }


        public DateTime CreationTime { get; set; }

        public bool IsApproved { get; set; }
    }
}
