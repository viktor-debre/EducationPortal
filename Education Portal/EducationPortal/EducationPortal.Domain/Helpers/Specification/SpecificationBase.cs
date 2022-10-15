namespace EducationPortal.Domain.Helpers.Specification
{
    public class SpecificationBase<T> : ISpecification<T>
    {
        public SpecificationBase(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public bool IsSatisfiedBy(T entity)
        {
            return Criteria.Compile().Invoke(entity);
        }
    }
}
