namespace GodwinPortfolioApi.DTOs;

public sealed class TaxCalculatorResponse
{
    public decimal AnnualGrossIncome { get; init; }

    public decimal AnnualRent { get; init; }

    public decimal PensionContribution { get; init; }

    public decimal NhfContribution { get; init; }

    public decimal NhisContribution { get; init; }

    public decimal LifeInsurance { get; init; }

    public decimal MortgageInterest { get; init; }

    public decimal RentRelief { get; init; }

    public decimal TotalDeductions { get; init; }

    public decimal ChargeableIncome { get; init; }

    public decimal AnnualTax { get; init; }

    public decimal MonthlyTax { get; init; }

    public decimal EffectiveTaxRate { get; init; }
}