using EducationPortal.Domain.Entities.Materials;
using EducationPortal.Domain.Repository;
using FluentValidation.Results;

namespace EducationPortal.Application.Commands
{
    internal class CreateBook
    {
        private readonly IBookRepository _bookRepository;

        public CreateBook(IBookRepository materialRepository)
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

            _bookRepository.GetBooks();
            BookMaterial? existingMaterial = _bookRepository.GetBookByName(book.Name);
            if (existingMaterial != null)
            {
                return false;
            }
            else
            {
                _bookRepository.SetBook(book);
                return true;
            }
        }
    }
}
