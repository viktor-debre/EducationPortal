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

            var checkArticle = _bookRepository.Find().FirstOrDefault(x => x.Name == book.Name);
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
