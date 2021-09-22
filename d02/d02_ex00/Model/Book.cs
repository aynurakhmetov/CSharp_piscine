using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Linq;

namespace d02_ex00
{
    class Books : ISearchable
    {
        private InfoBookJson infoBook;
        private List<Book> books;
        const string fileNameBookJson = "book_reviews.json";
        public IEnumerable<Book> selectedBooks;
        public int countSeletedBooks;

        public Books()
        {
            string jsonStringBook = File.ReadAllText(fileNameBookJson);
            InfoBookJson infoBook = JsonSerializer.Deserialize<InfoBookJson>(jsonStringBook);
            books = new List<Book>();
            for (int i = 0; i < infoBook.NumResults; i++)
            {
                Book tempBook = new Book();
                tempBook.Title = infoBook.Results[i].BookDetails[0].Title;
                tempBook.Author = infoBook.Results[i].BookDetails[0].Author;
                tempBook.SummaryShort = infoBook.Results[i].BookDetails[0].Description;
                tempBook.Rank = infoBook.Results[i].Rank;
                tempBook.ListName = infoBook.Results[i].ListName;
                tempBook.Url = infoBook.Results[i].AmazonProductUrl;
                books.Add(tempBook);
                tempBook = null;
            }
        }

        public void Search(string title)
        {
            countSeletedBooks = 0;
            
            selectedBooks = from book in books
                where book.Title.ToLower().Contains(title.ToLower())
                select book;

            foreach (var m in selectedBooks)
            {
                countSeletedBooks++;
            }
        }
    }
    
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string SummaryShort { get; set; }
        public int Rank { get; set; }
        public string ListName { get; set; }
        public string Url { get; set; }

        public override string ToString()
        {
            string answer;

            answer = $"{this.Title} by {this.Author} [{this.Rank} on NYT’s {this.ListName}]\n" +
                     $"{this.SummaryShort}\n" +
                     $"{this.Url}\n";
            return answer;
        }
    }
    public class InfoBookJson
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("copyright")]
        public string Copyright { get; set; }
        [JsonPropertyName("num_results")]
        public int NumResults { get; set; }
        [JsonPropertyName("last_modified")]
        public DateTime LastModified { get; set; }
        [JsonPropertyName("results")]
        public List<Result> Results { get; set; }
        public class Result
        {
            [JsonPropertyName("list_name")]
            public string ListName { get; set; }
            [JsonPropertyName("display_name")]
            public string DisplayName { get; set; }
            [JsonPropertyName("bestsellers_date")]
            public string BestsellersDate { get; set; }
            [JsonPropertyName("published_date")]
            public string PublishedDate { get; set; }
            [JsonPropertyName("rank")]
            public int Rank { get; set; }
            [JsonPropertyName("rank_last_week")]
            public int RankLastWeek { get; set; }
            [JsonPropertyName("weeks_on_list")]
            public int WeeksOnList { get; set; }
            [JsonPropertyName("asterisk")]
            public int Asterisk { get; set; }
            [JsonPropertyName("dagger")]
            public int Dagger { get; set; }
            [JsonPropertyName("amazon_product_url")]
            public string AmazonProductUrl { get; set; }
            [JsonPropertyName("isbns")]
            public List<Isbn> Isbns { get; set; }
            [JsonPropertyName("book_details")]
            public List<BookDetail> BookDetails { get; set; }
            [JsonPropertyName("reviews")]
            public List<Review> Reviews { get; set; }
        }
        public class Review
        {
            [JsonPropertyName("book_review_link")]
            public string BookReviewLink { get; set; }
            [JsonPropertyName("first_chapter_link")]
            public string FirstChapterLink { get; set; }
            [JsonPropertyName("sunday_review_link")]
            public string SundayReviewLink { get; set; }
            [JsonPropertyName("article_chapter_link")]
            public string ArticleChapterLink { get; set; }
        }
        public class BookDetail
        {
            [JsonPropertyName("title")]
            public string Title { get; set; }
            [JsonPropertyName("description")]
            public string Description { get; set; }
            [JsonPropertyName("contributor")]
            public string Contributor { get; set; }
            [JsonPropertyName("author")]
            public string Author { get; set; }
            [JsonPropertyName("contributor_note")]
            public string ContributorNote { get; set; }
            [JsonPropertyName("price")]
            public string Price { get; set; }
            [JsonPropertyName("age_group")]
            public string AgeGroup { get; set; }
            [JsonPropertyName("publisher")]
            public string Publisher { get; set; }
            [JsonPropertyName("primary_isbn13")]
            public string PrimaryIsbn13 { get; set; }
            [JsonPropertyName("primary_isbn10")]
            public string PrimaryIsbn10 { get; set; }
        }
        public class Isbn
        {
            [JsonPropertyName("isbn10")]
            public string Isbn10 { get; set; }
            [JsonPropertyName("isbn13")]
            public string Isbn13 { get; set; }
        }
    }
}