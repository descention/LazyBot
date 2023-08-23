using LazyLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace LazyLib.Pointers
{
    public static class PqrOffsetImporter
    {
        public static IPqrOffsets? ImportOffsetsFromEmbeddedResource(string resourceName)
        {
            using Stream resourceStream = Assembly.GetExecutingAssembly()?.GetManifestResourceStream(resourceName);
            
            if (resourceStream == null)
            {
                return null;
            }

            return new XmlSerializer(typeof(IPqrOffsets)).Deserialize(resourceStream) as IPqrOffsets;
           
        }
    }
}
