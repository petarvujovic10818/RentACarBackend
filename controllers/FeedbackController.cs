using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rentacar.dtos;
using rentacar.interfaces;
using rentacar.mappers;

namespace rentacar.controllers
{
    [Route("/api/feedback")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IUserRepository _userRepository;

        private readonly ICarRepository _carRepository;
        public FeedbackController(IFeedbackRepository feedbackRepository, IUserRepository userRepository, ICarRepository carRepository)
        {
            _feedbackRepository = feedbackRepository;
            _userRepository = userRepository;
            _carRepository = carRepository;
        }

        [HttpGet]
        [Route("/user/{id:int}")]
        [Authorize]
        public async Task<IActionResult> getFeedbacksForUser([FromRoute] int id){
            var feedbacks = await _feedbackRepository.getFeedbacksForUser(id);
            var fedbacksDTO = feedbacks.Select(x => x.toFeedbackDTO());
            return Ok(fedbacksDTO);
        }

        [HttpGet]
        [Route("/car/{id:int}")]
        [Authorize]
        public async Task<IActionResult> getFeedbacksForCar([FromRoute] int id){
            var feedbacks = await _feedbackRepository.getFeedbacksForCar(id);
            var fedbacksDTO = feedbacks.Select(x => x.toFeedbackDTO());
            return Ok(fedbacksDTO);
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> getFeedbackById([FromRoute] int id){
            var feedback = await _feedbackRepository.getFeedbackById(id);
            if(feedback == null) return NotFound();
            return Ok(feedback.toFeedbackDTO());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> createFeedback([FromBody] CreateFeedbackDTO feedbackDTO){

            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            if(!await _carRepository.carExists(feedbackDTO.carId)){
                return BadRequest("Car does not exist");
            }

            if(!await _userRepository.userExists(feedbackDTO.userId)){
                return BadRequest("User does not exist");
            }

            var feedbackModel = feedbackDTO.toFeedbackModel();
            await _feedbackRepository.createFeedback(feedbackModel);
            return CreatedAtAction(nameof(getFeedbackById), new {id = feedbackModel.id}, feedbackModel.toFeedbackDTO());
        }

    }
}