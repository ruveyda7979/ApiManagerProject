using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime UploadDate { get; set; }
        public List<Project> Projects { get; set; } = new(); // Bir kullanıcının projeleri
        public bool IsDeleted { get; set ; }
    }
}
