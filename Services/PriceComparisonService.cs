using MiataProjectTracker.Mobile.Models;
using System.Collections.Generic;
using System.Linq;

namespace MiataProjectTracker.Mobile.Services
{
    public class PriceComparisonService
    {
        private List<PriceComparison> _comparisons = new();
        private int _nextId = 1;

        public PriceComparisonService()
        {
            // Add some sample data
            _comparisons.Add(new PriceComparison
            {
                Id = _nextId++,
                PartName = "Coilover Kit",
                NewPrice = 899.99m,
                ActualPaidPrice = 699.99m,
                Source = "Facebook Marketplace",
                Notes = "Barely used, only 1000 miles"
            });

            _comparisons.Add(new PriceComparison
            {
                Id = _nextId++,
                PartName = "Exhaust Header",
                NewPrice = 349.99m,
                ActualPaidPrice = 200.00m,
                Source = "eBay",
                Notes = "Minor surface rust but otherwise perfect"
            });

            _comparisons.Add(new PriceComparison
            {
                Id = _nextId++,
                PartName = "Intake Manifold",
                NewPrice = 499.99m,
                ActualPaidPrice = 350.00m,
                Source = "Miata Forum",
                Notes = ""
            });
        }

        public List<PriceComparison> GetAllComparisons()
        {
            return _comparisons.ToList();
        }

        public PriceComparison GetComparison(int id)
        {
            return _comparisons.FirstOrDefault(c => c.Id == id);
        }

        public void AddComparison(PriceComparison comparison)
        {
            comparison.Id = _nextId++;
            _comparisons.Add(comparison);
        }

        public void UpdateComparison(PriceComparison comparison)
        {
            var existingComparison = _comparisons.FirstOrDefault(c => c.Id == comparison.Id);
            if (existingComparison != null)
            {
                existingComparison.PartName = comparison.PartName;
                existingComparison.NewPrice = comparison.NewPrice;
                existingComparison.ActualPaidPrice = comparison.ActualPaidPrice;
                existingComparison.Source = comparison.Source;
                existingComparison.Notes = comparison.Notes;
            }
        }

        public void DeleteComparison(int id)
        {
            var comparison = _comparisons.FirstOrDefault(c => c.Id == id);
            if (comparison != null)
            {
                _comparisons.Remove(comparison);
            }
        }
    }
}