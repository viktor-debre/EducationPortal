using EducationPortal.Application.Commands.Validation;
using EducationPortal.Domain.Helpers.Specification;
using FluentValidation.Results;

namespace EducationPortal.Application.Commands.CreateEntity
{
    internal class CreateBook
    {
        private readonly IRepository<BookMaterial> _bookRepository;

        public CreateBook(IRepository<BookMaterial> materialRepository)
        {
            _bookRepository = materialRepository;
        }

        public async Task<bool> TryCreateBook(BookMaterial book)
        {
            CreateBookValidation validations = new CreateBookValidation();
            ValidationResult validationResult = validations.Validate(book);
            if (!validationResult.IsValid)
            {
                return false;
            }

            var bookNameSpecification = new SpecificationBase<BookMaterial>(x => x.Name == book.Name);
            var checkBook = await _bookRepository.Find(bookNameSpecification);
            if (checkBook.FirstOrDefault() != null)
            {
                return false;
            }
            else
            {
                await _bookRepository.Add(book);
                return true;
            }
        }
    }
}
