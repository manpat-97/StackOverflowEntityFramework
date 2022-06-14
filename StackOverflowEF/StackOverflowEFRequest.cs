using FluentValidation;
using Microsoft.EntityFrameworkCore;
using StackOverflowEF.Dto;
using StackOverflowEF.Entities;

namespace StackOverflowEF
{
    public static class StackOverflowEFRequest
    {
        public static WebApplication RegisterEndpoints(this WebApplication app)
        {
            app.MapGet("questionsscore", (StackOverflowContext db) =>
            {
                var questions = db.ViewQuestionsWithScore.ToList();
                return questions;
            });

            app.MapPost("questions/points/{questionId}", AddQuestionPoint)
                .WithTags("Points");
            app.MapPost("questions/answers/points/{answerId}", AddAnswerPoint)
                .WithTags("Points");

            app.MapGet("questions", StackOverflowEFRequest.GetAllQuestions)
                .WithTags("Questions");
            app.MapGet("questions/{id}", StackOverflowEFRequest.GetQuestionById)
                .WithTags("Questions");
            app.MapPost("questions", StackOverflowEFRequest.CreateQuestion)
                .WithTags("Questions");
            app.MapPut("questions/{id}", StackOverflowEFRequest.UpdateQuestion)
                .WithTags("Questions");
            app.MapDelete("questions/{id}", StackOverflowEFRequest.DeleteQuestion)
                .WithTags("Questions");

            app.MapGet("questions/answers/{id}", StackOverflowEFRequest.GetAnswerById)
                .WithTags("Answers");
            app.MapPost("questions/answers/{questionId}", StackOverflowEFRequest.CreateAnswer)
                .WithTags("Answers");
            app.MapPut("questions/answers/{answerId}", StackOverflowEFRequest.UpdateAnswer)
                .WithTags("Answers");
            app.MapDelete("questions/answers/{answerId}", StackOverflowEFRequest.DeleteAnswer)
                .WithTags("Answers");

            app.MapGet("questions/comments/{id}", StackOverflowEFRequest.GetQuestionCommentById)
                .WithTags("Question comments");
            app.MapPost("questions/comments/{questionId}", StackOverflowEFRequest.CreateQuestionComment)
                .WithTags("Question comments");
            app.MapPut("questions/comments/{commentId}", StackOverflowEFRequest.UpdateQuestionComment)
                .WithTags("Question comments");
            app.MapDelete("questions/comments/{commentId}", StackOverflowEFRequest.DeleteQuestionComment)
                .WithTags("Question comments");

            app.MapGet("questions/answers/comments/{id}", StackOverflowEFRequest.GetAnswerCommentById)
                .WithTags("Answer comments");
            app.MapPost("questions/answers/comments/{answerId}", StackOverflowEFRequest.CreateAnswerComment)
                .WithTags("Answer comments");
            app.MapPut("questions/answers/comments/{commentId}", StackOverflowEFRequest.UpdateAnswerComment)
                .WithTags("Answer comments");
            app.MapDelete("questions/answers/comments/{commentId}", StackOverflowEFRequest.DeleteAnswerComment)
                .WithTags("Answer comments");
            return app;
        }

