namespace MessengerApp.Core.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Services.Friends;

    [Route("/friends")]
    public class FriendController : ApiController
    {

        private readonly IFriendService service;

        public FriendController(IFriendService service)
        {
            this.service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetFriends()
        {
            var getFriendResult = await service.GetFriends();
            return Ok(getFriendResult);
        }

        [HttpPost("searchFriend")]
        public async Task<IActionResult> SearchUsersByName(string name)
        {
            var lookupUserResult = await service.SearchUsersByName(name);
            return Ok(lookupUserResult);
        }
    }
}
