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

                // Write the save data for the Game.
                writer.WriteStartElement("Game");

                writer.WriteStartElement("Day");
                writer.WriteString(gameInstance.Day.ToString());
                writer.WriteFullEndElement();

                writer.WriteStartElement("Events");
                if (gameInstance.itemEvents.Message != null)
                {
                    foreach(string message in gameInstance.itemEvents.Message)
                    {
                        writer.WriteStartElement("Message");
                        writer.WriteString(message);
                        writer.WriteFullEndElement();
                    }
                }
                writer.WriteFullEndElement();

                // Write the save data for the Player.
                writer.WriteComment("Player Data");
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

                writer.WriteStartElement("AdditionalInventory");
                writer.WriteString(gameInstance.player.AdditionalInventory.ToString());
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

                // End Player element.
                writer.WriteFullEndElement();

                writer.WriteComment("Location Data");
                writer.WriteStartElement("Location");

                //writer.WriteStartElement("LocationIndex");
                writer.WriteStartElement("LocationName");
                writer.WriteString(gameInstance.CurrentLocation.Name);
                writer.WriteFullEndElement();

                writer.WriteStartElement("Products");
                foreach (Product p in gameInstance.CurrentLocation.CurrentProducts)
                {
                    writer.WriteStartElement("Product");

                    writer.WriteStartElement("Name");
                    writer.WriteString(p.Name);
                    writer.WriteFullEndElement();

                    writer.WriteStartElement("Price");
                    writer.WriteString(p.CurrentValue.ToString());
                    writer.WriteFullEndElement();

                    writer.WriteFullEndElement();
                }
                writer.WriteFullEndElement();

                // End Location element.
                writer.WriteFullEndElement();

                // End Game element.
                writer.WriteFullEndElement();
            }
        }

        // TODO: Maybe in the DoWhile loop we move the reader to a start tag and not worry about
        // end tags. This would skip over 1 whole Do loop after we perform the proper switch case.
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
                //reader.ReadToDescendant("Player");

                string tag = "";

                do
                {
                    // This to skip over the whitespace in between the end of an element and the start of a new one.
                    reader.MoveToContent(); 
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            tag = reader.Name;

                            if (tag == "Day")
                            {
                                reader.Read();
                                gameInstance.Day = reader.ReadContentAsInt();
                            }
                            else if (tag == "Message")
                            {
                                reader.Read();
                                gameInstance.itemEvents.Message.Add(reader.ReadContentAsString());
                            }
                            else if (tag == "Money")
                            {
                                reader.Read();
                                gameInstance.player.Money = reader.ReadContentAsInt();
                            }
                            else if (tag == "Debt")
                            {
                                reader.Read();
                                gameInstance.player.Debt = reader.ReadContentAsInt();
                            }
                            else if (tag == "Health")
                            {
                                reader.Read();
                                gameInstance.player.Health = reader.ReadContentAsInt();
                            }
                            else if (tag == "Savings")
                            {
                                reader.Read();
                                gameInstance.player.Savings = reader.ReadContentAsInt();
                            }
                            else if (tag == "AdditionalInventory")
                            {
                                reader.Read();
                                gameInstance.player.AdditionalInventory = reader.ReadContentAsInt();
                            }
                            else if (tag == "LocationName")
                            {
                                reader.Read();
                                gameInstance.CurrentLocation.Name = reader.ReadContentAsString();
                            }
                            else if (tag == "Inventory" || tag == "Products")
                            {
                                // Inventory and Products tags share the same structure just with different names.
                                // ---------------------------------------------------------------------------
                                // Inventory has multiple <Item> descendants depending on how many items the Player
                                // had in their Inventory when they saved. Each <item> has a <Key><Val> children pair.
                                string itemName;
                                int itemPrice;
                                int itemQuantity;

                                // Create a SubTree reader to read over the <Inventory> xml element and corresponding children. 
                                // We use this to iterate over the <Key><Val> pairs of each <Item> to properly get each item name and 
                                // item quantity to put them back into the players inventory.
                                using (XmlReader subReader = reader.ReadSubtree())
                                {
                                    do
                                    {
                                        // This to skip over whitespace.
                                        reader.MoveToContent();
                                        tag = subReader.Name;

                                        // For each <Item> tag, grab the Item name <Key> and Item quantity <Val>
                                        // and add it to the Player's Inventory.
                                        if (tag == "Item" && subReader.NodeType != XmlNodeType.EndElement)
                                        {
                                            subReader.ReadToDescendant("Key");
                                            subReader.Read();
                                            itemName = subReader.ReadContentAsString();

                                            subReader.ReadToNextSibling("Val");
                                            subReader.Read();
                                            itemQuantity = subReader.ReadContentAsInt();

                                            gameInstance.player.addItemsToInventory(itemName, itemQuantity);
                                        }
                                        else if (tag == "Product" && subReader.NodeType != XmlNodeType.EndElement)
                                        {
                                            subReader.ReadToDescendant("Name");
                                            subReader.Read();
                                            itemName = subReader.ReadContentAsString();

                                            subReader.ReadToNextSibling("Price");
                                            subReader.Read();
                                            itemPrice = subReader.ReadContentAsInt();

                                            gameInstance.CurrentLocation.addCurrentProduct(itemName, itemPrice);
                                        }
                                    } while (subReader.Read());
                                }
                            }
                        break;
                    }
                } while (reader.Read());
            }
        }
        // CONSIDER XELEMENT?
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
