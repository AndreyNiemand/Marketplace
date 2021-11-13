namespace MariElMarketplace.Models
{
    public class ProductWithCarryPrice : Product
    {

        /// <summary>
        /// Сумма доставки
        /// </summary>
        public decimal CarryPrice { get; set; }

    }
}
