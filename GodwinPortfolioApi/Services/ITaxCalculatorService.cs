using GodwinPortfolioApi.DTOs;

namespace GodwinPortfolioApi.Services;

public interface ITaxCalculatorService
{
    TaxCalculatorResponse Calculate(
        TaxCalculatorRequest request);
}