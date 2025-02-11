using kennel.Core.Entities;

namespace kennel.Core.Repositories;

public interface IPetShopRepository
{
    IEnumerable<PetShop> GetPetshops();
}