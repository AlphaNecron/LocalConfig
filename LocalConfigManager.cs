
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LocalConfig
{
    public class LocalConfigManager
    {
        private StreamReader _reader;
        private string _path;

        public LocalConfigManager(string location)
        {
            _path = location;
            if (!File.Exists(location)) File.Create(location);
        }

        public void WriteConfig(object @object)
        {
            var content = JsonConvert.SerializeObject(@object);
            File.WriteAllText(_path, content);
        }

        public T ReadConfig<T>()
        {
            _reader = new StreamReader(_path, Encoding.UTF8);
            var content = _reader.ReadToEnd();
            _reader.Close();
            return JsonConvert.DeserializeObject<T>(content);
        }

        public object ReadProperty(string name)
        {
            _reader = new StreamReader(_path, Encoding.UTF8);
            var content = _reader.ReadToEnd();
            _reader.Close();
            return JObject.Parse(content)[name];
        }
    }
}