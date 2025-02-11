using kennel.Core.Entities;
using kennel.Core.Repositories;
using Kennel.Infrastructure.Repositories;
using kennel.Core.Extensions;

    Console.WriteLine("Digite a data do banho (dd/MM/yyyy), quantidade de cães pequenos e quantidade de cães grandes:");
    string input = Console.ReadLine();
    
    var validationResult = UserInput.ValidateInput(input);
        
    if (!validationResult.IsValid)
    {
        Console.WriteLine($"Erro: {validationResult.ErrorMessage}");
        Console.ReadLine();
        return;
    }

    string[] inputs = input.Split(' ');
    DateTime date = DateTime.ParseExact(inputs[0], "dd/MM/yyyy", null);
    int qtdSmallDogs = int.Parse(inputs[1]);
    int qtdLargeDogs = int.Parse(inputs[2]);

    Bath bath = new Bath
    {
        Date = date,
        QuantitySmallDogs = qtdSmallDogs,
        QuantityLargeDogs = qtdLargeDogs
    };

    IPetShopRepository repository = new PetshopRepository();
    var petshops = repository.GetPetshops();

    var bestPetshop = petshops
        .Select(p => new
        {
            Nome = p.Name,
            PrecoTotal = p.CalculateTotalPrice(bath),
            Distancia = p.Distance
        })
        .OrderBy(p => p.PrecoTotal)
        .ThenBy(p => p.Distancia) // Se tiver empate no preço, aqui vai ordena por distância. Escolhe o mais próximo
        .First();

    Console.WriteLine($"Melhor petshop: {bestPetshop.Nome}, Preço total: R${bestPetshop.PrecoTotal:F2}");
    Console.ReadLine();