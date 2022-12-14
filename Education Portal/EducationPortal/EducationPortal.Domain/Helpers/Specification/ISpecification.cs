namespace EducationPortal.Domain.Helpers.Specification
{
    public interface ISpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; }

        public bool IsSatisfiedBy(T obj);
    }
}
