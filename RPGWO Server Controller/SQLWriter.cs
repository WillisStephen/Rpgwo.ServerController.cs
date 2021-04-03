using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace RPGWO_Server_Controller
{
    public class SQLWriter
    {
        public static int MAX_INVENTORY_SLOTS = 80;
        public static int MAX_EQUIP_SLOTS = 12 + 2;  // + 2 as there are is dummy bytes for unused slots.
        public static int MAX_SKILL_SLOTS = 60;

        public static void BuildSQLTables()
        {
            StringBuilder query = new StringBuilder();

            query.Append(SQLCreation.DatabaseCreate());
            //query.Append(SQLCreation.OnlinePlayers());
            //query.Append(SQLCreation.Players());
            //query.Append(SQLCreation.Players_Inventory());
            //query.Append(SQLCreation.Players_Equipment());
            query.Append(SQLCreation.Players_Skills());

            MySqlCommand command = new MySqlCommand(query.ToString(), ConnectionHandler.connection);
            command.ExecuteNonQuery();

        }

        public static void UpdatePlayerData()
        {
            TruncateTable("players");
            TruncateTable("players_inventory");
            TruncateTable("players_equipment");
            TruncateTable("players_skills");

            StringBuilder players_query = new StringBuilder("INSERT INTO players (Account, AccountUUID, " +
                "Name, Level, XpNeeded, XpSpendable, XpTotal, SkillPoints, XCoord, YCoord, ZCoord, " +
                "CurrentLife, MaxLife, CurrentStamina, MaxStamina, CurrentMana, MaxMana, " +
                "Strength, Dexterity, Quickness, Intelligence, Wisdom, XAttuned, YAttuned, ZAttuned, " +
                "HeroBuff, HeroDuration, StrengthBuff, StrengthDuration, DexterityBuff, DexterityDuration, " +
                "QuicknessBuff, QuicknessDuration, IntelligenceBuff, IntelligenceDuration, " +
                "WisdomBuff, WisdomDuration) VALUES ");

            StringBuilder players_equipment_query = new StringBuilder("INSERT INTO players_equipment VALUES ");
            StringBuilder players_inventory_query = new StringBuilder("INSERT INTO players_inventory VALUES ");
            StringBuilder players_skills_query = new StringBuilder("INSERT INTO players_skills VALUES ");

            foreach (Player player in DATReader.players)
            {
                if (player.exists1)
                {
                    string cacheString = new string(player.accountName);
                    players_query.Append("('" + cacheString.Trim() + "',");

                    players_query.Append(player.accountUUID + ",");

                    cacheString = new string(player.playerName);
                    players_query.Append("'" + cacheString.Trim() + "',");

                    players_query.Append(player.level + ",");
                    players_query.Append(player.neededXp + ",");
                    players_query.Append(player.spendableXp + ",");
                    players_query.Append(player.totalXp + ",");
                    players_query.Append(player.skillPoints + ",");
                    players_query.Append(player.xPosCurrent + ",");
                    players_query.Append(player.yPosCurrent + ",");
                    players_query.Append(player.zPosCurrent + ",");
                    players_query.Append(player.currentLife + ",");
                    players_query.Append(player.maxLife + ",");
                    players_query.Append(player.currentStam + ",");
                    players_query.Append(player.maxStam + ",");
                    players_query.Append(player.currentMana + ",");
                    players_query.Append(player.maxMana + ",");
                    players_query.Append(player.strength + ",");
                    players_query.Append(player.dexterity + ",");
                    players_query.Append(player.quickness + ",");
                    players_query.Append(player.intelligence + ",");
                    players_query.Append(player.wisdom + ",");
                    players_query.Append(player.xPosAttuned + ",");
                    players_query.Append(player.yPosAttuned + ",");
                    players_query.Append(player.zPosAttuned + ",");
                    players_query.Append(player.heroBuffAmount + ",");
                    players_query.Append(player.heroBuffDuration + ",");
                    players_query.Append(player.strengthBuffAmount + ",");
                    players_query.Append(player.strengthBuffDuration + ",");
                    players_query.Append(player.dexterityBuffAmount + ",");
                    players_query.Append(player.dexterityBuffDuration + ",");
                    players_query.Append(player.quicknessBuffAmount + ",");
                    players_query.Append(player.quicknessBuffDuration + ",");
                    players_query.Append(player.intelligenceBuffAmount + ",");
                    players_query.Append(player.intelligenceBuffDuration + ",");
                    players_query.Append(player.wisdomBuffAmount + ",");
                    players_query.Append(player.wisdomBuffDuration);


                    players_skills_query.Append("('" + cacheString.Trim() + "',");
                    for (int i = 0; i < player.skills.Length; i++)
                    {
                        if (INIReader.skills.ContainsKey(i + 1))
                            players_skills_query.Append("'" + INIReader.skills[i + 1].name + "',");
                        else
                            players_skills_query.Append("'',");
                        
                        if (player.skills[i].skillLearned1)
                        {
                            if(i == (MAX_SKILL_SLOTS - 1))
                                players_skills_query.Append(player.skills[i].skillLevelActual);
                            else
                                players_skills_query.Append(player.skills[i].skillLevelActual + ",");
                        }
                        else
                        {
                            if (i == (MAX_SKILL_SLOTS - 1))
                                players_skills_query.Append(0);
                            else
                                players_skills_query.Append(0 + ",");
                        }
                    }

                    players_inventory_query.Append("('" + cacheString.Trim() + "',");
                    for (int i = 0; i < player.inventory.Length; i++)
                    {
                        if (player.inventory[i].itemCount > 0 && player.inventory[i].itemNumber > 0)
                        {
                            if (i == (MAX_INVENTORY_SLOTS - 1))
                                    players_inventory_query.Append("'" + INIReader.items[player.inventory[i].itemNumber].itemName + "'," + player.inventory[i].itemCount);
                            else
                                    players_inventory_query.Append("'" + INIReader.items[player.inventory[i].itemNumber].itemName + "'," + player.inventory[i].itemCount + ",");

                        }
                        else
                        {
                            if (i == (MAX_INVENTORY_SLOTS - 1))
                                players_inventory_query.Append("''" + "," + 0);
                            else
                                players_inventory_query.Append("''" + "," + 0 + ",");
                        }
                    }

                    players_equipment_query.Append("('" + cacheString.Trim() + "',");
                    for (int i = 0; i < player.equipped.Length; i++)
                    {
                        if (player.equipped[i].itemCount > 0 && player.equipped[i].itemNumber > 0)
                        {
                            if (i == (MAX_EQUIP_SLOTS - 1))
                                players_equipment_query.Append("'" + INIReader.items[player.equipped[i].itemNumber].itemName + "'");
                            else
                                players_equipment_query.Append("'" + INIReader.items[player.equipped[i].itemNumber].itemName + "',");
                        }
                        else
                        {
                            if (i == (MAX_EQUIP_SLOTS - 1))
                                players_equipment_query.Append("''");
                            else
                                players_equipment_query.Append("''" + ",");
                        }
                    }

                    players_query.Append("),");
                    players_skills_query.Append("),");
                    players_inventory_query.Append("),");
                    players_equipment_query.Append("),");

                }

            }

            players_query.Length -= 2;
            players_skills_query.Length -= 2;
            players_inventory_query.Length -= 2;
            players_equipment_query.Length -= 2;

            players_query.Append(");");
            players_skills_query.Append(");");
            players_inventory_query.Append(");");
            players_equipment_query.Append(");");

            //MySqlCommand command = new MySqlCommand(players_query.ToString(), ConnectionHandler.connection);
            //command.ExecuteNonQuery();

            MySqlCommand command = new MySqlCommand(players_skills_query.ToString(), ConnectionHandler.connection);
            command.ExecuteNonQuery();

            //command = new MySqlCommand(players_inventory_query.ToString(), ConnectionHandler.connection);
            //command.ExecuteNonQuery();

            //command = new MySqlCommand(players_equipment_query.ToString(), ConnectionHandler.connection);
            //command.ExecuteNonQuery();
        }

        public static void BuildWhosOnlineData()
        {
            TruncateTable("onlinePlayers");

            if (ConnectionHandler.whosOnline.Count == 0)
                return;

            StringBuilder query = new StringBuilder("INSERT INTO onlineplayers (PlayerName) VALUES ");

            List<string> players = new List<string>();
            foreach(string player in ConnectionHandler.whosOnline)
            {
                players.Add("('" + player.Trim() + "')");
            }

            query.Append(string.Join(",", players));
            query.Append(";");

            MySqlCommand command = new MySqlCommand(query.ToString(), ConnectionHandler.connection);

            command.ExecuteNonQuery();
        }

        public static void TruncateTable(string table)
        {
            string query = "TRUNCATE TABLE " + table;

            MySqlCommand command = new MySqlCommand(query, ConnectionHandler.connection);

            command.ExecuteNonQuery();
        }

        public static void UpdateItemIniData()
        {

        }
    }
}
