using System.ComponentModel.DataAnnotations;

namespace GodwinPortfolioApi.DTOs;

public sealed class TaxCalculatorRequest : IValidatableObject
{
    public decimal AnnualGrossIncome { get; set; }

    public decimal AnnualRent { get; set; }

    public decimal PensionContribution { get; set; }

    public decimal NhfContribution { get; set; }

    public decimal NhisContribution { get; set; }

    public decimal LifeInsurance { get; set; }

    public decimal MortgageInterest { get; set; }

    public IEnumerable<ValidationResult> Validate(
        ValidationContext validationContext)
    {
        if (AnnualGrossIncome < 0m)
        {
            yield return new ValidationResult(
                "Annual gross income cannot be negative.",
                new[] { nameof(AnnualGrossIncome) });
        }

        if (AnnualRent < 0m)
        {
            yield return new ValidationResult(
                "Annual rent cannot be negative.",
                new[] { nameof(AnnualRent) });
        }

        if (PensionContribution < 0m)
        {
            yield return new ValidationResult(
                "Pension contribution cannot be negative.",
                new[] { nameof(PensionContribution) });
        }

        if (NhfContribution < 0m)
        {
            yield return new ValidationResult(
                "NHF contribution cannot be negative.",
                new[] { nameof(NhfContribution) });
        }

        if (NhisContribution < 0m)
        {
            yield return new ValidationResult(
                "NHIS contribution cannot be negative.",
                new[] { nameof(NhisContribution) });
        }

        if (LifeInsurance < 0m)
        {
            yield return new ValidationResult(
                "Life insurance cannot be negative.",
                new[] { nameof(LifeInsurance) });
        }

        if (MortgageInterest < 0m)
        {
            yield return new ValidationResult(
                "Mortgage interest cannot be negative.",
                new[] { nameof(MortgageInterest) });
        }

        var allInputsAreZero =
            AnnualGrossIncome == 0m &&
            AnnualRent == 0m &&
            PensionContribution == 0m &&
            NhfContribution == 0m &&
            NhisContribution == 0m &&
            LifeInsurance == 0m &&
            MortgageInterest == 0m;

        if (allInputsAreZero)
        {
            yield return new ValidationResult(
                "At least one tax input must be greater than zero.");
        }
    }
}