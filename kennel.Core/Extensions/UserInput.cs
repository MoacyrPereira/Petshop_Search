using kennel.Core.Entities;

namespace kennel.Core.Extensions;

public class UserInput
{
    private const int MaxDogsPerSize = 15;
    private const string DateFormat = "dd/MM/yyyy";

    public record ValidationResult(bool IsValid, string ErrorMessage, Bath Bath = null);

    public static ValidationResult ValidateInput(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return new ValidationResult(false, "A entrada não pode estar vazia.");
        
        var inputs = input.Split(' ')
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .ToArray();

        if (inputs.Length != 3)
            return new ValidationResult(false, "A entrada tem que conter data, quantidade de cães pequenos e quantidade de cães grandes.");
        
        var isValidDate = DateTime.TryParseExact(
            inputs[0], 
            DateFormat, 
            null, 
            System.Globalization.DateTimeStyles.None, 
            out var date);

        if (!isValidDate)
            return new ValidationResult(false, $"A data deve estar no formato {DateFormat}");
        
        var isValidSmallDogs = int.TryParse(inputs[1], out int smallDogs);
        var isValidLargeDogs = int.TryParse(inputs[2], out int largeDogs);

        if (!isValidSmallDogs || !isValidLargeDogs)
            return new ValidationResult(false, "Quantidades de cães devem ser números válidos.");

        var validationResult = ValidateQuantities(smallDogs, largeDogs);
        if (!validationResult.IsValid)
            return validationResult;

        var bath = new Bath
        {
            Date = date,
            QuantitySmallDogs = smallDogs,
            QuantityLargeDogs = largeDogs
        };

        return new ValidationResult(true, string.Empty, bath);
    }

    private static ValidationResult ValidateQuantities(int smallDogs, int largeDogs)
    {
        var errorMessage = (smallDogs, largeDogs) switch
        {
            ( < 0, _) => "A quantidade de cães pequenos não pode ser negativa.",
            (_, < 0) => "A quantidade de cães grandes não pode ser negativa.",
            ( > MaxDogsPerSize, _) => $"A quantidade de cães pequenos não pode exceder {MaxDogsPerSize}.",
            (_, > MaxDogsPerSize) => $"A quantidade de cães grandes não pode exceder {MaxDogsPerSize}.",
            _ => string.Empty
        };

        return new ValidationResult(
            string.IsNullOrEmpty(errorMessage),
            errorMessage
        );
    }
}