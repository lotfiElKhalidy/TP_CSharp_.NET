using NavalWar.DTO;
using NavalWar.DAL.Models;

namespace NavalWar.DAL.Repositories
{
    public class GamingMapRepository
    {
        public readonly NavalContext _context;
        public GamingMapRepository(NavalContext context)
        {
            _context = context;
        }

        public GamingMapDto GetGamingMap(int id, string sessionId)
        {
            try
            {
                Player player = _context.players.FirstOrDefault(player => player.ID == id);
                GamingMap gamingMap = player.Sessions.FirstOrDefault(session => session == sessionId);
                
                return gamingMap.ToDto();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
