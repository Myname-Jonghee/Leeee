using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Battery.Models
{
    public class Enquiry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  // 기본 키

        [Required]
        public string Title { get; set; }  // 제목

        [Required]
        public string Contents { get; set; }  // 문의 내용

        [Required]
        public string Category { get; set; }  // 항목 (예: 제품, 주문/배송, 미디어)

        [Required]
        public string Name { get; set; }  // 이름

        [Required]
        public string Email { get; set; }  // 이메일
    }
}
