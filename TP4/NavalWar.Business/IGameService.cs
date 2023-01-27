using NavalWar.DTO;

namespace NavalWar.Business
{
    public interface IGameService
    {
        public GamingMapDto CreateGamingMap(int Width, int Height);
        public bool AddShipToGamingMap(string infos);
        public bool DeleteShipFromGamingMap(string infos);
        public bool ReplaceShipInGamingMap(string infos);
    }
}
