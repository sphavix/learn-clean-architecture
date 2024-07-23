namespace Movies.Core.Entities
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string DirectorName { get; set; }
        public string ReleaseYear { get; set; }
    }
}