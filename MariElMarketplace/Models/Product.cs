using System.ComponentModel.DataAnnotations;

namespace MariElMarketplace.Models
{
    public class Product
    {

        [Key]
        public int Id { get; set; }

        public decimal Price { get; set; }

        public string Title { get; set; }

        public string ImageName { get; set; }

        public string Description { get; set; }

        public UnitEnum Unit { get; set; }

        public ProductTypeEnum ProductType { get; set; }

        public string SubType { get; set; }

        public double Count { get; set; }

        public double MinBuyCount { get; set; }

        public string FermerId { get; set; }

        public string PlaceName { get; set; }

        /// <summary>
        /// Срок хранения
        /// </summary>
        public string ShelfLife { get; set; }
        public string Application { get; internal set; }
    }
}
