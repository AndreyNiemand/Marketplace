using System.Collections.Generic;

namespace MariElMarketplace.Models
{
    public class ProductWithCarryPrice : Product
    {


        /// <summary>
        /// Маршрут
        /// </summary>
        public List<Distance> Route { get; set; }

        /// <summary>
        /// Сумма доставки
        /// </summary>
        public decimal CarryPrice { get; set; }

    }
}
