using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NavalWar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamingMapController : ControllerBase
    {
        // GET: api/<GamingMapController>
        [HttpGet]
        public GamingMap Get()
        {
            const int WIDTH = 5, HEIGHT = 5;

            GamingMap map = new GamingMap();

            map = map.CreateGamingMap(WIDTH, HEIGHT);

            return map;
        }

        /*
        // GET api/<GamingMapController>/5
        [HttpGet("{id}")]
        public GamingMap Get(int id)
        {
            List<GamingMap> MapList = new List<GamingMap>();
            MapList.Add(new GamingMap());

            MapList[0].ShipPositionsMap = new List<int>();
            MapList[0].WarMap = new List<int>();

            MapList[0].MapID = 1;
            MapList[0].Width = 4;
            MapList[0].Height = 4;

            for (int i = 0; i < MapList[0].Width * MapList[0].Height; i++)
            {
                MapList[0].ShipPositionsMap.Add(0);
            }

            MapList[0].ShipPositionsMap[1] = 1;

            for (int i = 0; i < MapList[0].Width * MapList[0].Height; i++)
            {
                MapList[0].WarMap.Add(0);
            }



            return MapList.Find(element => element.MapID == 1);
        }
        */

        // POST api/<GamingMapController>
        [HttpPost]
        public void Post([FromBody] GamingMap map, [FromBody] Ship ship, [FromBody] int position)
        {
        }
        
        // PUT api/<GamingMapController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] GamingMap map, [FromBody] int position)
        {
        }

        // DELETE api/<GamingMapController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // PUT api/<GamingMapController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] GamingMap map, [FromBody] int position)
        {
            map.AttackPlayer(position);
        }
    }
}
