using System.IO;
using fnbot.shop.Backend.Configuration;

namespace BaseModule
{
    sealed class Config : IConfig
    {
        // You are to handle everything when working with previous versions, invalid data, etc.
        public void LoadConfig(Stream stream)
        {
            using var reader = new BinaryReader(stream);
            PostMessage.Value = reader.ReadString();
        }

        // The file is truncated for you, write as it's a new file
        public void SaveConfig(Stream stream)
        {
            using var writer = new BinaryWriter(stream);
            writer.Write(PostMessage.Value);
        }

        public readonly ConfigProperty<string> PostMessage = new ConfigProperty<string>("This is a test message.", "Post Message", true, true);
    }
}
