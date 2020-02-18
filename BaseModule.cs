using System;
using System.Threading.Tasks;
using fnbot.shop.Backend;
using fnbot.shop.Backend.Configuration;
using fnbot.shop.Backend.ItemTypes;

namespace BaseModule
{
    public sealed class BaseModule : IModule
    {
        // Usually in seconds
        public int RefreshTime => 3;
        public IConfig Config => config;

        Config config = new Config();
        Random random = new Random();

        // Respect the force argument and return a non-null item if true
        public async Task<IItem> Post(bool force)
        {
            if (force || random.NextDouble() > .8f)
            {
                Console.WriteLine("PRINTING " + config.PostMessage.Value);
                return new ItemText(config.PostMessage.Value);
            }
            return null;
        }

        public void Dispose()
        {

        }
    }
}
