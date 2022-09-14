<<<<<<<< HEAD:tests/StudyFriendTests/DataTests.cs
﻿using StudyFriend.Data;
using StudyFriend.Models;
========
﻿using StudyJourney.Data;
using StudyJourney.Models;
>>>>>>>> develop:tests/StudyJourneyTests/DataTests.cs
using System.Linq;
using Xunit;

namespace StudyFriendTests
{
    public class DataTests
    {
        [Fact]
        public void FindTopic_ByUserId()
        {
            using (var db = new StudyFriendContext(Utilities.TestDbContextOptions()))
            {
                string user_id = "test_id";
                var topics = new Topic[]
                {
                    new Topic { Name = "JavaScript", UserId = user_id}
                };
                foreach (Topic t in topics)
                {
                    db.Topic.Add(t);
                }
                db.SaveChanges();

                var topic = (from t in db.Topic
                             where t.UserId == user_id
                             select t).Single();

                Assert.Equal(topic.UserId, user_id);
            }
        }
    }
}
