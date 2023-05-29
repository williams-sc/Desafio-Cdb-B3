using B3.CDB.API.Model;
using B3.CDB.API.Service;
using B3.CDB.API.ViewModel;
using B3.CDB.Unit.Test.Configuration;
using Microsoft.Extensions.Options;

namespace B3.CDB.Unit.Test;

public class CdbCalculatorServiceTest
{
    private readonly IOptions<IncomeTaxRange> _incomeTaxRate = SettingsConfiguration.InitIncomeTaxVariable();

    private CdbCalculatorService GetCalculatorService()
    {
        return new CdbCalculatorService(_incomeTaxRate);
    }

    [Theory]
    [InlineData(2, 1000, 1019.53, 1015.14)]
    [InlineData(7, 1000, 1070.06, 1056.05)]
    [InlineData(15, 1000, 1156.15, 1128.82)]
    [InlineData(28, 1000, 1311.07, 1264.41)]
    public void CdbCalculate_WithCorrectValues_ReturnCorretresponse(int term, decimal initialAmount, decimal gross, decimal net)
    {
        var requestMock = new CdbCalculatorRequest { MonthlyTerm = term, InitialAmount = initialAmount };

        var cdbCalculatorService = GetCalculatorService();

        var response = cdbCalculatorService.CdbCalculate(requestMock);

        Assert.NotNull(response);
        Assert.IsAssignableFrom<CdbCalculatorResponse>(response);
        Assert.Equal(gross, response.TotalAmountGross);
        Assert.Equal(net, response.TotalAmountNet);
    }
}