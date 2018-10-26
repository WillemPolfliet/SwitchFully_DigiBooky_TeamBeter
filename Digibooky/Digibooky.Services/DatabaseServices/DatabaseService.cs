using Digibooky.Databases;
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static List<string> ReadLinesFromTxtFile(string fileName)
        {
            List<string> listOfLinesToReturn = new List<string>();

            var wantedPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var wantedFile = Path.Combine(wantedPath, "DB_InFiles", fileName);

            using (StreamReader reader = new StreamReader(File.Open(wantedFile, FileMode.OpenOrCreate)))
            {
                string[] lines = reader.ReadToEnd().Split("\r\n");
                listOfLinesToReturn.AddRange(lines);
            }
            return listOfLinesToReturn;
        }


        private static void ReadDatabaseFileOfAuthors(string fileName)
        {
            var listOfLines = ReadLinesFromTxtFile(fileName);

            for (int i = 0; i < listOfLines.Count; i++)
            {
                if (i == 0)
                { continue; }
                if (i == listOfLines.Count - 1)
                { continue; }

                string[] fields = listOfLines[i].Split(";");
                if (fields.Length != 3)
                { throw new Exception(); }

                Author currentAuthor = new Author
                    (
                        Convert.ToInt32(fields[0]),
                        fields[1],
                        fields[2]
                    );
                AuthorsDatabase.authorsDb.Add(currentAuthor);
            }
        }

        private static void ReadDatabaseFileOfBooks(string fileName)
        {
            var listOfLines = ReadLinesFromTxtFile(fileName);

            for (int i = 0; i < listOfLines.Count; i++)
            {
                if (i == 0)
                { continue; }
                if (i == listOfLines.Count - 1)
                { continue; }

                string[] fields = listOfLines[i].Split(";");
                if (fields.Length != 3)
                { throw new Exception("exc 01"); } //TODO: Exception

                var currentAuthor = AuthorsDatabase.authorsDb.FirstOrDefault(Author => Author.AuthorId == Convert.ToInt32(fields[2]));
                if (currentAuthor == null)
                { throw new Exception("exc 02"); }

                Book currentBook = new Book
                    (
                        fields[0],
                        fields[1],
                        currentAuthor
                    );
                BooksDatabase.booksDb.Add(currentBook);
            }
        }
    }
}
