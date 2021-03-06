using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [Authorize]
  public class UsersController : BaseApiController
  {
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UsersController(IUserRepository userRepository, IMapper mapper)
    {
      _mapper = mapper;
      _userRepository = userRepository;

    }


    [HttpGet] //ASYNC GET REQUEST
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
      var users = await _userRepository.GetMembersAsync();
      return Ok(users);
    }


    [HttpGet("{username}")] //ASYNC GET REQUEST BY ID
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
      var user = await _userRepository.GetMemberAsync(username);
      // var userToReturn = _mapper.Map<MemberDto>(user); //maps user to MemberDto (avoid circular dependency)
      return user;
    }
  }
}