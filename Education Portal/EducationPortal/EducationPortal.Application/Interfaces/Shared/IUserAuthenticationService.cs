namespace EducationPortal.Application.Interfaces.Shared
{
    public interface IUserAuthenticationService
    {
        public bool Authenticate(string userName, string password);
    }
}
