using NavalWar.DTO;

namespace NavalWar.DAL.Repositories
{
    class SessionRepository
    {
        public readonly NavalContext _context;
        public SessionRepository(NavalContext context)
        {
            _context = context;
        }

        public SessionDto GetSession(int id)
        {
            try
            {
                var session = _context.sessions.FirstOrDefault(s => s.ID == id);
                return session.ToDto();
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
