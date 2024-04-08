using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rentacar.data;
using rentacar.dtos;
using rentacar.interfaces;
using rentacar.mappers;
using rentacar.repositories;

namespace rentacar.controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IUserRepository _userRepository;
        public UserController(ApplicationDBContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }
        [HttpGet]
        [Authorize]
        // [ClaimRequirement()]
        public async Task<IActionResult> getAllUsers(){
            
            var user = User.FindFirst("Typ").Value;
            if(!user.Equals("ADMIN")) return Unauthorized("You have no permissions!");

            var users = await _userRepository.getUsersAsync();
            var usersDTO = users.Select(s => s.toUserDTO()); //select = map
            return Ok(usersDTO);
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> getUserById([FromRoute] int id){

            var userType = User.FindFirst("Typ").Value;
            if(!userType.Equals("ADMIN")) return Unauthorized("You have no permissions!");

            var user = await _userRepository.getUserByIdAsync(id);

            if(user == null){
                return NotFound();
            }

            return Ok(user.toUserDTO());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> createUser([FromBody] CreateUserDTO createUserDto){

            var userType = User.FindFirst("Typ").Value;
            if(!userType.Equals("ADMIN")) return Unauthorized("You have no permissions!");

            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var userModel = createUserDto.toUserFromCreateUserDTO();
            await _userRepository.createUserAsync(userModel);
            return CreatedAtAction(nameof(getUserById), new { id = userModel.id }, userModel.toUserDTO());
            //method to get back user data after create
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> updateUser([FromRoute] int id, [FromBody] UpdateUserDTO updateUserDTO){

            var userType = User.FindFirst("Typ").Value;
            if(!userType.Equals("ADMIN")) return Unauthorized("You have no permissions!");

            var userModel = await _userRepository.updateUserAsync(id, updateUserDTO);

            if(userModel == null){
                return NotFound();
            }

            return Ok(userModel.toUserDTO());

        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> deleteUser([FromRoute] int id){

            var userType = User.FindFirst("Typ").Value;
            if(!userType.Equals("ADMIN")) return Unauthorized("You have no permissions!");

            var userModel = await _userRepository.deleteUserAsync(id);
            if(userModel == null){
                return NotFound();
            }

            return NoContent();
        }
    }
}