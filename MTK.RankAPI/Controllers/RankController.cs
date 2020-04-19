using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using MTK.Contracts;
using MTK.RankAPI.Data;
using MTK.RankAPI.Models;

namespace MTK.RankAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RankController : ControllerBase
    {
        private readonly RankServiceDbContext _context;
        private readonly IPublishEndpoint _publishEndpoint;
        public RankController(RankServiceDbContext context, IBus bus, IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AgeGroup>> Get()
        {
            return _context.AgeGroup.ToList();
        }

        [HttpPut]
        public ActionResult Put()
        {
            Console.WriteLine("Rank updated");

            _publishEndpoint.Publish<UpdateRank>(new { EventId = Guid.NewGuid() });

            return Ok();
        }
    }
}
