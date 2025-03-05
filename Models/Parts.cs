// Models/PartItem.cs
namespace MiataProjectTracker.Mobile.Models
{
    public class PartItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Status { get; set; } = "Needed";
        public decimal Cost { get; set; }
    }
}