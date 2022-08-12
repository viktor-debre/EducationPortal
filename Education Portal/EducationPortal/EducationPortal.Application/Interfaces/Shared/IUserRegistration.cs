namespace EducationPortal.Application.Interfaces.Shared
{
    public interface IUserRegistration
    {
        public bool TryCreateUser(string name, string password);
    }
}
