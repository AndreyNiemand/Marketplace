using System.Collections.Generic;

namespace MariElMarketplace.Models.ViewModels
{
    public class HomeViewModel
    {

        public List<Product> Products { get; set; }
        public Dictionary<string, Product> BestProductTypes { get; set; }

    }
}
