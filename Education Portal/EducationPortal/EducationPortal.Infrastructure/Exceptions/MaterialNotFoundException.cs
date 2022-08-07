namespace EducationPortal.Infrastructure.Exceptions
{
    internal class MaterialNotFoundException : Exception
    {
        public MaterialNotFoundException()
        {
        }

        public MaterialNotFoundException(string name)
            : base($"Can not be found material with name: {name}.")
        {
        }

    }
}
