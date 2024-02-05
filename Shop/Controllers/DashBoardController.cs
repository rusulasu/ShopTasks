using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class DashBoardController : Controller // Why this controller "DashBoard"? To use it to display the frequently content
    {

        private static List<Product> _products = new List<Product>();
        private static List<Blog> _blogs = new List<Blog>();

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
            int id;
            if (_products.Count == 0)
            {
                id = 1;
            }
            else
            {
                id = _products.Max(x => x.Id) + 1;
            }
            product.Id = id;

            _products.Add(product);
            return RedirectToAction("index");
            // index means the main page for this controller,which is the DashBoard

        }

        #region GetAll
        public IActionResult GetAllData()
        {
            return View(_products);
            //View for what? array

            //Why without loop? 
            // while the controller provides the data to the view, the actual rendering, including any necessary loops
        }
        #endregion

        #region DeleteProduct

        public IActionResult Delete(int id)
        { // asp-acion of Delete tag

            Product product = _products.FirstOrDefault(x => x.Id == id);

            _products.Remove(product);

            return RedirectToAction("GetAllData");

        }
        #endregion


        #region EditProduct

        public IActionResult Edit(int id)
        {
            Product product = _products.FirstOrDefault(x => x.Id == id);
            return View(product); // To display all product details
                                  // with this id
                                  // on the web to see it and edit it
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            Product pd = _products.SingleOrDefault(c => c.Id == product.Id);
            //this method used to catch the index of the product that matched 
            // with the ID to update the info's at the same location

            if (pd != null)
            {
                pd.Price = product.Price;
                pd.Quantity = product.Quantity;
                pd.EnableSize = product.EnableSize;
                pd.Name = product.Name;
                pd.Description = product.Description;

                // Check if company is not null before accessing its Id
                if (pd.company != null)
                {
                    pd.company.Id = product.company.Id;
                }
            }

            return RedirectToAction("index");
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
            int id;
            if (_blogs.Count == 0)
            {
                id = 1;
            }
            else
            {
                id = _blogs.Max(x => x.Id) + 1;
            }
            blog.Id = id;
            _blogs.Add(blog);
            return RedirectToAction("index");
        }

        #endregion


        #region ShowAllBlogs

        public IActionResult ShowAllBlogs()
        {
            return View(_blogs);
        }


        #endregion


        #region EditBlog

        public IActionResult EditBlog(int id)
        {
            Blog blog = _blogs.FirstOrDefault(x => x.Id == id);
            return View(blog);
        }


        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            Blog bg = _blogs.SingleOrDefault(g => g.Id == blog.Id);

            if (bg != null)
            {
                bg.Title = blog.Title;
                bg.Content = blog.Content;

                if (bg.blog_type != null)
                {
                    bg.blog_type.Category = blog.blog_type.Category;
                }
            }

            return RedirectToAction("ShowAllBlogs");
        }




        #endregion

        #region BlogDelete

        public IActionResult DeleteBlog(int id)
        {
            Blog blog = _blogs.FirstOrDefault(x => x.Id == id);

            _blogs.Remove(blog);

            return RedirectToAction("ShowAllBlogs");
        }

        #endregion







    }
}
