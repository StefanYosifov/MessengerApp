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

        [HttpGet("searchFriend/{userName}")]
        public async Task<IActionResult> SearchUsersByName([FromQuery]string userName)
        {
            var lookupUserResult = await service.SearchUsersByName(userName);
            return Ok(lookupUserResult);
        }
    }
}
