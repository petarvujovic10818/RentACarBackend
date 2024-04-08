using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rentacar.dtos;
using rentacar.helpers;
using rentacar.interfaces;
using rentacar.mappers;
using rentacar.models;

namespace rentacar.controllers
{
    [Route("/api/cars")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getAllCars([FromQuery] QueryObject query){
            var cars =  await _carRepository.getCars(query);
            var carsDTO = cars.Select(c => c.carToReadDTO());
            return Ok(carsDTO);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> getCarById([FromRoute] int id){
            var car = await _carRepository.getCarById(id);
            if(car == null) return NotFound();
            return Ok(car.carToReadDTO());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> createCar([FromBody] UpdateCarDTO carDTO){

            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var carModel = carDTO.dtoToModel();
            await _carRepository.createCar(carModel);
            return CreatedAtAction(nameof(getCarById), new {id = carModel.id}, carModel.toCarDTO()); //is it gonna work this way
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> updateCar([FromRoute] int id, [FromBody] UpdateCarDTO dto){
            var car = await _carRepository.updateCar(id, dto);
            if(car == null) return NotFound();
            return Ok(car.toCarDTO());
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> deleteCar([FromRoute] int id) {
            var car = await _carRepository.deleteCar(id);
            if(car == null) return NotFound();
            return NoContent();
        }
    }
}