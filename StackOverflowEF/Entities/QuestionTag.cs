namespace StackOverflowEF.Entities
{
    public class QuestionTag
    {
        public virtual Question Question { get; set; }
        public int QuestionId { get; set; }
        public virtual Tag Tag { get; set; }
        public int TagId { get; set; }
    }
}