        public static IResult GetAllQuestions(StackOverflowContext db)
        {
            var questions = db.Questions
                .Include(q => q.Answers)
                .Include(q => q.Tags)
                .Include(q => q.User)
                .Select(q => new { q.Id, q.Title,
                    CreatedDate = q.CreatedDate.ToString("g"), 
                    NumberOfAnswers = q.Answers.Count, AuthorName = q.User.Name, q.Tags })
                .ToList();
            return Results.Ok(questions);
        }
        public static IResult GetQuestionById(StackOverflowContext db, int id)
        {
            var question = db.Questions
            .Include(q => q.Answers).ThenInclude(a => a.Comments).ThenInclude(c => c.User)
            .Include(q => q.Answers).ThenInclude(a => a.User)
            .Include(q => q.Tags)
            .Include(q => q.Comments).ThenInclude(c => c.User)
            .Include(q => q.User)
            .Select(q => new
            {
                q.Id,
                q.Title,
                q.Content,
                q.Score,
                CreatedDate = q.CreatedDate.ToString("g"),
                AuthorName = q.User.Name,
                Tags = q.Tags.Select(t => t.Name),
                Comments = q.Comments.Select(c => new
                {
                    c.Content,
                    AuthorName = c.User.Name,
                    CreatedDate = c.CreatedDate.ToString("g")
                }),
                Answers = q.Answers.Select(answer => new
                {
                    answer.Content,
                    AuthorName = answer.User.Name,
                    CreatedDate = answer.CreatedDate.ToString("g"),
                    answer.Score,
                    Comments = answer.Comments.Select(c => new
                    {
                        c.Content,
                        AuthorName = c.User.Name,
                        CreatedDate = c.CreatedDate.ToString("g")
                    })
                })
            })
            .FirstOrDefault(q => q.Id == id);

            if (question == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(question);
        }
        public static IResult CreateQuestion(StackOverflowContext db, QuestionDto questionDto, IValidator<QuestionDto> validator)
        {
            var validationResult = validator.Validate(questionDto);
            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }
            var userId = Guid.Parse("0B72E7C5-6C7A-42CA-B6C4-687CDC937D98");
            var tag = db.Tags.First(t => t.Id == 1);

            var question = new Question()
            {
                Title = questionDto.Title,
                Content = questionDto.Content,
                UserId = userId,
                Tags = new List<Tag>()
            };
            question.Tags.Add(tag);

            db.Questions.Add(question);
            db.SaveChanges();
            return Results.Created($"questions/{question.Id}", question);
        }
        public static IResult UpdateQuestion(StackOverflowContext db, int id, QuestionUpdateDto questionDto)
        {
            var questionDb = db.Questions
              .Include(q => q.Tags)
              .FirstOrDefault(q => q.Id == id);
            if (questionDb == null)
            {
                return Results.NotFound();
            }

            if (questionDto.QuestionDto != null)
            {
                if (questionDto.QuestionDto.Title != null)
                {
                    questionDb.Title = questionDto.QuestionDto.Title;
                }
                if (questionDto.QuestionDto.Content != null)
                {
                    questionDb.Content = questionDto.QuestionDto.Content;
                }
            }

            var dbTags = db.Tags.ToList();
            if (questionDto.Tags != null)
            {
                foreach (var tag in questionDto.Tags)
                {
                    if (questionDb.Tags.FirstOrDefault(t => t.Name == tag.Name) is null)
                    {
                        var dbTag = dbTags.FirstOrDefault(t => t.Name == tag.Name);
                        if (dbTag is null)
                        {
                            var newTag = new Tag() { Name = tag.Name };
                            questionDb.Tags.Add(newTag);
                        }
                        else
                        {
                            questionDb.Tags.Add(dbTag);
                        }
                    }
                }
            }
            db.SaveChanges();
            return Results.NoContent();
        }
        public static IResult DeleteQuestion(StackOverflowContext db, int id)
        {
            var question = db.Questions
               .Include(q => q.Answers).ThenInclude(a => a.Comments)
               .Include(q => q.Comments)
               .Include(q => q.Points)
               .Include(q=>q.Tags)
               .First(q => q.Id == id);
            if (question == null)
            {
                return Results.NotFound();
            }
            db.Questions.Remove(question);
            db.SaveChanges();
            return Results.NoContent();
        }

