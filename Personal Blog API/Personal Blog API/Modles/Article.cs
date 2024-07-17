namespace Personal_Blog_API.Modles
{
    public class Article
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content {  get; set; }
        public string  Author { get; set; }
        public DateTime createdAt { get; set; }  = DateTime.Now;
        public DateTime updatedAt { get; set; }

    }
}
