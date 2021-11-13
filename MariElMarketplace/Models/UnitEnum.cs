using System.ComponentModel;

namespace MariElMarketplace.Models
{
    public enum UnitEnum
    {

        [Description("кг")]
        Kg,

        [Description("г")]
        gr,

        [Description("л")]
        liter,
        /// <summary>
        /// Штука
        /// </summary>
        [Description("шт.")]
        point

    }
}
