using System.ComponentModel.DataAnnotations;

namespace GodwinPortfolioApi.DTOs;

public sealed class TaxCalculatorRequest
{
    [Range(0, double.MaxValue)]
    public decimal AnnualGrossIncome { get; set; }

    [Range(0, double.MaxValue)]
    public decimal AnnualRent { get; set; }

    [Range(0, double.MaxValue)]
    public decimal PensionContribution { get; set; }

    [Range(0, double.MaxValue)]
    public decimal NhfContribution { get; set; }

    [Range(0, double.MaxValue)]
    public decimal NhisContribution { get; set; }

    [Range(0, double.MaxValue)]
    public decimal LifeInsurance { get; set; }

    [Range(0, double.MaxValue)]
    public decimal MortgageInterest { get; set; }
}