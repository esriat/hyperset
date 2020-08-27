using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace SetTheGame.Model
{
    public class IOOption
    {
        private static readonly DataContractSerializer serializer = new DataContractSerializer(typeof(string));

        private static readonly string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Option.bin");
        public static string LoadOption()
        {
            string options = "";
            try
            {
                using (Stream s = File.OpenRead(fileName))
                {
                    options = serializer.ReadObject(s) as string;
                }
            }
            catch (Exception)
            {
                options = "Default";
            }
            return options;
        }
        public static void SaveOption(string options)
        {
            try
            {
                using (Stream s = File.OpenWrite(fileName))
                {
                    serializer.WriteObject(s, options);
                }
            }
            catch (FileNotFoundException)
            {
                try
                {
                    using (Stream s = File.Create(fileName))
                    {

                        serializer.WriteObject(s, options);
                    }
                }
                catch (Exception e2)
                {
                    System.Diagnostics.Debug.WriteLine(e2.Message);
                }
            }
        }
    }
}
