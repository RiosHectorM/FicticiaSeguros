namespace FicticiaSeguros.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string UserMail { get; set; } = null!;
        public string UserPass { get; set; } = null!;

    }
}
