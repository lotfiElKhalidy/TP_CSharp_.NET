using System.ComponentModel.DataAnnotations;

namespace NavalWar.DTO
{
    public class PlayerDto
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public List<SessionDto> Sessions { get; set; }
    }
}
