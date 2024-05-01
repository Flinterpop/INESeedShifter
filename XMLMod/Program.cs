// See https://aka.ms/new-console-template for more information
using System.Xml;
using System.IO;
using System.Security.AccessControl;

string fname = "source.xml";

string[] arguments = Environment.GetCommandLineArgs();

if (arguments.Length > 1)
{
    Console.WriteLine("GetCommandLineArgs: {0}", string.Join(", ", arguments[1]));
    fname = arguments[1];
}

string cwd = Directory.GetCurrentDirectory();
Console.WriteLine("Current folder: {0}.", cwd);

Console.WriteLine("Shifting INE Seeds found in {0}", fname);


XmlDocument doc = new XmlDocument();
doc.Load(fname);




XmlNodeList nodes = doc.GetElementsByTagName("IneSeed");
for (int i = 0; i < nodes.Count; i++)
{
    string s = nodes[i].InnerXml;

    int val = 0;
    bool success = Int32.TryParse(s, out val);

    Console.WriteLine(nodes[i].InnerXml);

    if (val>=100)
    {
        int newVal = val - 75;
        nodes[i].InnerXml = newVal.ToString();

    }
}

try
{
    string newFname = fname + ".xml";
    doc.Save(newFname);
}
catch (Exception e)
{
    Console.WriteLine(e.ToString());
}

//Console.ReadKey();

