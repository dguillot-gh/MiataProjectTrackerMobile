namespace MiataProjectTracker.Mobile.Models
{
    public class PriceComparison
    {
        public int Id { get; set; }
        public string PartName { get; set; } = "";
        public decimal NewPrice { get; set; }
        public decimal ActualPaidPrice { get; set; }
        public string Source { get; set; } = "";
        public string Notes { get; set; } = "";

        public decimal Savings => NewPrice - ActualPaidPrice;
        public decimal SavingsPercentage => NewPrice > 0 ? (Savings / NewPrice) * 100 : 0;
    }
}