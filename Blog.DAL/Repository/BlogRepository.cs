using System.Collections.Generic;
using Blog.DAL.Infrastructure;
using Blog.DAL.Model;
using System;
using System.Linq;

namespace Blog.DAL.Repository
{
    public class BlogRepository
    {
        private readonly BlogContext _context;

        public BlogRepository()
        {
            _context = new BlogContext();
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Posts;
        }
        public void AddPost(string author, string content)
        {
            _context.Posts.Add(new Post { Author = author, Content = content });
            _context.SaveChanges();
        }
        public void AddComment(string author, string content, long postId)
        {
            _context.Comments.Add(new Comment { Author = author, Content = content, PostId = postId});
            _context.SaveChanges();
        }
        public IEnumerable<Comment> GetCommentsForPost(long postId)
        {
            return _context.Comments.Where(x => x.PostId == postId);
        }
    }
}
