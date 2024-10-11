using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIBackEnd.Models
{
    public class tableMatch
    {
        public int id { get; set; }
        public string Ateam { get; set; }
        public string Hteam { get; set; }
        public int Ascore { get; set; }
        public int Hscore { get; set; }
    }
}
