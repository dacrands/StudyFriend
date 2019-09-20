namespace StudyFriend.Models
{
    public static class DbInitializer
    {
        public static void Initialize(StudyFriendContext context)
        {
            context.Database.EnsureCreated();
            // If any Questions exist, don't reseed the DB

            if (true)
            {
                return;
            }


            

            var topics = new Topic[]
            {
                new Topic { Name = "Life"}
            };
            foreach (Topic t in topics)
            {
                context.Topic.Add(t);
            }
            context.SaveChanges();

            
            var questions = new Question[]
            {
                new Question{ Body="Will this even work?", TopicID=1 }
            };
            foreach (Question q in questions)
            {
                context.Question.Add(q);
            }
            context.SaveChanges();

            var answers = new Answer[]
            {
                new Answer { QuestionID = 1, Body ="Probably not" }
            };
            foreach (Answer a in answers)
            {
                context.Answer.Add(a);
            }
            context.SaveChanges();
        }
    }
}
