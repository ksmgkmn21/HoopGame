using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Handlers;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {

        [HttpPost]
        public HoopGameResponse HoopGame(HoopGameRequest request)
        {
            try
            {
                if (request.NumberOfPlayers != default(int) && request.NumberOfPlayers > 1)
                {

                    var winner = new HoopGameHandler().PlayGame(request.NumberOfPlayers);
                    return new HoopGameResponse { Succes = true, Message = "The winning player : " + winner.No };
                }
                else
                {
                    return new HoopGameResponse { Succes = false, Message = "wrong parameter" };
                }
            }
            catch (Exception ex)
            {
                return new HoopGameResponse { Succes = false, Message = ex.Message };
            }
        }

       
    }
}