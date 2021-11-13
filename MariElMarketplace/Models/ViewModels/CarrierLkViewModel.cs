using System.Collections.Generic;

namespace MariElMarketplace.Models.ViewModels
{
    public class CarrierLkViewModel
    {

        public Dictionary<Product, Requests> MyProducts { get; set; }
        public Dictionary<Product, Requests> OtherProducts { get; set; }

    }

}
