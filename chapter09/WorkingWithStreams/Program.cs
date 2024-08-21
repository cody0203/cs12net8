using Packt.Shared;
using System.Xml;


#region Text streams
SectionTitle("Writing to text streams");

// Define a file to write to.
string textFile = Combine(CurrentDirectory, "streams.txt");

// Create a text file and return a helper writer.
StreamWriter text = File.CreateText(textFile);

foreach (string item in Viper.Callsigns)
{
    text.WriteLine(item);
}

text.Close();

OutputFileInfo(textFile);

#endregion

#region XML streams
SectionTitle("Writing to XML streams");

// Define a file path to write to.
string xmlFile = Combine(CurrentDirectory, "streams.xml");

// Declare variables for the filestream and XML writer
FileStream? xmlFileStream = null;
XmlWriter xml = null;

try
{
    xmlFileStream = File.Create(xmlFile);

    // Wrap the file stream in an XML writer helper and tell it
    // to automatically indent nested elements.

    xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings { Indent = true });

    // write the XML declaration.
    xml.WriteStartDocument();

    // Write a root element.
    xml.WriteStartElement("callsigns");

    foreach (string item in Viper.Callsigns)
    {
        xml.WriteElementString("callsigns", item);
    }

    // Write the close root element.
    xml.WriteEndElement();
}
catch (Exception ex)
{
    WriteLine($"{ex.GetType()} says {ex.Message}");
}
finally
{
    if (xml is not null)
    {
        xml.Close();
        WriteLine("The XML writer's unmanaged resources have ben disposed.");
    }

    if (xmlFileStream is not null)
    {
        xmlFileStream.Close();
        WriteLine("The file stream's unmanaged resources have been disposed");
    }
}

OutputFileInfo(xmlFile);
#endregion

#region Compressing streams
SectionTitle("Compressing streams");
Compress(algorithm: "gzip");
Compress(algorithm: "brotli"); // Smaller than gzip
#endregion