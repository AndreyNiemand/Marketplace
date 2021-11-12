using System.ComponentModel.DataAnnotations;

namespace MariElMarketplace.Models
{
    public class Distance
    {

        public Distance(string from, string to, int km)
        {
            From = from;
            To = to;
            Km = km;
        }

        [Key]
        public int Id { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public int Km { get; set; }

    }
}
