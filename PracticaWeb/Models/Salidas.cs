namespace PracticaWeb.Models
{
    public class Salidas
    {
        public int idServicio { get; set; }
        public int NoPlaca { get; set; }
        
        public DateTime? FehaEntrada { get; set; }
        public string? HoraEntrada { get; set; }
    }
}
