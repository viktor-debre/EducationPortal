using EducationPortal.Application.Commands.Validation;
using EducationPortal.Domain.Entities.Materials;
using FluentValidation.Results;
using EducationPortal.Domain.Repository;

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
