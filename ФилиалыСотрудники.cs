namespace WebApplication_v._1._1.Models
{
    public class ФилиалыСотрудники
    {
        public int id_s { get;  set; }
        public Сотрудники Сотрудники { get; set; }
        public int id_f { get;  set; }
        public Филиалы Филиалы { get; set; }
    }
}
