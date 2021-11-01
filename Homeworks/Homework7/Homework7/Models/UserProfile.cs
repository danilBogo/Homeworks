using System.ComponentModel.DataAnnotations;

namespace Homework7.Models
{
    public class UserProfile
    {
        [Required,MaxLength(20)]
        public string? FirstName { get; set; }
        
        [Required,MaxLength(20)]
        public string? SecondName { get; set; }
        
        [MaxLength(20)]
        public string? Patronymic { get; set; }
        
        [Display(Name = "Choose your sex")]
        [Required]
        public Sex Sex { get; set; }
        
        [Range(18, 200,ErrorMessage = "18+"),Required]
        public int Age { get; set; }
    }

    public enum Sex
    {
        Male = 0,
        Female = 1
    }
}