using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using rentacar.dtos;
using rentacar.interfaces;
using rentacar.mappers;
using rentacar.models;

namespace rentacar.controllers
{
    [Route("/api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICarRepository _carRepository;
        public OrderController(IOrderRepository orderRepository, IUserRepository userRepository, ICarRepository carRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _carRepository = carRepository;
        }

        [HttpGet]
        [Route("/userOrder/{id:int}")]
        [Authorize]
        public async Task<IActionResult> getOrdersByUser([FromRoute] int id){
            var orders = await _orderRepository.getOrdersForUser(id);
            var ordersDTO = orders.Select((x) => x.orderToDTO());
            return Ok(ordersDTO);
            //update 
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> getOrderById([FromRoute] int id){
            var order = await _orderRepository.getOrderById(id);
            if(order == null) return NotFound();
            return Ok(order.orderToDTO());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> createOrder([FromBody] CreateOrderDTO dto){

            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            if(!await _carRepository.carExists(dto.carId)){
                return BadRequest("Car does not exist");
            }

            if(!await _userRepository.userExists(dto.userId)){
                return BadRequest("User does not exist");
            }

            var orderModel = dto.dtoToModelOrder();
            await _orderRepository.createOrder(orderModel);
            return CreatedAtAction(nameof(getOrderById), new {orderModel.id}, orderModel.orderToDTO());
        }

    }
}