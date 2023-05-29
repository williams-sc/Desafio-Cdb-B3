namespace B3.CDB.API.ViewModel
{
    public class CdbCalculatorResponse
    {
        public CdbCalculatorResponse(decimal totalAmountGross, decimal totalAmountNet)
        {
            TotalAmountGross = totalAmountGross;
            TotalAmountNet = totalAmountNet;
        }

        public decimal TotalAmountGross { get; set; }
        public decimal TotalAmountNet { get; set; }

    }
}
