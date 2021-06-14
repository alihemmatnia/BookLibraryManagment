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

        public IActionResult Index()
        {
            ViewBag.StudentsCout = _student.GetAll().Count();   
            return View(_Books.GetAll());
        }

        #region Books

        [HttpGet]
        [Route("/AddBook")]
        public IActionResult AddBook()
        {
            ViewData["Category"] = new SelectList(_category.GetAll(), "CategoryId", "Title");
            return View();
        }

        [HttpPost]
        [Route("/AddBook")]
        public IActionResult AddBook(AddBookDto dto, IFormFile imgup)
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
                    imgup.CopyTo(st);
                }

                _Books.AddBook(NewBook);
                _Books.Save();

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
        public IActionResult BookDel()
        {
            return View(_Books.GetAll());
        }

        [HttpGet]
        [Route("/BookDell")]
        public IActionResult BookDell(long Id)
        {
            if (Id != null)
            {
                _Books.Delete(Id);
                _Books.Save();
                return Redirect("/BookDel");
            }
            return Redirect("/BookDel");
        }

        [HttpGet]
        [Route("/BookUpdate")]
        public IActionResult BookUpdate()
        {
            return View(_Books.GetAll());
        }

        [HttpGet]
        [Route("/BookUpdatee")]
        public IActionResult BookUpdatee(long Id)
        {
            if (Id != null)
            {
                ViewData["Category"] = new SelectList(_category.GetAll(), "CategoryId", "Title");

                return View(_Books.GetById(Id));
            }
            return Redirect("/BookUpdate");
        }

        [HttpPost]
        [Route("/BookUpdatee")]
        public IActionResult BookUpdatee(Books dto, IFormFile imgup)
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
                            imgup.CopyTo(st);
                        }
                    }
                    _Books.Edit(dto);
                    _Books.Save();
                    return Redirect("/BookUpdate");

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_Books.GetById(dto.BookId)==null)
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
        public IActionResult Receivership(AddReceivershipDto dto)
        {
            if (ModelState.IsValid)
            {
                bool st = _Books.Receivership(dto);
                if (st)
                {
                    _Books.Save();
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
        public IActionResult BackBook(AddReceivershipDto dto)
        {
            if (ModelState.IsValid)
            {
                bool st = _Books.BackBook(dto);
                if (st)
                {
                    _Books.Save();
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
        public IActionResult ReceivershipList()
        {
            var books = _Books.GetReceivershipList();
            return View(books);
        }


        #endregion


        #region Category


        [HttpGet]
        [Route("/Category")]
        public IActionResult Category()
        {
            return View(_category.GetAll());
        }

        [HttpGet("/CategoryDel")]
        public IActionResult DeleteCategory([FromQuery] long Id)
        {
            if (Id != null)
            {
                _category.Delete(Id);
                _category.Save();
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
        public IActionResult AddCategory(AddCategoryDto dto)
        {
            if (ModelState.IsValid)
            {
                _category.AddCategory(dto);
                _category.Save();
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
        public IActionResult AddStudent(AddStudentDto dto)
        {
            if (ModelState.IsValid)
            {
                _student.AddStudent(dto);
                _student.Save();
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
        public IActionResult StudentsDel()
        {
            return View(_student.GetAll());
        }

        [HttpGet]
        [Route("/StudentDell")]
        public IActionResult StudentsDell(long Id)
        {
            if (Id != null)
            {
                _student.Delete(Id);
                _student.Save();
                ViewBag.Mode = "success";
                ViewBag.Message = "با موفقیت حذف شد";
                return Redirect("/StudentDel");
            }
            return Redirect("/StudentDel");

        }

        [HttpGet]
        [Route("/StudentUpdate")]
        public IActionResult StudentUpdate()
        {
            return View(_student.GetAll());
        }

        [HttpGet]
        [Route("/StudentUpdatee")]
        public IActionResult StudentUpdatee(long Id)
        {
            if (Id != null)
            {
                return View(_student.GetById(Id));
            }
            return Redirect("/StudentUpdate");
        }

        [HttpPost]
        [Route("/StudentUpdatee")]
        public IActionResult StudentUpdatee(Students dto)
        {
            if (ModelState.IsValid)
            {
                _student.Edit(dto);
                _student.Save();
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
        public IActionResult Users()
        {
            return View(_userManager.Users.ToList());
        }

        [HttpGet]
        [Route("/NewUser")]
        [Authorize(Roles = "Admin")]
        public IActionResult NewUser()
        {
            return View();
        }

        [HttpPost]
        [Route("/NewUser")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> NewUser(AddUserDto model)
        {
            IdentityUser user = new IdentityUser()
            {
                UserName = model.Username,
                Email = model.Email,
                PhoneNumber=model.PhoneNumber,
                PhoneNumberConfirmed=true,
                EmailConfirmed = true
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
