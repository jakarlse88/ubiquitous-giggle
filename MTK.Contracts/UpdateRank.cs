using System;

namespace MTK.Contracts
{
    public interface IUpdateRank
    {
        Guid EventId { get; }
        DateTime TimeStamp { get; }

        int RankId { get; }
        int RankTypeId { get; }
        string Description { get; }
    }
}