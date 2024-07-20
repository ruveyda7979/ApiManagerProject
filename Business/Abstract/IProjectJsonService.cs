using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProjectJsonService
    {
        Task<IEnumerable<ProjectJson>> GetAllProjectJsonAsync();
        Task<ProjectJson>GetProjectJsonByIdAsync(int id);
        Task AddProjectJsonAsync(ProjectJson projectJson);
        void UpdateProjectJson(ProjectJson projectJson);
        void DeleteProjectJson(ProjectJson projectJson);
    }
}
