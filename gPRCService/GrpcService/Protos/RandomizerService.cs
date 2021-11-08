using System;
using System.Threading.Tasks;
using Grpc.Core;

namespace GrpcService.Protos
{
    public class RandomizerService : Randomizer.RandomizerBase
    {
        private Random _random;
        public RandomizerService()
        {
            _random = new Random();
        }
        public override Task<RandomResponse> GetRandom(RandomRequest request, ServerCallContext context)
        {
            return Task.FromResult(new RandomResponse {Numb = _random.Next()});
        }
    }
}