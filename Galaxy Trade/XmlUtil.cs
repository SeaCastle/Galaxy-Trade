using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.IO;

namespace Galaxy_Trade
{   
    class XmlUtil
    {       
        private Game gameInstance;

        public XmlUtil(ref Game g)
        {            
            gameInstance = g;
        }

        public void writeGameToXmlFile(string xmlFile)
        {
            XmlWriterSettings ws = new XmlWriterSettings();
            ws.Indent = true;

            using (FileStream fs = new FileStream(xmlFile, FileMode.Create, FileAccess.Write))
            using (XmlWriter writer = XmlWriter.Create(fs, ws))
            {
                writer.WriteProcessingInstruction("xml", "version='1.0'");
                writer.WriteComment("Game Save data for Galaxy Trade");
                writer.WriteStartElement("Game");

                // Write the save data for the Player.
                writer.WriteStartElement("Player");

                writer.WriteStartElement("Money");
                writer.WriteString(gameInstance.player.Money.ToString());
                writer.WriteFullEndElement();

                writer.WriteStartElement("Debt");                
                writer.WriteString(gameInstance.player.Debt.ToString());
                writer.WriteFullEndElement();

                writer.WriteStartElement("Health");
                writer.WriteString(gameInstance.player.Health.ToString());
                writer.WriteFullEndElement();

                writer.WriteStartElement("Savings");
                writer.WriteString(gameInstance.player.Savings.ToString());
                writer.WriteFullEndElement();

                writer.WriteStartElement("Inventory");
                foreach (string key in gameInstance.player.Inventory.Keys)
                {
                    writer.WriteStartElement("Item");

                    writer.WriteStartElement("Key");
                    writer.WriteString(key);
                    writer.WriteFullEndElement();

                    writer.WriteStartElement("Val");
                    writer.WriteString(gameInstance.player.Inventory[key].ToString());
                    writer.WriteFullEndElement();

                    writer.WriteFullEndElement();
                }                                
                writer.WriteFullEndElement();

                // End Player data.
                writer.WriteFullEndElement();

                // End Game element.
                writer.WriteFullEndElement();
            }
        }

        public void loadGameFromXmlFile(string xmlFile)
        {
            if (!File.Exists(xmlFile))
                return;

            using (FileStream fs = new FileStream(xmlFile, FileMode.Open, FileAccess.Read))
            using (XmlReader reader = XmlReader.Create(fs))
            {
                if (fs.Length < 60)
                    return;

                reader.MoveToContent();
                reader.ReadToDescendant("Player");

                string tag = "";

                do
                {
                    // This to skip over the whitespace in between the end of an element and the start of a new one.
                    reader.MoveToContent(); 
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            tag = reader.Name;

                            if (tag == "Money")
                            {
                                reader.Read();
                                gameInstance.player.Money = Int32.Parse(reader.Value);
                            }
                            else if (tag == "Debt")
                            {
                                reader.Read();
                                gameInstance.player.Debt = Int32.Parse(reader.Value);
                            }
                            else if (tag == "Health")
                            {
                                reader.Read();
                                gameInstance.player.Health = Int32.Parse(reader.Value);
                            }
                            else if (tag == "Savings")
                            {
                                reader.Read();
                                gameInstance.player.Savings = Int32.Parse(reader.Value);
                            }
                            else if (tag == "Inventory")
                            {
                                gameInstance.player.Inventory.Clear();
                            }
                            break;
                    }
                } while (reader.Read());
            }
        }

        /*
        public void savePlayerToFile(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                XmlSerializer XML = new XmlSerializer(typeof(Player));
                XML.Serialize(fs, player);
            }
        }
        */
    }
}
