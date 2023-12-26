namespace WebApplication_v._1._1.Models
{
    public partial class Сотрудники
    {
        [Key]
        public int id_s { set; get; }
        public string Familia { set; get; }
        public string Imya { set; get; }
        public string Otchestvo { set; get; }
        public DateTime dateB { get; set; }
        public string Strana { set; get; }
        public string Gorod { set; get; }
        public string Ulitsa { set; get; }
        public string dom { set; get; }
        public string Kvartira { set; get; }
        public string phone { set; get; }
        public string Role { set; get; }
        [Required(ErrorMessage = "Не указан Email")]
        public string Email { set; get; }
        [DataType(DataType.Password)]
        public string password { set; get; }
        public ICollection<ФилиалыСотрудники> ФилиалыСотрудникиs { get; set; }
        [ForeignKey("Филиалы")]
        public int id_f { get; set; }
        public Филиалы Филиалы { get; set; }
    }
}
