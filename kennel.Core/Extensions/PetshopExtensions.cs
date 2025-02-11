using kennel.Core.Entities;

namespace kennel.Core.Extensions;

public static class PetshopExtensions
{
    public static double CalculateTotalPrice(this PetShop petshop, Bath bath)
    {
        var isFds = bath.Date.DayOfWeek == DayOfWeek.Saturday || bath.Date.DayOfWeek == DayOfWeek.Sunday;
        var smallPrice = isFds ? petshop.SmallDogPriceWeekend : petshop.SmallDogPrice;
        var largePrice = isFds ? petshop.LargeDogPriceWeekend : petshop.LargeDogPrice;
        return bath.QuantitySmallDogs * smallPrice + bath.QuantityLargeDogs * largePrice;
    }
}