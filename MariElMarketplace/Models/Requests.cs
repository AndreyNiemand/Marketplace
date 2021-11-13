using System.ComponentModel.DataAnnotations;

namespace MariElMarketplace.Models
{
    public class Requests
    {

        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string UserId { get; set; }

        public string ToPlaceName { get; set; }

        public bool IsActive { get; set; } = false;

        public string CarrierId { get; set; }

    }
}
