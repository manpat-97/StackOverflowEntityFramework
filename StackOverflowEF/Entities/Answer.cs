namespace StackOverflowEF.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Score { get; set; }
        public virtual List<Point> Points { get; set; }
        public virtual Question Question { get; set; }
        public int QuestionId { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
    }
}
