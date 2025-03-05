using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MiataProjectTracker.Mobile.Models;

namespace MiataProjectTracker.Mobile.Services
{
    public class BuildTaskService
    {
        private List<BuildTask> _tasks = new List<BuildTask>
        {
            new BuildTask {
                Id = 1,
                Title = "Replace Timing Belt",
                Description = "Replace timing belt and water pump",
                Status = "Not Started",
                Category = "Engine",
                PartsNeeded = true,
                PartsAcquired = false
            },
            new BuildTask {
                Id = 2,
                Title = "Install Coilovers",
                Description = "Install new coilover suspension",
                Status = "In Progress",
                Category = "Suspension",
                PartsNeeded = true,
                PartsAcquired = true
            },
            new BuildTask {
                Id = 3,
                Title = "Replace Brake Pads",
                Description = "Install new brake pads and rotors",
                Status = "Completed",
                Category = "Brakes",
                PartsNeeded = true,
                PartsAcquired = true
            },
            new BuildTask {
                Id = 4,
                Title = "Fix Dashboard Lights",
                Description = "Repair non-working dashboard illumination",
                Status = "Not Started",
                Category = "Electrical",
                PartsNeeded = false,
                PartsAcquired = false
            }
        };

        public List<BuildTask> GetTasks()
        {
            return _tasks.Where(t => !t.IsArchived).ToList();
        }

        public List<BuildTask> GetArchivedTasks()
        {
            return _tasks.Where(t => t.IsArchived).ToList();
        }

        public void AddTask(BuildTask task)
        {
            task.Id = _tasks.Count > 0 ? _tasks.Max(t => t.Id) + 1 : 1;
            _tasks.Add(task);
        }

        public void UpdateTask(BuildTask task)
        {
            var index = _tasks.FindIndex(t => t.Id == task.Id);
            if (index != -1)
            {
                _tasks[index] = task;
            }
        }

        public void DeleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                _tasks.Remove(task);
            }
        }

        public void ArchiveTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.IsArchived = true;
                task.ArchivedDate = DateTime.Now;
            }
        }

        public void UnarchiveTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.IsArchived = false;
                task.ArchivedDate = null;
            }
        }
    }
}
