using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Book.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Book.Services.Categoryy;
using Book.Dtos;
using Microsoft.AspNetCore.Http;
using Book.Data;
using System.IO;
using Book.Services.Book;
using Book.Services.Student;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Book.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryRepository _category;
        private readonly IBookRepository _Books;
        private readonly IStudentRepository _student;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signmanager;
        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signmanager,ILogger<HomeController> logger, IBookRepository books, ICategoryRepository category, IStudentRepository student)
        {
            _logger = logger;
            _Books = books;
            _userManager = userManager;
            _category = category;
            _signmanager = signmanager;
            _student = student;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.StudentsCout = _student.GetAll().Result.Count;
            return View(await _Books.GetAll());
        }

        #region Books

        [HttpGet]
        [Route("/AddBook")]
        public async Task<IActionResult> AddBook()
        {
            ViewData["Category"] = new SelectList(await _category.GetAll(), "CategoryId", "Title");
            return View();
        }

        [HttpPost]
        [Route("/AddBook")]
        public async Task<IActionResult> AddBook(AddBookDto dto, IFormFile imgup)
        {
            if (ModelState.IsValid)
            {
                Books NewBook = new Books();
                NewBook.Author = dto.Author;
                NewBook.Content = dto.Content;
                NewBook.Title = dto.Title;
                NewBook.Status = false;
                NewBook.PublishDate = dto.PublishDate;
                NewBook.CreateDate = DateTime.Now;
                NewBook.CategoryId = dto.CategoryId;

                NewBook.Image = Guid.NewGuid().ToString() + Path.GetExtension(imgup.FileName);
                string savepath = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot/Images", NewBook.Image
                );
                using (FileStream st = new FileStream(savepath, FileMode.Create))
                {
                    await imgup.CopyToAsync(st);
                }

                await _Books.AddBook(NewBook);
                await _Books.Save();

                ViewData["message"] = "با موفقیت اضافه شد ";
                return Redirect("/");

            }
            else
            {
                return View(dto);
            }

        }

        [HttpGet]
        [Route("/BookDel")]
        public async Task<IActionResult> BookDel()
        {
            return View(await _Books.GetAll());
        }

        [HttpGet]
        [Route("/BookDell")]
        public async Task<IActionResult> BookDell(long Id)
        {
            if (Id != null)
            {
                await _Books.Delete(Id);
                await _Books.Save();
                return Redirect("/BookDel");
            }
            return Redirect("/BookDel");
        }

        [HttpGet]
        [Route("/BookUpdate")]
        public async Task<IActionResult> BookUpdate()
        {
            return View(await _Books.GetAll());
        }

        [HttpGet]
        [Route("/BookUpdatee")]
        public async Task<IActionResult> BookUpdatee(long Id)
        {
            if (Id != null)
            {
                ViewData["Category"] = new SelectList(await _category.GetAll(), "CategoryId", "Title");

                return View(await _Books.GetById(Id));
            }
            return Redirect("/BookUpdate");
        }

        [HttpPost]
        [Route("/BookUpdatee")]
        public async Task<IActionResult> BookUpdatee(Books dto, IFormFile imgup)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (imgup != null)
                    {
                        if (dto.Image == null)
                        {
                            dto.Image = Guid.NewGuid().ToString() + Path.GetExtension(imgup.FileName);
                        }
                        string savepath = Path.Combine(
                                Directory.GetCurrentDirectory(), "wwwroot/Images", dto.Image
                            );
                        using (FileStream st = new FileStream(savepath, FileMode.Create))
                        {
                            await imgup.CopyToAsync(st);
                        }
                    }
                     _Books.Edit(dto);
                    await _Books.Save();
                    return Redirect("/BookUpdate");

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _Books.GetById(dto.BookId)==null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return Redirect("/BookUpdate");
        }

        [HttpGet]
        [Route("/Receivership")]
        public IActionResult Receivership()
        {
            return View();
        }

        [HttpPost]
        [Route("/Receivership")]
        public async Task<IActionResult> Receivership(AddReceivershipDto dto)
        {
            if (ModelState.IsValid)
            {
                bool st = await _Books.Receivership(dto);
                if (st)
                {
                    await _Books.Save();
                    ViewBag.Mode = "success";
                    ViewBag.Message = "با موفقیت امانت داده شد ";
                    return View();
                }
                else
                {
                    ViewBag.Mode = "error";
                    ViewBag.Message = "این کتاب در امانت است";
                    //ModelState.AddModelError("", "این کتاب در امانت است ");
                    return View();

                }

            }

            else { return View(dto); }
        }


        [HttpGet]
        [Route("/BackBook")]
        public IActionResult BackBook()
        {
            return View();
        }

        [HttpPost]
        [Route("/BackBook")]
        public async Task<IActionResult> BackBook(AddReceivershipDto dto)
        {
            if (ModelState.IsValid)
            {
                bool st =await _Books.BackBook(dto);
                if (st)
                {
                    await _Books.Save();
                    ViewBag.Mode = "success";
                    ViewBag.Message = "با موفقیت پس گرفته شد";
                    return View();
                }
                else
                {
                    ViewBag.Mode = "error";
                    ViewBag.Message = "این کتاب در امانت نیست";
                    //ModelState.AddModelError("", "این کتاب در امانت نیست ");
                    return View();

                }

            }

            else { 
                return View(dto); 
            }
        }

        [HttpGet]
        [Route("/ReceivershipList")]
        public async Task<IActionResult> ReceivershipList()
        {
            var books = await _Books.GetReceivershipList();
            return View(books);
        }


        #endregion


        #region Category


        [HttpGet]
        [Route("/Category")]
        public async Task<IActionResult> Category()
        {
            return View(await _category.GetAll());
        }

        [HttpGet("/CategoryDel")]
        public async Task<IActionResult> DeleteCategory([FromQuery] long Id)
        {
            if (Id != null)
            {
                await _category.Delete(Id);
                await _category.Save();
                return Redirect("/Category");
            }
            else
            {
                return Redirect("/Category");
            }

        }

        [HttpGet]
        [Route("/CategoryAdd")]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        [Route("/CategoryAdd")]
        public async Task<IActionResult> AddCategory(AddCategoryDto dto)
        {
            if (ModelState.IsValid)
            {
                await _category.AddCategory(dto);
                await _category.Save();
                ViewBag.Mode = "success";
                ViewBag.Message = "با موفقیت اضافه شد";
                return View();
            }
            else
            {
                return View(dto);
            }
        }
        #endregion


        #region Student


        [HttpGet]
        [Route("/StudentAdd")]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        [Route("/StudentAdd")]
        public async Task<IActionResult> AddStudent(AddStudentDto dto)
        {
            if (ModelState.IsValid)
            {
                await _student.AddStudent(dto);
                await _student.Save();
                ViewBag.Mode = "success";
                ViewBag.Message = "با موفقیت اضافه شد";
                return View();
            }
            else {
                return View(dto);

            }
        }

        [HttpGet]
        [Route("/StudentDel")]
        public async Task<IActionResult> StudentsDel()
        {
            return View(await _student.GetAll());
        }

        [HttpGet]
        [Route("/StudentDell")]
        public async Task<IActionResult> StudentsDell(long Id)
        {
            if (Id != null)
            {
                await _student.Delete(Id);
                await _student.Save();
                ViewBag.Mode = "success";
                ViewBag.Message = "با موفقیت حذف شد";
                return Redirect("/StudentDel");
            }
            return Redirect("/StudentDel");

        }

        [HttpGet]
        [Route("/StudentUpdate")]
        public async Task<IActionResult> StudentUpdate()
        {
            return View(await _student.GetAll());
        }

        [HttpGet]
        [Route("/StudentUpdatee")]
        public async Task<IActionResult> StudentUpdatee(long Id)
        {
            if (Id != null)
            {
                return View(await _student.GetById(Id));
            }
            return Redirect("/StudentUpdate");
        }

        [HttpPost]
        [Route("/StudentUpdatee")]
        public async Task<IActionResult> StudentUpdatee(Students dto)
        {
            if (ModelState.IsValid)
            {
                _student.Edit(dto);
                await _student.Save();
                ViewBag.Mode = "success";
                ViewBag.Message = "با موفقیت ویرایش شد";
                return View();
            }
            return View(dto);
        }


        #endregion

        #region Users

        [HttpGet]
        [Route("/Users")]
        [Authorize(Roles ="Admin")]
        // [AllowAnonymous]
        public async Task<IActionResult> Users()
        {
            return View(await _userManager.Users.ToListAsync());
        }

        [HttpGet]
        [Route("/NewUser")]
        [Authorize(Roles = "Admin")]
        // [AllowAnonymous]
        public IActionResult NewUser()
        {
            return View();
        }

        [HttpPost]
        [Route("/NewUser")]
        // [AllowAnonymous]

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> NewUser(AddUserDto model)
        {
            IdentityUser user = new IdentityUser()
            {
                UserName = model.Username,
                Email = model.Email,
                PhoneNumber=model.PhoneNumber,
                PhoneNumberConfirmed=true,
                EmailConfirmed = true,
            };
            IdentityResult res = await _userManager.CreateAsync(user: user, password: model.Password);
            if (res.Succeeded)
            {
                ViewData["Message"] = "با موفقیت ثبت نام شد";
                ViewData["Mode"] = "success";
            }
            foreach (IdentityError i in res.Errors)
            {
                ModelState.AddModelError("", i.Description);
            }
            return View(model);
        }

        [HttpGet]
        [Route("/UserDel")]
        public async Task<IActionResult> UserDel(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            await _userManager.DeleteAsync(user);
            return Redirect("/users");
        }

        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
