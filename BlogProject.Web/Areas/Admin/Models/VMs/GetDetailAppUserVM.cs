using BlogProject.Model.Enums;


namespace BlogProject.Web.Areas.Admin.Models.VMs
{
    public class GetDetailAppUserVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        public string Image { get; set; }
    }
}
