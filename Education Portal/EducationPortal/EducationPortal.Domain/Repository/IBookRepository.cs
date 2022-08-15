﻿using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Domain.Repository
{
    public interface IBookRepository
    {
        public List<BookMaterial> GetBooks();

        public BookMaterial GetBookById(int id);

        public void SetBook(BookMaterial material);

        public void UpdateBook(string name, BookMaterial updatedMaterial);

        public void DeleteBook(BookMaterial book);

        public void Save();
    }
}
