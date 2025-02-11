using kennel.Core.Entities;
using kennel.Core.Repositories;

namespace Kennel.Infrastructure.Repositories;

public class PetshopRepository : IPetShopRepository
{
    public IEnumerable<PetShop> GetPetshops()
    {
        return new List<PetShop>
        {
            new PetShop
            {
                Name = "Meu Canino Feliz",
                Distance = 2.0,
                SmallDogPrice = 20.0,
                LargeDogPrice = 40.0,
                SmallDogPriceWeekend = 20.0 * 1.2,
                LargeDogPriceWeekend = 40.0 * 1.2
            },
            new PetShop
            {
                Name = "Vai Rex",
                Distance = 1.7,
                SmallDogPrice = 15.0,
                LargeDogPrice = 50.0,
                SmallDogPriceWeekend = 20.0,
                LargeDogPriceWeekend = 55.0
            },
            new PetShop
            {
                Name = "ChowChawgas",
                Distance = 0.8,
                SmallDogPrice = 30.0,
                LargeDogPrice = 45.0,
                SmallDogPriceWeekend = 30.0,
                LargeDogPriceWeekend = 45.0
            }
        };
    }
}