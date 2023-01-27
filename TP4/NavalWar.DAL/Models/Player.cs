using NavalWar.DTO;
using System.ComponentModel.DataAnnotations;

namespace NavalWar.DAL.Models
{
    class Player
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Session> Sessions { get; set; }

        public PlayerDto ToDto()
        {
            PlayerDto player = new PlayerDto();

            player.ID = this.ID;
            player.Name = this.Name;
            player.Sessions = this.Sessions;

            return player;
        }

    }
}
