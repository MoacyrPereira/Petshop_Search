using kennel.Core.Extensions;
using kennel.Core.Entities;
using Xunit;

namespace kennel.Test;

public class PetshopTests
{
    [Fact]
    public void CalculateTotalPrice_MeuCaninoFeliz_DiaUtil()
    {
        var petshop = new PetShop
        {
            SmallDogPrice = 20.0,
            LargeDogPrice = 40.0,
            SmallDogPriceWeekend = 24.0,
            LargeDogPriceWeekend = 48.0
        };

        var bath = new Bath
        {
            Date = new DateTime(2025, 02, 12), // Quarta-feira
            QuantitySmallDogs = 3,
            QuantityLargeDogs = 5
        };

        double precoTotal = petshop.CalculateTotalPrice(bath);
        Assert.Equal(3 * 20.0 + 5 * 40.0, precoTotal);
    }

    [Fact]
    public void CalculateTotalPrice_VaiRex_Weekend()
    {
        var petshop = new PetShop
        {
            SmallDogPrice = 15.0,
            LargeDogPrice = 50.0,
            SmallDogPriceWeekend = 20.0,
            LargeDogPriceWeekend = 55.0
        };

        var banho = new Bath
        {
            Date = new DateTime(2025, 02, 15), // Sábado
            QuantitySmallDogs = 2,
            QuantityLargeDogs = 3
        };

        double precoTotal = petshop.CalculateTotalPrice(banho);
        Assert.Equal(2 * 20.0 + 3 * 55.0, precoTotal);
    }
}