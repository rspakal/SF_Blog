﻿namespace HedonismBlog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; }
        public User User { get; set; }
        public Post Post { get; set; }
    }
}
