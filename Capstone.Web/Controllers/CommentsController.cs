using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Core.Interfaces;
using Capstone.Core.Models;
using Capstone.Infrastructure.Interfaces;
using Capstone.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Capstone.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private IRepository<Comment> _CommentsRepository;
        private IRepository<ICommentable> _CommentableRepository;
        private IRepository<Author> _AuthorsRepository;
        private UserManager<CapstoneUser> _UserManager;

        public CommentsController(
            IRepository<Comment> commentsRepository,
            IRepository<ICommentable> commentableRepository,
            IRepository<Author> authorsRepository,
            UserManager<CapstoneUser> userManager
            )
        {
            _CommentsRepository = commentsRepository;
            _CommentableRepository = commentableRepository;
            _AuthorsRepository = authorsRepository;
            _UserManager = userManager;
        }

        // GET: api/<CommentsApiController>
        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            return new JsonResult(_CommentsRepository.ReadFilteredAsync(e => e.Parent.Id == id));
        }

        // POST api/<CommentsApiController>
        [HttpPost]
        public async Task Post(string parentId, string content)
        {
            Comment comment = new Comment
            {
                Substance = HttpUtility.HtmlEncode(content)
            };
            comment.Parent = (await _CommentableRepository.ReadFilteredAsync(e => e.Id == parentId)).Single();
            comment.Author = (await _AuthorsRepository.ReadFilteredAsync(e => e.Id == _UserManager.GetUserId(User))).Single();
            comment.Author.Comments.Add(comment);
            if (ModelState.IsValid)
            {
                await _CommentsRepository.WriteAsync(comment);
            }
        }

        // PUT api/<CommentsApiController>/5
        [HttpPut("{id}")]
        public async Task Put([FromBody] Comment comment)
        {
            Author author = (await _AuthorsRepository.ReadFilteredAsync(e => e.Id == comment.Author.Id)).Single();
            string userId = _UserManager.GetUserId(User);
            if (ModelState.IsValid && author.Id == userId)
            {
                _CommentsRepository.Update(comment);
            }
        }

        // DELETE api/<CommentsApiController>/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            Comment comment = (await _CommentsRepository.ReadFilteredAsync(e => e.Id == id)).Single();
            Author author = (await _AuthorsRepository.ReadFilteredAsync(e => e.Comments.Where(e => e.Id == id).Count() > 0)).Single();
            author.Comments.Remove(comment);
            _AuthorsRepository.Update(author);
            _CommentsRepository.Delete(comment);
        }
    }
}