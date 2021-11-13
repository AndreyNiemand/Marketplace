using System.ComponentModel.DataAnnotations;

namespace MariElMarketplace.Models
{
    public class Requests
    {

        [Key]
        public int Id { get; set; }

        public Product Product { get; set; }

        public string UserId { get; set; }

        public string ToPlaceName { get; set; }

    }
}
