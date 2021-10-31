using System;
using System.IO;
using System.Runtime.Serialization;

namespace Amazonia.DAL.Infraestrutura
{
 
    [Serializable]
    public class AmazoniaException : Exception
    {

        protected AmazoniaException(SerializationInfo info, StreamingContext context)
        {
        }

        public AmazoniaException(string tipoErro) 
        {

            var path = @"d:\temp\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var log = $"{DateTime.Now} :: {tipoErro}";

            File.WriteAllText($@"{path}log.txt", log);
        }

    }
}
