using System;
using System.Linq;
using d02._2;


var books = new Books();
var movies = new Movies();

if (args.Length == 1 && args[0] == "best")
{
    books.Best();
    movies.Best();
    return;
}

string searchTitle;

Console.WriteLine("> Input search text:");
searchTitle = Console.ReadLine();

books.selectedBooks = books.books.Search(searchTitle);
books.countSeletedBooks = books.selectedBooks.Count();

movies.selectedMovies = movies.movies.Search(searchTitle);
movies.countSeletedMovies = movies.selectedMovies.Count();

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