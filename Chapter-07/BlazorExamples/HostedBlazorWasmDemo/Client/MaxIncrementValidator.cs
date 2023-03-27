using System.ComponentModel.DataAnnotations;

namespace HostedBlazorWasmDemo.Client;

public class MaxIncrementValidator : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var paramValuesConfig = validationContext.GetRequiredService<ParamValuesConfig>();

        if ((int)value > paramValuesConfig.MaxIncrementValue)
            return new ValidationResult($"Values greated than {paramValuesConfig.MaxIncrementValue
                } are not allowed!", new[] { validationContext.MemberName });

        return ValidationResult.Success;
    }
}

public class ParamValuesConfig
{
    public int MaxIncrementValue { get; set; } = 5;
}