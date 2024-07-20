using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Project : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime UploadDate { get; set; }
        public int UserId { get; set; }  

        public User User { get; set; }
        public ICollection<ProjectJson> ProjectJsons { get; set; }
        public ICollection<ProjectFile> ProjectFiles { get; set; }
        public bool IsDeleted { get ; set ; }
    }
}
