using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace SetTheGame.Model
{
    public sealed class IOTutorial
    {
        private string setTutorialPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "setTutorialSer.xml");
        private string hypersetTutorialPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "hypersetTutorialSer.xml");
        public bool isSetTutorialDone { get; private set; } = false;
        public bool isHypersetTutorialDone { get; private set; } = false;
        private static IOTutorial instance = null;
        public static IOTutorial Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new IOTutorial();
                }
                return instance;
            }
        }

        private IOTutorial()
        {
            try
            {
                using (FileStream fs = new FileStream(setTutorialPath, FileMode.Open))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(bool));
                    isSetTutorialDone = (bool)ser.Deserialize(fs);
                    System.Diagnostics.Debug.WriteLine("LE PETIT BONHOMME EN MOUSSEUH " + isSetTutorialDone);
                }
            }
            catch (Exception)
            {
                isSetTutorialDone = false;
            }

            try
            {
                using (FileStream fs = new FileStream(hypersetTutorialPath, FileMode.Open))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(bool));
                    isHypersetTutorialDone = (bool)ser.Deserialize(fs);
                }
            }
            catch (Exception)
            {
                isHypersetTutorialDone = false;
            }
        }

        public void SetTutorialDone()
        {
            using (TextWriter writer = new StreamWriter(setTutorialPath))
            {
                XmlSerializer ser = new XmlSerializer(typeof(bool));
                ser.Serialize(writer, true);
                isSetTutorialDone = true;
            }
        }

        public void HypersetTutorialDone()
        {
            using (TextWriter writer = new StreamWriter(hypersetTutorialPath))
            {
                XmlSerializer ser = new XmlSerializer(typeof(bool));
                ser.Serialize(writer, true);
                isHypersetTutorialDone = true;
            }
        }

        public void TutorialDone(GameModes gamemode)
        {
            if(gamemode == GameModes.Set)
            {
                SetTutorialDone();
            }
            else
            {
                HypersetTutorialDone();
            }
        }

        public bool IsTutorialDone(GameModes gamemode)
        {
            if(gamemode == GameModes.Set)
            {
                return isSetTutorialDone;
            }
            else
            {
                return isHypersetTutorialDone;
            }
        }
    }
}
