using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using d02_ex00;

namespace d02_ex00
{
    class Movies : ISearchable
    {
        private InfoMovieJson infoMovie;
        private List<Movie> movies;
        const string fileNameMovieJson = "book_reviews.json";

        public Movies()
        {
            string jsonStringMovie = File.ReadAllText(fileNameMovieJson);
            InfoMovieJson infoMovie = JsonSerializer.Deserialize<InfoMovieJson>(jsonStringMovie);
        }
    }
    
    
    public class Movie
    {
        public string Title { get; set; }
        public string Raiting { get; set; }
        public int IsCriticsPick { get; set; }
        public string SummaryShort { get; set; }
        public string Url { get; set; }
    }
    
    public class InfoMovieJson
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("copyright")]
        public string Copyright { get; set; }
        [JsonPropertyName("has_more")]
        public bool HasMore { get; set; }
        [JsonPropertyName("num_results")]
        public int NumResults { get; set; }
        [JsonPropertyName("results")]
        public List<Result> Results { get; set; }
        
        public class Result
        {
            [JsonPropertyName("title")]
            public string Title { get; set; }
            [JsonPropertyName("mpaa_rating")]
            public string MpaaRating { get; set; }
            [JsonPropertyName("critics_pick")]
            public int CriticsPick { get; set; }
            [JsonPropertyName("byline")]
            public string Byline { get; set; }
            [JsonPropertyName("headline")]
            public string Headline { get; set; }
            [JsonPropertyName("summary_short")]
            public string SummaryShort { get; set; }
            [JsonPropertyName("publication_date")]
            public string PublicationDate { get; set; }
            [JsonPropertyName("opening_date")]
            public string OpeningDate { get; set; }
            [JsonPropertyName("date_updated")]
            public string DateUpdated { get; set; }
            [JsonPropertyName("link")]
            public Link Link { get; set; }
            [JsonPropertyName("multimedia")]
            public Multimedia Multimedia { get; set; }
        }
        public class Multimedia
        {
            [JsonPropertyName("type")]
            public string Type { get; set; }
            [JsonPropertyName("src")]
            public string Src { get; set; }
            [JsonPropertyName("height")]
            public int Height { get; set; }
            [JsonPropertyName("width")]
            public int Width { get; set; }
        }
        public class Link
        {
            [JsonPropertyName("type")]
            public string Type { get; set; }
            [JsonPropertyName("url")]
            public string Url { get; set; }
            [JsonPropertyName("suggested_link_text")]
            public string SuggestedLinkText { get; set; }
        }
    }
}