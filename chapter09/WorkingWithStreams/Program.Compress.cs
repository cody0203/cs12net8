using Packt.Shared;
using System.IO.Compression;
using System.Xml;

partial class Program
{
    private static void Compress(string algorithm = "gzip")
    {
        string filePath = Combine(CurrentDirectory, $"streams.{algorithm}");

        FileStream file = File.Create(filePath);

        Stream compressor;

        if (algorithm == "gzip")
        {
            compressor = new GZipStream(file, CompressionMode.Compress);
        }
        else
        {
            compressor = new BrotliStream(file, CompressionMode.Compress);
        }

        using (compressor)
        {
            using (XmlWriter xml = XmlWriter.Create(compressor))
            {
                xml.WriteStartDocument();
                xml.WriteStartElement("callsigns");
                foreach (string item in Viper.Callsigns)
                {
                    xml.WriteElementString("callsign", item);
                }
            }
        } // using keyword also closes the underlying stream.

        OutputFileInfo(filePath);

        // Read the compressed file.

        WriteLine("Reading the compressed XML file");
        file = File.Open(filePath, FileMode.Open);
        Stream decompressor;

        if (algorithm == "gzip")
        {
            decompressor = new GZipStream(file, CompressionMode.Decompress);
        }
        else
        {
            decompressor = new BrotliStream(file, CompressionMode.Decompress);
        }

        using (decompressor)
        {
            using (XmlReader reader = XmlReader.Create(decompressor))
            {
                while (reader.Read())
                {
                    if (reader is { NodeType: XmlNodeType.Element, Name: "callsign" })
                    {
                        reader.Read();
                        WriteLine($"{reader.Value}");
                    }
                }
            }
        }
    }
}