        public static IResult GetAnswerById(StackOverflowContext db, int id)
        {
            var answer = db.Answers.FirstOrDefault(a => a.Id == id);
            if(answer == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(answer);
        }
        public static IResult CreateAnswer(StackOverflowContext db, int questionId, AnswerDto answerDto)
        {
            var userId = Guid.Parse("0B72E7C5-6C7A-42CA-B6C4-687CDC937D98");
            var newAnswer = new Answer()
            {
                Content = answerDto.Content,
                UserId = userId,
            };

            var question = db.Questions
            .Include(q => q.Answers)
            .FirstOrDefault(q => q.Id == questionId);
            if (question == null)
            {
                return Results.NotFound();
            }
            question.Answers.Add(newAnswer);
            db.SaveChanges();
            return Results.Created($"questions/answers/{newAnswer.Id}", newAnswer);
        }
        public static IResult UpdateAnswer(StackOverflowContext db, int answerId, AnswerDto answerDto)
        {
            var answer = db.Answers.FirstOrDefault(a => a.Id == answerId);
            if (answer == null)
            {
                return Results.NotFound();
            }
            answer.Content = answerDto.Content;
            db.SaveChanges();
            return Results.NoContent();
        }
        public static IResult DeleteAnswer(StackOverflowContext db, int answerId)
        {
            var answer = db.Answers
                .Include(a=>a.Comments)
                .Include(a=>a.Points)
                .FirstOrDefault(a => a.Id == answerId);

            if (answer == null)
            {
                return Results.NotFound();
            }
            db.Remove(answer);
            db.SaveChanges();
            return Results.NoContent();
        }

        public static IResult GetQuestionCommentById(StackOverflowContext db, int id)
        {
            var comment = db.Comments.FirstOrDefault(c => c.Id == id);
            if(comment == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(comment);
        }
        public static IResult CreateQuestionComment(StackOverflowContext db, int questionId, CommentDto commentDto)
        {
            var userId = Guid.Parse("1B55D748-2ED4-4092-A1CC-A26C430D9D5E");
            var newComment = new Comment()
            {
                Content = commentDto.Content,
                UserId = userId,
                QuestionId = questionId
            };
            var question = db.Questions
            .Include(q => q.Comments)
            .FirstOrDefault(q => q.Id == questionId);
            if(question == null)
            {
                return Results.NotFound();
            }
            question.Comments.Add(newComment);
            db.SaveChanges();
            return Results.Created($"questions/comments/{newComment.Id}", newComment);
        }
        public static IResult UpdateQuestionComment(StackOverflowContext db, int commentId, CommentDto commentDto)
        {
            var comment = db.Comments.FirstOrDefault(c => c.Id == commentId);
            if(comment == null)
            {
                return Results.NotFound();
            }
            comment.Content = commentDto.Content;
            db.SaveChanges();
            return Results.NoContent();
        }
        public static IResult DeleteQuestionComment(StackOverflowContext db, int commentId)
        {
            var comment = db.Comments.FirstOrDefault(c => c.Id == commentId);
            if(comment == null)
            {
                return Results.NotFound();
            }
            db.Remove(comment);
            db.SaveChanges();
            return Results.NoContent();
        }

        public static IResult GetAnswerCommentById(StackOverflowContext db, int id)
        {
            var comment = db.Comments.FirstOrDefault(c => c.Id == id);
            if (comment == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(comment);
        }
        public static IResult CreateAnswerComment(StackOverflowContext db, int answerId, CommentDto commentDto)
        {
            var answer = db.Answers
            .Include(a => a.Comments)
            .FirstOrDefault(a => a.Id == answerId);
            if (answer == null)
            {
                return Results.NotFound();
            }

            var userId = Guid.Parse("1B55D748-2ED4-4092-A1CC-A26C430D9D5E");
            var newComment = new Comment()
            {
                Content = commentDto.Content,
                UserId = userId,
                AnswerId = answerId
            };

            answer.Comments.Add(newComment);
            db.SaveChanges();
            return Results.Created($"answers/comments/{newComment.Id}", newComment);
        }
        public static IResult UpdateAnswerComment(StackOverflowContext db, int commentId, CommentDto commentDto)
        {
            var comment = db.Comments.FirstOrDefault(c => c.Id == commentId);
            if(comment == null)
            {
                return Results.NotFound();
            }
            comment.Content = commentDto.Content;
            db.SaveChanges();
            return Results.NoContent();
        }
        public static IResult DeleteAnswerComment(StackOverflowContext db, int commentId)
        {
            var comment = db.Comments.FirstOrDefault(c => c.Id == commentId);
            if(comment == null)
            {
                return Results.NotFound();
            }
            db.Remove(comment);
            db.SaveChanges();
            return Results.NoContent();
        }

        public static IResult AddQuestionPoint(StackOverflowContext db, int questionId)
        {
            //Ustawia flage w zaleznosci, ktora strzalka zostala kliknieta w glosowaniu up(true), down(false)
            var arrowAttribute = false;
            var exampleUserId = Guid.Parse("0B72E7C5-6C7A-42CA-B6C4-687CDC937D98");

            var userPoint = db.Points.Include(p => p.Question)
            .FirstOrDefault(p => (p.UserId == exampleUserId && p.QuestionId == questionId));

            if (userPoint == null)
            {
                var pointValue = arrowAttribute ? 1 : -1;
                var newPoint = new Point() { QuestionId = questionId, UserId = exampleUserId, Value = pointValue };
                var question = db.Questions.First(q => q.Id == newPoint.QuestionId);
                question.Score += newPoint.Value;
                db.Points.Add(newPoint);
            }
            else
            {
                switch (userPoint.Value, arrowAttribute)
                {
                    case (1, true):
                        break;
                    case (1, false):
                        userPoint.Value = -1;
                        userPoint.Question.Score -= 2;
                        break;
                    case (-1, true):
                        userPoint.Value = 1;
                        userPoint.Question.Score += 2;
                        break;
                    case (-1, false):
                        break;
                    default:
                        break;
                }
            }
            db.SaveChanges();
            return Results.NoContent();
        }
        public static IResult AddAnswerPoint(StackOverflowContext db, int answerId)
        {
            var arrowAttribute = true;
            var exampleUserId = Guid.Parse("0B72E7C5-6C7A-42CA-B6C4-687CDC937D98");

            var userPoint = db.Points.Include(p => p.Answer)
            .FirstOrDefault(p => (p.UserId == exampleUserId && p.AnswerId == answerId));

            if (userPoint == null)
            {
                var pointValue = arrowAttribute ? 1 : -1;
                var newPoint = new Point() { AnswerId = answerId, UserId = exampleUserId, Value = pointValue };
                var answer = db.Answers.First(a => a.Id == newPoint.AnswerId);
                answer.Score += newPoint.Value;
                db.Points.Add(newPoint);
            }
            else
            {
                switch (userPoint.Value, arrowAttribute)
                {
                    case (1, true):
                        break;
                    case (1, false):
                        userPoint.Value = -1;
                        userPoint.Question.Score -= 2;
                        break;
                    case (-1, true):
                        userPoint.Value = 1;
                        userPoint.Question.Score += 2;
                        break;
                    case (-1, false):
                        break;
                    default:
                        break;
                }
            }
            db.SaveChanges();
            return Results.NoContent();
        }
    }
}
