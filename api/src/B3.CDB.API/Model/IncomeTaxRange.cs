namespace B3.CDB.API.Model
{
    public class IncomeTaxRange
    {
        public float I { get; set; }
        public float II { get; set; }
        public float III { get; set; }
        public float IV { get; set; }


        public float GetIncomeTaxToApply(int term)
        {
            return term switch
            {
                < 7 => I,
                < 13 => II,
                < 25 => III,
                _ => IV,
            };
        }
    }
}
