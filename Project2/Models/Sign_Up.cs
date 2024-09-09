using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Battery.Models
{
    public class Sign_Up
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string UserName {  get; set; }
        [Required]
        public string Password { get; set; }
        [NotMapped]
        public string ConfirmPassword { get; set; }


    }
}
