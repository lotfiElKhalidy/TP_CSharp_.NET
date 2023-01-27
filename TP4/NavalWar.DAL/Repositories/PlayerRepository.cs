using NavalWar.DTO;
using NavalWar.DAL.Models;

namespace NavalWar.DAL.Repositories
{
    public class PlayerRepository
    {
        public readonly NavalContext _context;
        public PlayerRepository(NavalContext context)
        {
            _context = context;
        }

        public PlayerDto GetPlayer(int id)
        {
            try
            {
                var player = _context.players.FirstOrDefault(player => player.ID == id);
                return player.ToDto();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddPlayer(PlayerDto playerDto)
        {
            try
            {
                List<Session> sessions = new List<Session>();

                for(int i=0; i<playerDto.Sessions.Count; i++)
                {
                    Session ses = new Session
                    {
                        ID = playerDto.Sessions[i].ID,
                        token = playerDto.Sessions[i].token,
                        //Sessions = playerDto.Sessions
                    };

                    sessions.Add(ses);
                };

                Player player = new Player {
                    ID = playerDto.ID,
                    Name = playerDto.Name,
                    Sessions = sessions
                };

                _context.players.Add(player);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RemovePlayer(int id)
        {
            Player player = _context.players.Find(id);
            if (player != null)
            {
                _context.players.Remove(player);
                _context.SaveChanges();
            }
        }
    }
}
