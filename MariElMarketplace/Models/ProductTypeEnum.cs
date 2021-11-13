using System.ComponentModel;

namespace MariElMarketplace.Models
{

    //Мясо / Птица / Рыба / Полуфабрикаты / Бакалея / Сладости / Молоко/Сыр / Заготовки / Овощи/Фрукты/Ягоды / Разное / Питомцам
    //Meat / Poultry / Fish / Semi-finished products / Grocery / Sweets / Milk / Cheese / Billets / Vegetables / Fruits / Berries / Miscellaneous / For pets



    public enum ProductTypeEnum
    {

        [Description("Мясо")]
        Meat,

        [Description("Птица")]
        Poultry,

        [Description("Полуфабрикаты")]
        SemiFinishedProducts,

        [Description("Бакалея")]
        Grocery,

        [Description("Сладости")]
        Sweets,

        [Description("Молоко")]
        Milk,

        [Description("Сыр")]
        Cheese,

        [Description("Заготовки")]
        Billets,

        [Description("Овощи")]
        Vegetables,

        [Description("Фрукты")]
        Fruits,

        [Description("Ягоды")]
        Berries,

        [Description("Разное")]
        Miscellaneous,

        [Description("Питомцам")]
        ForPets

    }
}
