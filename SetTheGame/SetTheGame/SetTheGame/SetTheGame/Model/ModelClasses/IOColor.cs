using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Serialization;

namespace SetTheGame.Model
{
    public sealed class IOColor
    {
        private readonly string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Colors.xml");
        private static IOColor instance = null;
        public static IOColor Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new IOColor();
                }
                return instance;
            }
        }

        private readonly List<Color> colorlist;

        public Color Color1
        {
            get
            {
                return colorlist[0];
            }
            set
            {
                colorlist[0] = value;
            }
        }
        public Color Color2
        {
            get
            {
                return colorlist[1];
            }
            set
            {
                colorlist[1] = value;
            }
        }
        public Color Color3 
        {
            get
            {
                return colorlist[2];
            }
            set
            {
                colorlist[2] = value;
            }
        }

        public string FileName => fileName;

        private IOColor()
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(List<Color>));
                    colorlist = (List<Color>)ser.Deserialize(fs);
                }
            }
            catch (Exception)
            {
                colorlist = new List<Color>(3)
                {
                    Stub.Stub.GetRedColor(),
                    Stub.Stub.GetGreenColor(),
                    Stub.Stub.GetPurpleColor()
                };
            }
        }

        public void SaveColors()
        {
            using (TextWriter writer = new StreamWriter(FileName))
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<Color>));
                ser.Serialize(writer, colorlist);
            }
        }

        public void GetDefaultColors()
        {
            colorlist[0] = Stub.Stub.GetRedColor();
            colorlist[1] = Stub.Stub.GetGreenColor();
            colorlist[2] = Stub.Stub.GetPurpleColor();
        }

        public void GetColorblindColors()
        {
            colorlist[0] = new Color(0,0,0);
            colorlist[1] = new Color(0, 255, 0);
            colorlist[2] = new Color(0, 0, 255);
        }
    }
}
