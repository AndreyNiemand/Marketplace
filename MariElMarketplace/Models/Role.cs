using System.ComponentModel;

namespace MariElMarketplace.Models
{
    public enum Role
    {
        
        /// <summary>
        /// Покупатель
        /// </summary>
        [Description("Покупатель")]
        Customer,
        /// <summary>
        /// Перевозчик
        /// </summary>
        [Description("Перевозчик")]
        Сarrier,
        /// <summary>
        /// Товаропроизводитель
        /// </summary>
        [Description("Товаропроизводитель")]
        СommodityProducer,
        /// <summary>
        /// Администратор
        /// </summary>
        [Description("Администратор")]
        Admin

    }
}
