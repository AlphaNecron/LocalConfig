# LocalConfigManager
A simple C# library to help you save and load application config from local machine.
## Dependency
- Newtonsoft JSON.NET
## Usage
```
static void Main(string[] args)
{
    var localConfig = new LocalConfigManager(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "demo.conf"));
    var demoObject = new DemoObject()
    {
        DemoString = "Hello World!",
        DemoBoolean = true,
        DemoInteger = 12345
    };
    localConfig.WriteConfig(demoObject);
    Console.WriteLine("Demo string: " + localConfig.ReadProperty("DemoString"));
    Console.WriteLine("Demo boolean: " + localConfig.ReadProperty("DemoBoolean"));
    Console.Write("Demo integer: " + localConfig.ReadProperty("DemoInteger"));
}

class DemoObject
{
    public string DemoString;
    public int DemoInteger;
    public bool DemoBoolean;
}
```
