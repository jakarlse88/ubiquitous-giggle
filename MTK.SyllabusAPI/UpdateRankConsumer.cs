using System;
using System.Threading.Tasks;
using MassTransit;
using MTK.Contracts;

namespace MTK.SyllabusAPI
{
    public class UpdateRankConsumer : IConsumer<UpdateRank>
    {
        public async Task Consume(ConsumeContext<UpdateRank> context)
        {
            await Console.Out.WriteLineAsync($"Updating rank: {context.Message.RankId}");
        }
    }
}