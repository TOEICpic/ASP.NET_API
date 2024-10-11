using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Org.BouncyCastle.Asn1.Cms;

namespace APIBackEnd.Models
{
    public class tableTime
    {
        public int id { get; set; }
        public string Ateam { get; set; }
        public string Hteam { get; set; }
        public DateTime times { get; set; }
    }
}
