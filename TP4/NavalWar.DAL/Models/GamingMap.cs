using NavalWar.DTO;

namespace NavalWar.DAL.Models
{
    public class GamingMap
    {
        public int MapID { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int[][] ShipPositionsMap { get; set; }
        public int[][] WarMap { get; set; }

        public GamingMapDto ToDto()
        {
            GamingMapDto gamingMap = new GamingMapDto();

            gamingMap.MapID = this.MapID;
            gamingMap.Width = this.Width;
            gamingMap.Height = this.Height;
            gamingMap.ShipPositionsMap = this.ShipPositionsMap;
            gamingMap.WarMap = this.WarMap;

            return gamingMap;
        }
    }
}
