using EducationPortal.Domain.Helpers.Specification;
using FluentValidation.Results;

namespace EducationPortal.Application.Commands
{
    internal class CreateBook
    {
        private readonly IRepository<BookMaterial> _bookRepository;

        public CreateBook(IRepository<BookMaterial> materialRepository)
        {
            _bookRepository = materialRepository;
        }

        public bool TryCreateBook(BookMaterial book)
        {
            CreateBookValidation validations = new CreateBookValidation();
            ValidationResult validationResult = validations.Validate(book);
            if (!validationResult.IsValid)
            {
                return false;
            }

            var bookNameSpecification = new SpecificationBase<BookMaterial>(x => x.Name == book.Name);
            var checkArticle = _bookRepository.Find(bookNameSpecification).FirstOrDefault();
            if (checkArticle != null)
            {
                return false;
            }
            else
            {
                _bookRepository.Add(book);
                return true;
            }
        }
    }
}
