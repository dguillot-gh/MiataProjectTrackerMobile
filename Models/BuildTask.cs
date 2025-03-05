using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MiataProjectTracker.Mobile.Models
{
    public class BuildTask
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; } = "Not Started";

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; } = "Other";

        public bool PartsNeeded { get; set; } = false;
        public bool PartsAcquired { get; set; } = false;
        public bool IsArchived { get; set; }
        public DateTime? ArchivedDate { get; set; }
    }
}
