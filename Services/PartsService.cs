// Services/PartsService.cs
using MiataProjectTracker.Mobile.Models;

namespace MiataProjectTracker.Mobile.Services
{
    public class PartsService
    {
        private List<PartItem> _parts = new List<PartItem>
        {
            new PartItem { Id = 1, Name = "Brake Pads", Number = "BP-123", Status = "Needed", Cost = 89.99M },
            new PartItem { Id = 2, Name = "Oil Filter", Number = "OF-456", Status = "Acquired", Cost = 12.99M },
            new PartItem { Id = 3, Name = "Spark Plugs", Number = "SP-789", Status = "Needed", Cost = 24.50M }
        };

        public List<PartItem> GetParts()
        {
            return _parts;
        }

        public void AddPart(PartItem part)
        {
            part.Id = _parts.Count > 0 ? _parts.Max(p => p.Id) + 1 : 1;
            _parts.Add(part);
        }

        public void UpdatePart(PartItem part)
        {
            var index = _parts.FindIndex(p => p.Id == part.Id);
            if (index != -1)
            {
                _parts[index] = part;
            }
        }

        public void DeletePart(int id)
        {
            var part = _parts.FirstOrDefault(p => p.Id == id);
            if (part != null)
            {
                _parts.Remove(part);
            }
        }
    }
}