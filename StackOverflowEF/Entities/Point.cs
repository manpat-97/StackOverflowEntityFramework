using System.ComponentModel.DataAnnotations;

namespace StackOverflowEF.Entities
{
    public class Point
    {
        public int Id { get; set; }
        [Range(-1,1)]
        public int Value { get; set; }
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
        public virtual Question Question { get; set; }
        public int? QuestionId { get; set; }
        public virtual Answer Answer { get; set; }
        public int? AnswerId { get; set; }
    }
}
