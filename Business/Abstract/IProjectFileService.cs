using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProjectFileService
    {
        Task<IEnumerable<ProjectFile>> GetAllProjectFileAsync();
        Task<ProjectFile> GetProjectFileByIdAsync(int id);
        Task AddProjectFileAsync(ProjectFile projectFile);
        void UpdateProjectFile(ProjectFile projectFile);
        void DeleteProjectFile(ProjectFile projectFile);
    }
}
