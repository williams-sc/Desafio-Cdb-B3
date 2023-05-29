using System.ComponentModel.DataAnnotations;

namespace B3.CDB.API.ViewModel
{
    public class CdbCalculatorRequest
    {
        [Required(ErrorMessage = "A quantidade de meses precisa ser informada")]
        [Range(1, 60, ErrorMessage = "O prazo deve estar entre 01 mês e 05 anos (60 meses) sendo este último o prazo máximo de vencimento do CDB.")]
        public int MonthlyTerm { get; set; }

        [Required(ErrorMessage = "O valor precisa ser informado")]
        [Range(1, 9999999999999.99, ErrorMessage = "Você precisa indicar um capital inicial entre 1 e 9.999.999.999.999,99")]
        public decimal InitialAmount { get; set; }

    }
}