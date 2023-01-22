using NavalWar.DTO;

namespace NavalWar.DAL.Models
{
    class Session
    {
        public int ID { get; set; }
        public string token { get; set; }
        public GamingMap map { get; set; }

        public SessionDto ToDto()
        {
            SessionDto session = new SessionDto();

            session.ID = this.ID;

            return session;
        }
    }
}
