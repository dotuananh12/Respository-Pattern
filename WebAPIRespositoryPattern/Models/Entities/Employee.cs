using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }

        public int? phone { get; set; }

        public DateTime? dateofbirth { get; set; }
    }
}