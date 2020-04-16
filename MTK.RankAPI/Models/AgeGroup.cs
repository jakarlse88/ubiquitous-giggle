namespace MTK.RankAPI.Models
{
    public class AgeGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short UpperBoundary { get; set; }
        public short LowerBoundary { get; set; }
    }
}