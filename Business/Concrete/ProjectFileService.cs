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
    public class ProjectFileService : IProjectFileService
    {

        private readonly IProjectFileDal _projectFileDal;
        public ProjectFileService(IProjectFileDal projectFileDal)
        {
            _projectFileDal = projectFileDal;
        }
        public async Task AddProjectFileAsync(ProjectFile projectFile)
        {
          await _projectFileDal.AddAsync(projectFile);
        }

        public void DeleteProjectFile(ProjectFile projectFile)
        {
           projectFile.IsDeleted = true;
            _projectFileDal.Update(projectFile);
            
        }

        public async Task<IEnumerable<ProjectFile>> GetAllProjectFileAsync()
        {
            return await _projectFileDal.GetAllAsync(x=> x.IsDeleted == false);
        }

        public async Task<ProjectFile> GetProjectFileByIdAsync(int id)
        {
            return await _projectFileDal.GetAsync(p => p.Id == id && p.IsDeleted == false);
        }

        public void UpdateProjectFile(ProjectFile projectFile)
        {
            _projectFileDal.Update(projectFile);
        }
    }
}
