using System.ComponentModel.DataAnnotations;

namespace NavalWar.DAL.Models
{
    class Player
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Session> Sessions { get; set; }

    }
}
