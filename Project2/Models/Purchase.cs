using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project_Battery.Models
{
    public class Purchase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //주문자 정보
        [Required]
        [MaxLength(20)]
        public string Name { get; set; } //주문자명

        [Required]
        public int PhoneNumber { get; set; } //휴대폰번호

        [Required]
        [MaxLength(50)]
        public string Email { get; set; } //이메일

        //배송지 정보
        [Required]
        [MaxLength(150)]
        public string Address { get; set; } //주소

        //결제 정보
        [Required]
        public int CardNumber { get; set; } //카드번호

        [Required]
        [MaxLength(10)]
        public string ExpirationDate { get; set; } //유효기간
        [Required]
        public int CVC { get; set; } //CVC번호, 3자리로 설정


    }
}
