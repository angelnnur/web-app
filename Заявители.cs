namespace WebApplication_v._1._1.Models
{
    public partial class Заявители
    {
        [Key]
        public int id_z { set; get; }
        public string fio { set; get; }
        public DateTime dateB { get; set; }
        public string nationality { set; get; }
        public int passport_ser { set; get; }
        public int passport_num { set; get; }
        public string addres { set; get; }
        public string phone { set; get; }
        public string email { set; get; }
    }
}
