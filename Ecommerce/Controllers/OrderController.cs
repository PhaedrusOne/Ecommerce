using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Data;
using Ecommerce.Models;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly int orderID;
        //private readonly object o;

        public OrderController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Order> orders = context.Orders.ToList();

            return View(orders);
        }

        public IActionResult Add()
        {

            AddOrderViewModel addOrderViewModel = new AddOrderViewModel();

            return View(addOrderViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddOrderViewModel addOrderViewModel)
        {
            if (ModelState.IsValid)
            {
                Order newOrder = new Order
                {
                    OrderDate = addOrderViewModel.OrderDate,
                    DeliverDate = addOrderViewModel.DeliverDate
                };

                context.Orders.Add(newOrder);
                context.SaveChanges();

                return Redirect("/Order/ViewOrder/" + newOrder.ID);
            }

            return View(addOrderViewModel);
        }


        [HttpGet]
        public IActionResult ViewOrder(int id)
        {

            List<ProductOrder> items = context
                .ProductOrders
                .Include(item => item.Product)
                .Where(cm => cm.OrderID == id)
                .ToList();

            Order Order = context.Orders.SingleOrDefault(c => c.ID == id);


            ViewOrderViewModel viewModel = new ViewOrderViewModel()
            {
                Order = Order,
                Items = items
            };

            return View(viewModel);
        }


        [HttpGet]
        public IActionResult AddItem(int id)
        {
            Order order = context.Orders.SingleOrDefault(m => m.ID == id);
            List<Product> products = context.Products.ToList();
            return View(new AddOrderItemViewModel(order, products));
        }


        [HttpPost]
        public IActionResult AddItem(AddOrderItemViewModel addOrderItemViewModel)
        {
            if (ModelState.IsValid)
            {
                var productID = addOrderItemViewModel.ProductID;
                var orderID = addOrderItemViewModel.OrderID;

                IList<ProductOrder> existingItems = context.ProductOrders
                    .Where(cm => cm.ProductID == productID)
                    .Where(cm => cm.OrderID == orderID).ToList();

                if (existingItems.Count == 0)
                {
                    ProductOrder orderItem = new ProductOrder
                    {
                        Product = context.Products.SingleOrDefault(c => c.ID == productID),
                        Order = context.Orders.SingleOrDefault(m => m.ID == orderID)
                    };

                    context.ProductOrders.Add(orderItem);
                    context.SaveChanges();
                }

                return Redirect(string.Format("/Order/ViewOrder/{0}", addOrderItemViewModel.OrderID));

            }

            return View(addOrderItemViewModel);

        }


    }
}
