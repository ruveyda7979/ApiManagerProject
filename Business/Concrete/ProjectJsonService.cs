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
    public class ProjectJsonService : IProjectJsonService
    {
        private readonly IProjectJsonDal _projectJsonDal;
        public ProjectJsonService(IProjectJsonDal projectJsonDal)
        {
            _projectJsonDal = projectJsonDal;
        }
        public async Task AddProjectJsonAsync(ProjectJson projectJson)
        {
            await _projectJsonDal.AddAsync(projectJson);
        }

        public void DeleteProjectJson(ProjectJson projectJson)
        {
            projectJson.IsDeleted = true;
            _projectJsonDal.Update(projectJson);
        }

        public async Task<IEnumerable<ProjectJson>> GetAllProjectJsonAsync()
        {
            return await _projectJsonDal.GetAllAsync(x => x.IsDeleted== false);
        }

        public async Task<ProjectJson> GetProjectJsonByIdAsync(int id)
        {
            return await _projectJsonDal.GetAsync(j => j.Id ==id && j.IsDeleted == false);
        }

        public void UpdateProjectJson(ProjectJson projectJson)
        {
            _projectJsonDal.Update(projectJson);
        }
    }
}
