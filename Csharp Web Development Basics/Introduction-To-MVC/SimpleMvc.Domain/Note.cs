namespace SimpleMvc.Domain
{
    public class Note
    {
        public Note()
        {
        }

        public Note(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }

        public Note(string title, string content, int ownerId) : this(title, content)
        {
            this.OwnerId = ownerId;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int OwnerId { get; set; }

        public User Owner { get; set; }
    }
}