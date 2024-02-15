using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
    public class DashBoardController : Controller
    {

        private static List<Company> _company = new List<Company>();
        private static List<Product> _products = new List<Product>();
        private static List<Blog> _blogs = new List<Blog>();

        private readonly ApplicationDbContext _db;

        public DashBoardController(ApplicationDbContext db)
        {
            _db = db;
            _company.Add(new Company { Id = 1, Name = "Nike" });
            _company.Add(new Company { Id = 2, Name = "Adidas" });

          
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();

        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {

            _db.products.Add(product);
            _db.SaveChanges();

            return View();


        }

        #region GetAll
        public IActionResult GetAllData()
        {
            var product = _db.products.Include(p => p.company).ToList(); // var cause we return list (ToList())
            return View(product);

        }
        #endregion

        #region DeleteProduct

        public IActionResult Delete(int id)
        {

            Product? product = _db.products.SingleOrDefault(x => x.Id == id);
            _db.products.Remove(product);
            _db.SaveChanges();


            return RedirectToAction("GetAllData");

        }
        #endregion


        #region EditProduct

        public IActionResult Edit(int id)
        {
            Product product = _db.products.SingleOrDefault(x => x.Id == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            Product pd = _db.products.SingleOrDefault(p=>p.Id==product.Id);

            pd.Price = product.Price;
            pd.Quantity = product.Quantity;
            pd.EnableSize = product.EnableSize;
            pd.Name = product.Name;
            pd.Description = product.Description;
            pd.CompanyId = product.CompanyId;

            _db.products.Update(pd);
            _db.SaveChanges();
            return RedirectToAction("GetAllData");
        }


        #endregion


        #region AddBlog

        public IActionResult AddBlog()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {

            _db.blogs.Add(blog);
            _db.SaveChanges();


            return RedirectToAction("Index");
        }


        #endregion


        #region ShowAllBlogs

        public IActionResult ShowAllBlogs()
        {
            var blog = _db.blogs.Include(p=>p.blog_type).ToList();
            return View(blog);
        }


        #endregion


        #region EditBlog

        public IActionResult EditBlog(int id)
        {
            Blog blog = _db.blogs.SingleOrDefault(x => x.Id == id);
            return View(blog);
        }


        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            Blog bg = _db.blogs.SingleOrDefault(g => g.Id == blog.Id);

            bg.Title = blog.Title;
            bg.Content = blog.Content;
            bg.TypeId = blog.TypeId;
                
            _db.blogs.Update(bg);
            _db.SaveChanges();

            return RedirectToAction("ShowAllBlogs");
        }




        #endregion

        #region BlogDelete

        public IActionResult DeleteBlog(int id)
        {
            Blog? blog = _db.blogs.SingleOrDefault(x => x.Id == id);

            _db.blogs.Remove(blog);
            _db.SaveChanges();

            return RedirectToAction("ShowAllBlogs");
        }

        #endregion
    }
}