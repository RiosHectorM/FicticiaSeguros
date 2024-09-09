using System.ComponentModel.DataAnnotations;

namespace FicticiaSeguros.Models
{
    public class Person
    {
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "No debe exceder los 100 caracteres")]
        public string Name { get; set; } = null!;

        [Range(1, 99999999, ErrorMessage = "El número de identificación debe estar entre 1 y 99999999")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El número de identificación debe contener solo dígitos")]
        public long Dni { get; set; }

        public Gender Gender { get; set; }

        public bool IsActive { get; set; }
        public bool IsDriver { get; set; }
        public bool UsesGlasses { get; set; }
        public bool IsDiabetic { get; set; }

        [MaxLength(500, ErrorMessage = "No debe exceder los 500 caracteres")]
        public string? OtherDiseases { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}