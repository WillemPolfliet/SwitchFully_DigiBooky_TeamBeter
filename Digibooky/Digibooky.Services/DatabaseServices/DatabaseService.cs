using Digibooky.Databases.Authors;
using Digibooky.Databases.Books;
using Digibooky.Domain.Authors;
using Digibooky.Domain.Books;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Digibooky.Services.DatabaseServices
{
    public static class DatabaseService
    {
        public static void InitializeDatabase()
        {
            try
            {
                ReadDatabaseFileOfAuthors("uniqueAuthorsWithId.txt");
                ReadDatabaseFileOfBooks("uniqueBooksWithAuthorId.txt");
            }
            catch
            {
                throw new Exception();
            }
        }

        private static List<string> ReadLinesFromTxtFile(string folder, string fileName)
        {
            List<string> listOfLinesToReturn = new List<string>();

            var dir = Path.Combine(@"..\Digibooky.Database", folder);
            using (StreamReader reader = new StreamReader(File.Open(Path.Combine(dir, fileName), FileMode.OpenOrCreate)))
            {
                string[] lines = reader.ReadToEnd().Split("\r\n");
                listOfLinesToReturn.AddRange(lines);
            }
            return listOfLinesToReturn;
        }








        private static void ReadDatabaseFileOfAuthors(string fileName)
        {
            var listOfLines = ReadLinesFromTxtFile("Authors", fileName);

            foreach (string line in listOfLines)
            {
                string[] fields = line.Split(";");
                if (fields.Length != 3)
                { break; }

                Author currentAuthor = new Author(
                    Convert.ToInt32(fields[0]),
                    fields[1],
                    fields[2]
                    );

                AuthorsDatabase.authorsDb.Add(currentAuthor);
            }
        }

        private static void ReadDatabaseFileOfBooks(string fileName)
        {
            var listOfLines = ReadLinesFromTxtFile("Books", fileName);

            foreach (string line in listOfLines)
            {
                string[] fields = line.Split(";");
                if (fields.Length != 3)
                { break; } //TODO: Exception

                var currentAuthor = AuthorsDatabase.authorsDb.FirstOrDefault(Author => Author.AuthorId == Convert.ToInt32(fields[2]));
                if (currentAuthor == null)
                { throw new Exception(); }

                Book currentBook = new Book(
                    fields[0],
                    fields[1],
                    currentAuthor
                    );

                BooksDatabase.booksDb.Add(currentBook);
            }
        }
    }
}
