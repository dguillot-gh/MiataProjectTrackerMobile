using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiataProjectTracker.Mobile.Models;

namespace MiataProjectTracker.Mobile.Services
{
    public class PartsService
    {
        private List<PartItem> _parts = new List<PartItem>
        {
            new PartItem { Id = 1, Name = "Brake Pads", Number = "BP-123", Status = "Needed", Cost = 89.99M },
            new PartItem { Id = 2, Name = "Oil Filter", Number = "OF-456", Status = "Acquired", Cost = 12.99M }
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
    }
}