using System;
using System.IO;
using System.Runtime.Serialization;

namespace Amazonia.DAL.Infraestrutura
{
 
    public class AmazoniaException : Exception
    {
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
