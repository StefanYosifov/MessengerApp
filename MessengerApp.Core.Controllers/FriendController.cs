namespace MessengerApp.Core.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Services.Friends;

    using ViewModels.Friends;

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
        public async Task<IActionResult> GetUsersByName([FromQuery] string userName)
        {
            var lookupUserResult = await service.SearchUsersByName(userName);
            return Ok(lookupUserResult);
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendFriendRequest(SendFriendRequest userSentTo)
        {
            var sentFriendRequestResult = await service.SendFriendRequest(userSentTo.UserId);
            return Ok(sentFriendRequestResult);
        }

        [HttpGet("myFriendRequests")]
        public async Task<IActionResult> GetFriendRequest()
        {
            var myFriendRequestsResult = await service.ViewMyFriendRequests();
            return Ok(myFriendRequestsResult);
        }

        [HttpPost("request/accept")]
        public async Task<IActionResult> AcceptFriendRequest(RespondToFriendRequest request)
        {
            var requestResult = await service.AcceptFriendRequest(request);
            return Ok(requestResult);
        }
    }
}