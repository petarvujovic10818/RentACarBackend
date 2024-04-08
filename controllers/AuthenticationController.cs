using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.IdentityModel.Tokens;
using rentacar.data;
using rentacar.dtos;
using rentacar.interfaces;

namespace rentacar.controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepository _repo;
        private readonly ItokenService _tokenService;
        public AuthenticationController(IAuthenticationRepository repo, ItokenService tokenService)
        {
            _repo = repo;
            _tokenService = tokenService;
        }

        //HTTP POST /login
        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> login([FromBody] LoginDTO dto){
            var res = await _repo.login(dto);
            if(res.JWT.IsNullOrEmpty()) return BadRequest("Wrong email or password!");
            return Ok(res);
        }

        //HTTP POST /checkEmail -> if exists
        //HTTP POST /changePassword -> new password
        //HTTP POST /register -> moze i u UsersController

    }
}