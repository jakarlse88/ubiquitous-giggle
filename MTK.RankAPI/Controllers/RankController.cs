using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MTK.RankAPI.Data;
using MTK.RankAPI.Models;

namespace MTK.RankAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RankController : ControllerBase
    {
        private readonly RankServiceDbContext _context;

        public RankController(RankServiceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AgeGroup>> Get()
        {
            return _context.AgeGroup.ToList();
        }
    }
}
