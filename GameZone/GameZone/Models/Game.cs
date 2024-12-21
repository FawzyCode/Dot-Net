

namespace GameZone.Models
{
    public class Game : BaseEntity
    {
        //public int Id { get; set; }
        //[MaxLength(250)]
        //public string Name { get; set; }=string.Empty;
        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Cover { get; set; } = string.Empty;
        [ForeignKey("category")]
        public int CategoryId { get; set; }
        public Category category { get; set; } = default!; // Novigation Property 
        //relation between (Game, Devices) Many To Many
        public ICollection<GameDevice> Devices { get; set; }=new List<GameDevice>();
    }
}
