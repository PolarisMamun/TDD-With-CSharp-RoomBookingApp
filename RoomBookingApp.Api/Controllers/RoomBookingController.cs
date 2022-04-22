using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomBookingApp.Core.Models;
using RoomBookingApp.Core.Processors;
using System;
using System.Threading.Tasks;

namespace RoomBookingApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomBookingController : ControllerBase
    {
        private IRoomBookingRequestProcesser _roomBookingProcessor;

        public RoomBookingController(IRoomBookingRequestProcesser roomBookingProcessor)
        {
            this._roomBookingProcessor = roomBookingProcessor;
        }

        [HttpPost]
        public async Task<IActionResult> BookRoom(RoomBookingRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = _roomBookingProcessor.BookRoom(request);
                if (result.Flag == Core.Enums.BookingResultFlag.Success)
                {
                    return Ok(result);
                }

                ModelState.AddModelError(nameof(RoomBookingRequest.Date), "No Rooms Available For Given Date");
            }

            return BadRequest(ModelState);
        }
    }
}
