using AutoMapper;
using BookWatch.Data;
using BookWatch.ViewModel;
using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWatch.Controllers
{
    [Route("/api/orders/{orderid}/items")]
    public class OrderItemController : Controller
    {
        private readonly ILogger<OrderItemController> _logger;
        private readonly IBookWatchRepository _repository;
        private readonly IMapper _mapper;

        public OrderItemController(ILogger<OrderItemController> logger,
            IBookWatchRepository repository,
            IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Get(int orderId)
        {
            var order = _repository.GetOrderById(orderId);
            if (order != null) return Ok(_mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderItemViewModel>>(order.Items));
            return NotFound();
            //api/order/1/items
            //building apis aspdotnet core
        }


        [HttpGet("{id}")]
        public IActionResult Get(int orderId, int id)
        {
            var order = _repository.GetOrderById(orderId);
            if (order != null)
            {
                var item = order.Items.Where(i => i.Id == id).FirstOrDefault();
                if (item != null)
                {
                    return Ok(_mapper.Map<OrderItem, OrderItemViewModel>(item));
                }
            }
            return NotFound();
        }
    }
}
