using System.Collections.Generic;

namespace MariElMarketplace.Models.ViewModels
{
    public class DetailViewModel
    {

        public ProductWithCarryPrice ThisProduct { get; set; }

        public List<ProductWithCarryPrice> Suggestions { get; set; }

    }
}
