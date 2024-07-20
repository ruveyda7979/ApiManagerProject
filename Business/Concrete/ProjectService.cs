using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProjectService : IProjectService
    {

        private readonly IProjectDal _projectDal;
        public ProjectService(IProjectDal projectDal)
        {
            _projectDal = projectDal;
        }
        public async Task AddProjectAsync(Project project)
          => await _projectDal.AddAsync(project);


        public void DeleteProject(Project project)
        {
            project.IsDeleted = true;
            _projectDal.Update(project);
        }


        public async Task<IEnumerable<Project>> GetAllProjectAsync()
            => await _projectDal.GetAllAsync(x => x.IsDeleted == false);


        public async Task<Project> GetProjectByIdAsync(int id)
           => await _projectDal.GetAsync(p => p.Id == id && p.IsDeleted == false);


        public void UpdateProject(Project project)
           => _projectDal.Update(project);
        
    }
}
