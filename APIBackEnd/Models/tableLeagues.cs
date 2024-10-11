using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIBackEnd.Models
{
    public class tableLeagues
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string team { get; set; }
        public int matchs { get; set; }
        public int win { get; set; }
        public int draw { get; set; }
        public int lose { get; set; }
        public int goal { get; set; }
        public int lost { get; set; }
        public string different { get; set; }
        public int score { get; set; }
    }
}
