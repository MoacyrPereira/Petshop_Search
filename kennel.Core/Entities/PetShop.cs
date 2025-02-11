namespace kennel.Core.Entities;

public class PetShop
{
    public string Name { get; set; } = new("");
    public double Distance { get; set; }
    public double SmallDogPrice { get; set; }
    public double LargeDogPrice { get; set; }
    public double SmallDogPriceWeekend { get; set; }
    public double LargeDogPriceWeekend { get; set; }
}