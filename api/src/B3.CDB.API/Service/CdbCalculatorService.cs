using B3.CDB.API.Model;
using B3.CDB.API.Utility;
using B3.CDB.API.ViewModel;
using Microsoft.Extensions.Options;

namespace B3.CDB.API.Service
{
    public class CdbCalculatorService : ICdbCalculatorService
    {
        private readonly IncomeTaxRange _incomeTaxRange;
        const float bankIncome = 1.08F;
        const float cdi = 0.009F;

        public CdbCalculatorService(IOptions<IncomeTaxRange> incomeTaxRange)
        {
            _incomeTaxRange = incomeTaxRange.Value;
        }

        public CdbCalculatorResponse CdbCalculate(CdbCalculatorRequest request)
        {
            var amountGrossTotalBeforeTax = AmountTotalCalculate(request);
            var amountIncomeTotalBeforeTax = amountGrossTotalBeforeTax - request.InitialAmount;

            var amountIncomeTax = ApplyTax(request.MonthlyTerm, amountIncomeTotalBeforeTax);

            return new CdbCalculatorResponse
            (
                Math.Round(amountGrossTotalBeforeTax, 2),
                Math.Round(amountGrossTotalBeforeTax - amountIncomeTax, 2)
            );
        }

        private decimal AmountTotalCalculate(CdbCalculatorRequest request)
        {
            var efectiveTax = FinancialOperation.GetEfectiveTax(cdi, bankIncome);

            var incomeByTerm = FinancialOperation.GetTotalComposedIncomeByTerm(efectiveTax, request.MonthlyTerm);

            var amountTotal = request.InitialAmount * incomeByTerm;

            return amountTotal;
        }

        private decimal ApplyTax(int term, decimal amountIncomeTotalBeforeTax)
        {
            var tax = _incomeTaxRange.GetIncomeTaxToApply(term);

            return amountIncomeTotalBeforeTax * (decimal)tax;
        }

    }
}