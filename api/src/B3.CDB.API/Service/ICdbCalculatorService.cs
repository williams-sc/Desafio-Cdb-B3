using B3.CDB.API.ViewModel;

namespace B3.CDB.API.Service
{
    public interface ICdbCalculatorService
    {
        CdbCalculatorResponse CdbCalculate(CdbCalculatorRequest request);
    }
}