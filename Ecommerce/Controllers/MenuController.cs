using System.Collections.Generic;
using System.Linq;
using Ecommerce.Data;
using Ecommerce.Models;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.Controllers
{
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext context;

        public MenuController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Menu> menus = context.Menus.ToList();

            return View(menus);
        }

        public IActionResult Add()
        {          
            AddMenuViewModel addMenuViewModel = new AddMenuViewModel();

            return View(addMenuViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddMenuViewModel addMenuViewModel)
        {
            if (ModelState.IsValid)
            {
                Menu newMenu = new Menu
                {
                    Name = addMenuViewModel.Name
                };

                context.Menus.Add(newMenu);
                context.SaveChanges();

                return Redirect("/Menu/ViewMenu/" + newMenu.ID);
            }

            return View(addMenuViewModel);
        }

        [HttpGet]
        public IActionResult ViewMenu(int id)
        {
            List<ProductMenu> items = context
                .ProductMenus
                .Include(item => item.Product)
                .Where(cm => cm.MenuID == id)
                .ToList();

            Menu Menu = context.Menus.Single(c => c.ID == id);


            ViewMenuViewModel viewModel = new ViewMenuViewModel()
            {
                Menu = Menu,
                Items = items
            };

            return View(viewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Menu";
            ViewBag.menus = context.Menus.ToList();
            return View();
        }


        [HttpPost]
        public IActionResult Remove(int[] menuIds)
        {
            foreach (int menuId in menuIds)
            {
                Menu theMenu = context.Menus.Single(c => c.ID == menuId);
                context.Menus.Remove(theMenu);
            }

            context.SaveChanges();

            return Redirect("/");
        }


        [HttpGet]
        public IActionResult AddItem(int id)
        {
            ViewBag.title = "Add Item to Menu: ";
            Menu menu = context.Menus.Single(m => m.ID == id);
            List<Product> products = context.Products.ToList();
            return View(new AddMenuItemViewModel(menu, products));
        }

        [HttpPost]
        public IActionResult AddItem(AddMenuItemViewModel addMenuItemViewModel)
        {
            if (ModelState.IsValid)
            {
                var productID = addMenuItemViewModel.ProductID;
                var menuID = addMenuItemViewModel.MenuID;

                IList<ProductMenu> existingItems = context.ProductMenus
                    .Where(cm => cm.ProductID == productID)
                    .Where(cm => cm.MenuID == menuID).ToList();

                if (existingItems.Count == 0)
                {
                    ProductMenu menuItem = new ProductMenu
                    {
                        Product = context.Products.Single(c => c.ID == productID),
                        Menu = context.Menus.Single(m => m.ID == menuID)
                    };

                    context.ProductMenus.Add(menuItem);
                    context.SaveChanges();
                }
                ViewBag.title = "Add Item to Menu: ";
                return Redirect(string.Format("/Menu/ViewMenu/{0}", addMenuItemViewModel.MenuID));
            }

            return View(addMenuItemViewModel);

        }

    }
}
