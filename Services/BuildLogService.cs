using MiataProjectTracker.Mobile.Models;
using System.Collections.Generic;
using System.Linq;

namespace MiataProjectTracker.Mobile.Services
{
    public class BuildLogService
    {
        private List<BuildLog> _entries = new();
        private int _nextId = 1;

        public BuildLogService()
        {
            // Add some sample data
            _entries.Add(new BuildLog
            {
                Id = _nextId++,
                Title = "Started Engine Rebuild",
                Summary = "Removed the engine from the car today. Found some issues with the head gasket that will need to be addressed.",
                Tag = "Engine",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-30))
            });

            _entries.Add(new BuildLog
            {
                Id = _nextId++,
                Title = "New Suspension Install",
                Summary = "Installed the new coilovers. The ride height is much better now and the handling has improved significantly.",
                Tag = "Suspension",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-15))
            });
        }

        public List<BuildLog> GetAllEntries()
        {
            return _entries.ToList();
        }

        public BuildLog GetEntry(int id)
        {
            return _entries.FirstOrDefault(e => e.Id == id);
        }

        public void AddEntry(BuildLog entry)
        {
            entry.Id = _nextId++;
            _entries.Add(entry);
        }

        public void UpdateEntry(BuildLog entry)
        {
            var existingEntry = _entries.FirstOrDefault(e => e.Id == entry.Id);
            if (existingEntry != null)
            {
                existingEntry.Title = entry.Title;
                existingEntry.Summary = entry.Summary;
                existingEntry.Tag = entry.Tag;
                existingEntry.Date = entry.Date;
            }
        }

        public void DeleteEntry(int id)
        {
            var entry = _entries.FirstOrDefault(e => e.Id == id);
            if (entry != null)
            {
                _entries.Remove(entry);
            }
        }
    }
}