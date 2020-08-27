using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace SetTheGame.Model
{
    public class IOLeaderboard
    {
        private static readonly string setPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "setLeaderboard.xml");
        private static readonly string hypersetPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "hypersetLeaderboard.xml");
        public static Leaderboard ChargeLeaderboard(GameModes mode)
        {
            string rightPath = mode == GameModes.Set ? setPath : hypersetPath;
            try
            {
                using(FileStream fs = new FileStream(rightPath, FileMode.Open))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(Leaderboard));
                    Leaderboard lb = (Leaderboard)ser.Deserialize(fs);
                    return lb;
                }
            }
            catch
            {
                return new Leaderboard();
            }
        }

        public static void SaveLeaderboard(Leaderboard toSave, GameModes mode)
        {
            string rightPath = mode == GameModes.Set ? setPath : hypersetPath;
            using (TextWriter writer = new StreamWriter(rightPath))
            {
                XmlSerializer ser = new XmlSerializer(typeof(Leaderboard));
                ser.Serialize(writer, toSave);
            }
        }
    }
}
