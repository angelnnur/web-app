namespace WebApplication_v._1._1.Models
{
    public partial class Принятые_заявления
    {
        
        [Key]
        public int id_pz { set; get; }
        public String num_zayav { set; get; }
        public DateTime date_start { set; get; }
        [ForeignKey("Заявители")]
        public int id_z { get; set; }
        [ForeignKey("Сотрудники")]
        public int id_s { get; set; }
        [ForeignKey("Филиалы")]
        public int id_f { get; set; }
        public bool obrabotka { get; set; }
        public virtual Заявители Заявители { get; set; }
        public virtual Сотрудники Сотрудники { get; set; }
        public virtual Филиалы Филиалы { get; set; }
    }
}
