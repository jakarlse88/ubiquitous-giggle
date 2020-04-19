using System;
using MTK.Contracts;

namespace MTK.SyllabusAPI
{
    public class UpdateRank : IUpdateRank
    {
        public Guid EventId { get; }
        public DateTime TimeStamp { get; }
        public int RankId { get; }
        public int RankTypeId { get; }
        public string Description { get; }
    }
}