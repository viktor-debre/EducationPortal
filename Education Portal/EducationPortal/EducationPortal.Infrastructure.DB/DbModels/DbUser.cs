namespace EducationPortal.Infrastructure.DB.DbModels
{
    internal class DbUser: BaseEntity
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }
    }
}
