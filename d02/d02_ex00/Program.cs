using System;
using d02_ex00;

var books = new Books();
var movies = new Movies();
string searchTitle;

Console.WriteLine("> Input search text:");
searchTitle = Console.ReadLine();

books.Search(searchTitle);
movies.Search(searchTitle);

if (books.countSeletedBooks + movies.countSeletedMovies == 0)
{
    Console.WriteLine($"\nThere are no “{searchTitle}” in media today.");
    return;
}

Console.WriteLine($"\nItems found: {books.countSeletedBooks + movies.countSeletedMovies}\n");

Console.WriteLine($"Book search result [{books.countSeletedBooks}]:");
foreach(var book in books.selectedBooks)
{
    Console.Write($"- {book.ToString()}");
}

Console.WriteLine($"\nMovie search result [{movies.countSeletedMovies}]:");
foreach(var movie in movies.selectedMovies)
{
    Console.Write($"- {movie.ToString()}");
}
