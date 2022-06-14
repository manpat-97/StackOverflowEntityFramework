namespace StackOverflowEF.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Score { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual List<Point> Points { get; set; }
        public virtual List<Tag> Tags { get; set; }
        public virtual List<Answer> Answers { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
       
    }
}
