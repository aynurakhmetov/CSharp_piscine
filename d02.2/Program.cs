﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using d02._2;
using Enumerable = d02._2.Enumerable;

var books = new Books();
var movies = new Movies();
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