namespace MTK.RankAPI.Models
{
    public class Rank
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int RankTypeId { get; set; }
        public RankType RankType { get; set; }
    }
}