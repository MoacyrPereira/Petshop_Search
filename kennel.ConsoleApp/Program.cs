using kennel.Core.Entities;
using kennel.Core.Repositories;
using Kennel.Infrastructure.Repositories;
using kennel.Core.Extensions;

    var resultOk = false;
    var input = string.Empty;
    var validationResult = new UserInput.ValidationResult(false, string.Empty);
    
    Console.WriteLine("Digite a data do banho (dd/MM/yyyy), quantidade de cães pequenos e quantidade de cães grandes:");
    input = Console.ReadLine();

    do
    {
        if(input == "exit")
            return;
        
        validationResult = UserInput.ValidateInput(input);
    
        if (!validationResult.IsValid)
        {
            Console.WriteLine($"Erro: {validationResult.ErrorMessage}. Tente novamente:");
            input = Console.ReadLine();
            continue;
        }

        resultOk = true;
    }
    while (!resultOk);

    Bath bath = new Bath
    {
        Date = validationResult.Bath.Date,
        QuantitySmallDogs = validationResult.Bath.QuantitySmallDogs,
        QuantityLargeDogs = validationResult.Bath.QuantityLargeDogs
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
    Console.WriteLine("Console Finalizado! Pressione qualquer tecla para sair.");
    Console.ReadKey();