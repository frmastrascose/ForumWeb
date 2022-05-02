using ForumProject.ViewModels.Role;
using System.Collections.Generic;

namespace ForumProject.ViewModels.Admin
{
    public class AdminIndexViewModel
    {
        public IEnumerable<RoleViewModel> Roles { get; set; }
    }
}
