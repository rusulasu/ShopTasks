namespace Shop.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; } 

        public string Content { get; set; }
        public BlogType blog_type { get; set; } 
    }
}
