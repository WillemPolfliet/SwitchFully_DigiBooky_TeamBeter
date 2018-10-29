using Digibooky.Domain.Books;
using System.Collections.Generic;

namespace Digibooky.Databases
{
    public static class BooksDatabase
    {
        public static List<Book> booksDb = new List<Book>()
        {
            new Book("9789024555147","Het Franciscus Verbond", "Gwen", "Jamroziak"),
            new Book("9789028418028","Wereldbibliotheekreeks Verloren eer","Gwen", "Jamroziak"),
            new Book("9789021006536","Drie weken in Parijs","Gwen", "Jamroziak"),
            new Book("9789063050184","Icy Sparks","Gwen", "Jamroziak"),
            new Book("9789065656322","De weg van wijzewentel", "Caroline", "Callens"),
            new Book("9789022325896","Vergelijking met X onbekenden", "Caroline", "Callens"),
            new Book("9789063050689","Mortuarium", "Caroline", "Callens"),
            new Book("9789032515119","Koudwatervrees", "Caroline", "Callens"),
            new Book("9789041006295","IN SLUIER GEVANGEN / UIT LIEFDE VR KIND", "Caroline", "Callens"),
            new Book("9789044501094","Het Huwelijk", "Caroline", "Callens")
        };
    }
}
