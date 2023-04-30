using Newtonsoft.Json;

var json = JsonConvert.SerializeObject(new
    {
        title =  "Jéjé",
        Power = new
        {
            Label = "Wizard"
        }
    });

File.WriteAllText(@"C:\Users\jerom\Documents\Dev\Tests\test.json", JsonConvert.SerializeObject(json));
//Console.WriteLine(json);
