using Bookish.Models.Request;
using Bookish.Models.Response;
using Bookish.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bookish.Controllers
{
    [Route("members")]
    public class MembersController : Controller
    {
        private readonly IMembersService _membersService;
        
        public MembersController(IMembersService membersService)
        {
            _membersService = membersService;
        }

        [HttpGet("")]
        public IActionResult GetAllMembers()
        {
            var members = _membersService.GetAllMembers();
            var model = new MembersModel(members);
            return View("AllMembers", model);
        }

        [HttpGet("create")]
        public IActionResult CreateMemberPage()
        {
            return View("CreateMember");
        }

        [HttpPost("create")]
        public IActionResult CreateMember([FromForm] CreateMemberModel memberModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateMember");
            }

            _membersService.InsertUser(memberModel);
            return Redirect(Url.Action("GetAllMembers"));
        }
    }
}