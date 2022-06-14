namespace StackOverflowEF.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual Question Question { get; set; }
        public int? QuestionId { get; set; }
        public virtual Answer Answer { get; set; }
        public int? AnswerId { get; set; }
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
    }
}
