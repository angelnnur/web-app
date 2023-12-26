namespace WebApplication_v._1._1.Models
{
    public partial class Филиалы
    {
        [Key]
        public int id_f { get; set; }
        public string names { get; set; }
        public string addres { get; set; }

        public ICollection<ФилиалыСотрудники> ФилиалыСотрудникиs { get; set; }
    }
}
