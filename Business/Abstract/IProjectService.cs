using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllProjectAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task AddProjectAsync(Project project);
        void UpdateProject(Project project);
        void DeleteProject(Project project);
    }
}
