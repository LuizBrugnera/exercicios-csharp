using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciciosTooC_.ExPost
{
    internal class Post
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Moment { get; private set; }
        public int Likes { get; private set; }
        public List<Comment> Comments { get; private set; } = new List<Comment>();

        public Post()
        {
        }

        public Post(string title, string content, DateTime moment)
        {
            Title = title;
            Content = content;
            Moment = moment;
            Likes = 0;
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public void RemoveComment(Comment comment)
        {
            Comments.Remove(comment);
        }

        public void Like()
        {
            Likes++;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Title);
            sb.Append(Likes);
            sb.Append(" Likes - ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine(Content);
            sb.AppendLine("Comments:");
            foreach (Comment c in Comments)
            {
                sb.AppendLine(c.Text);
            }
            return sb.ToString();
        }
    }
}
