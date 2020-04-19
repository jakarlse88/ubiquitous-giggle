using System;
using System.Threading.Tasks;
using MassTransit;
using MTK.Contracts;

namespace MTK.SyllabusAPI
{
    public class UpdateRankConsumer : IConsumer<IUpdateRank>
    {
        public async Task Consume(ConsumeContext<IUpdateRank> context)
        {
            await Console.Out.WriteLineAsync($"Updating rank: {context.Message.RankId}");
        }
    }
}