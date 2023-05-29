namespace B3.CDB.API.Utility
{
    public static class FinancialOperation
    {
        public static double GetEfectiveTax(float baseTax, float AppliedTax)
        {
            return (1 + (baseTax * AppliedTax));
        }

        public static decimal GetTotalComposedIncomeByTerm(double tax, int term)
        {
            var incomeByTerm = Math.Pow(tax, term);

            return Convert.ToDecimal(incomeByTerm);
        }
    }
}
