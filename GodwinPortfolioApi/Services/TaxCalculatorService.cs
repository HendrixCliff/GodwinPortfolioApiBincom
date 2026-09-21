using GodwinPortfolioApi.DTOs;

namespace GodwinPortfolioApi.Services;

public sealed class TaxCalculatorService
    : ITaxCalculatorService
{
    public TaxCalculatorResponse Calculate(
        TaxCalculatorRequest request)
    {
        var rentRelief = Math.Min(
            request.AnnualRent * 0.20m,
            500_000m);

        var totalDeductions =
            rentRelief
            + request.PensionContribution
            + request.NhfContribution
            + request.NhisContribution
            + request.LifeInsurance
            + request.MortgageInterest;

        var chargeableIncome = Math.Max(
            0m,
            request.AnnualGrossIncome -
            totalDeductions);

        var annualTax =
            CalculateProgressiveTax(chargeableIncome);

        var monthlyTax = Math.Round(
            annualTax / 12m,
            2,
            MidpointRounding.AwayFromZero);

        var effectiveTaxRate =
            request.AnnualGrossIncome > 0
                ? annualTax /
                  request.AnnualGrossIncome *
                  100m
                : 0m;

        return new TaxCalculatorResponse
        {
            AnnualGrossIncome =
                request.AnnualGrossIncome,

            AnnualRent =
                request.AnnualRent,

            PensionContribution =
                request.PensionContribution,

            NhfContribution =
                request.NhfContribution,

            NhisContribution =
                request.NhisContribution,

            LifeInsurance =
                request.LifeInsurance,

            MortgageInterest =
                request.MortgageInterest,

            RentRelief = rentRelief,

            TotalDeductions =
                totalDeductions,

            ChargeableIncome =
                chargeableIncome,

            AnnualTax =
                annualTax,

            MonthlyTax =
                monthlyTax,

            EffectiveTaxRate =
                effectiveTaxRate
        };
    }

    private static decimal CalculateProgressiveTax(
        decimal taxableIncome)
    {
        decimal remaining = taxableIncome;
        decimal tax = 0m;

        remaining = ApplyBand(
            remaining,
            800_000m,
            0m,
            ref tax);

        remaining = ApplyBand(
            remaining,
            2_200_000m,
            0.15m,
            ref tax);

        remaining = ApplyBand(
            remaining,
            9_000_000m,
            0.18m,
            ref tax);

        remaining = ApplyBand(
            remaining,
            13_000_000m,
            0.21m,
            ref tax);

        remaining = ApplyBand(
            remaining,
            25_000_000m,
            0.23m,
            ref tax);

        if (remaining > 0)
        {
            tax += remaining * 0.25m;
        }

        return Math.Round(
            tax,
            2,
            MidpointRounding.AwayFromZero);
    }

    private static decimal ApplyBand(
        decimal remaining,
        decimal bandSize,
        decimal rate,
        ref decimal tax)
    {
        if (remaining <= 0)
        {
            return 0m;
        }

        var taxableAmount =
            Math.Min(
                remaining,
                bandSize);

        tax += taxableAmount * rate;

        return remaining - taxableAmount;
    }
}