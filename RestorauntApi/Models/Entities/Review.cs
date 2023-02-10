using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace RestorauntApi.Models.Entities
{
    public class Review
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "Поле не может быть пустым")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Поле не может быть пустым")]
        public string Surname { get; set; }

        [EmailAddress (ErrorMessage = "Некорректый адрес")]
        [Required (ErrorMessage = "Поле не может быть пустым")]
        public string Email { get; set; }

        [Phone (ErrorMessage = "Некорретный номер телефона")]
        [Required (ErrorMessage = "Поле не может быть пустым")]
        public string Phone { get; set; }

        [Required (ErrorMessage = "Поле не может быть пустым")]
        public DateOnly DateOfVisit { get; set; }

        [Range(1, 500, ErrorMessage = "Недопустимое число гостей")]
        public int? NumberOfGuests { get; set; }

        [Range(1, 1000, ErrorMessage = "Недопустимый номер стола")]
        public int? TableNumber { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public string Message { get; set; }
        [Required]
        public bool IsAccepted { get; set; }
        public int? AdminId { get; set; }
        public virtual Admin? Admin { get; set; }
    }
}
