using System.Collections.Generic;

namespace MariElMarketplace.Models.ViewModels
{
    public class CarrierLkViewModel
    {

        public Dictionary<ProductWithCarryPrice, Requests> MyProducts { get; set; }
        public Dictionary<ProductWithCarryPrice, Requests> OtherProducts { get; set; }

    }

}
