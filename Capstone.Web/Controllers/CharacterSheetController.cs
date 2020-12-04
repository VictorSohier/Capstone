using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Core.Models;
using Capstone.Infrastructure.Interfaces;
using Capstone.Infrastructure.Models;
using Capstone.Web.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Capstone.Web.Controllers
{
    public class CharacterSheetController : Controller
    {
        private IRepository<Author> _AuthorRepository;
        private IRepository<CharacterSheet> _CharacterSheetRepository;
        private IRepository<Comment> _CommentsRepository;
        private UserManager<CapstoneUser> _UserManager;

        public CharacterSheetController(
            IRepository<Author> authorRepository,
            IRepository<CharacterSheet> characterSheetRepository,
            IRepository<Comment> commentsRepository,
            UserManager<CapstoneUser> userManager
            )
        {
            _AuthorRepository = authorRepository;
            _CharacterSheetRepository = characterSheetRepository;
            _CommentsRepository = commentsRepository;
            _UserManager = userManager;
        }

        // GET: CharacterSheetController
        public async Task<IActionResult> Index()
        {
            List<CharacterSheet> sheets = await _CharacterSheetRepository
                .ReadAll()
                .Include(e => e.Author)
                .ToListAsync();
            return View(sheets);
        }

        // GET: CharacterSheetController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            CharacterSheet model = (await _CharacterSheetRepository
                .ReadFilteredAsync(e => e.Id == id))
                .Include(e => e.Author)
                .Include(e => e.Comments)
                .FirstOrDefault();
            if (model != null)
                return View(model);
            else
                return NotFound();
        }

        // GET: CharacterSheetController/Create
        [Authorize(Roles = "StdUser")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: CharacterSheetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "StdUser")]
        public async Task<IActionResult> Create(VMCharacterSheet vmcs)
        {
            if (ModelState.IsValid)
            {
                CharacterSheet model = vmcs;
                model.Author = (await _AuthorRepository.ReadFilteredAsync(e => e.Id == _UserManager.GetUserId(User))).Single();
                model.Author.CharacterSheets.Add(model);
                try
                {
                    await _CharacterSheetRepository.WriteAsync(model);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        // GET: CharacterSheetController/Edit/5
        [Authorize(Roles = "StdUser")]
        public async Task<IActionResult> Edit(string id)
        {
            CharacterSheet model = (await _CharacterSheetRepository.ReadFilteredAsync(e => e.Id == id)).Single();
            if (model != null && model.Author.Id == _UserManager.GetUserId(User))
                return View((VMCharacterSheet) model);
            else if (model.Author.Id != _UserManager.GetUserId(User))
            {
                return Forbid();
            }
            else
                return NotFound();
        }

        // POST: CharacterSheetController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "StdUser")]
        public async Task<IActionResult> Edit(string id, VMCharacterSheet vmcs)
        {
            CharacterSheet model = vmcs;
            model.Author = (await _UserManager.GetUserAsync(User)).AuthoredItems;
            if (ModelState.IsValid && model.Author.Id == _UserManager.GetUserId(User))
            {
                try
                {
                    _CharacterSheetRepository.Update(model);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        // GET: CharacterSheetController/Delete/5
        [Authorize(Roles = "StdUser")]
        public async Task<IActionResult> Delete(string id)
        {
            return View((await _CharacterSheetRepository.ReadFilteredAsync(e => e.Id == id)).Single());
        }

        // POST: CharacterSheetController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "StdUser")]
        public async Task<IActionResult> Delete(string id, IFormCollection collection)
        {
            try
            {
                CharacterSheet sheet = (await _CharacterSheetRepository.ReadFilteredAsync(e => e.Id == id)).Single();
                Author author = (await _UserManager.GetUserAsync(User)).AuthoredItems;
                author.CharacterSheets.Remove(sheet);
                await _CommentsRepository.DeleteManyAsync(sheet.Comments);
                await _CharacterSheetRepository.DeleteAsync(sheet);
                _AuthorRepository.Update(author);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
