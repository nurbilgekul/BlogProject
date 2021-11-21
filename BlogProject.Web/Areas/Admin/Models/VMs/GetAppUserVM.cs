using BlogProject.Model.Enums;


namespace BlogProject.Web.Areas.Admin.Models.VMs
{
    public class GetAppUserVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string Image { get; set; }
    }
}
