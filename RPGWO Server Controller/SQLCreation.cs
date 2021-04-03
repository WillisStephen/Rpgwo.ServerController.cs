using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Server_Controller
{
    public class SQLCreation
    {
        public static string DatabaseCreate()
        {
            string query = "CREATE DATABASE IF NOT EXISTS `rpgwo_test`";

            return query;
        }

        public static string OnlinePlayers()
        {
            string query = "CREATE TABLE IF NOT EXISTS onlineplayers" +
                        "(" +
                        "Id INT(11) NOT NULL AUTO_INCREMENT," +
                        "PlayerName VARCHAR(50)," +
                        "Primary Key(Id)" +
                        ");";

            return query;
        }

        public static string Players()
        {
            string query = "CREATE TABLE IF NOT EXISTS players" +
                        "(" +
                        "Id INT(11) NOT NULL AUTO_INCREMENT," +
                        "Account NVARCHAR(20)," +
                        "AccountUUID INT(11)," +
                        "Name NVARCHAR(50)," +
                        "Level SMALLINT(10)," +
                        "XpNeeded INT(10)," +
                        "XpSpendable INT(10)," +
                        "XpTotal INT(10)," +
                        "SkillPoints SMALLINT(10)," +
                        "XCoord SMALLINT(10)," +
                        "YCoord SMALLINT(10)," +
                        "ZCoord SMALLINT(10)," +
                        "CurrentLife SMALLINT(10)," +
                        "MaxLife SMALLINT(10)," +
                        "CurrentStamina SMALLINT(10)," +
                        "MaxStamina SMALLINT(10)," +
                        "CurrentMana SMALLINT(10)," +
                        "MaxMana SMALLINT(10)," +
                        "Strength SMALLINT(10)," +
                        "Dexterity SMALLINT(10)," +
                        "Quickness SMALLINT(10)," +
                        "Intelligence SMALLINT(10)," +
                        "Wisdom SMALLINT(10)," +
                        "XAttuned SMALLINT(10)," +
                        "YAttuned SMALLINT(10)," +
                        "ZAttuned SMALLINT(10)," +
                        "HeroBuff SMALLINT(10)," +
                        "HeroDuration SMALLINT(10)," +
                        "StrengthBuff SMALLINT(10)," +
                        "StrengthDuration SMALLINT(10)," +
                        "DexterityBuff SMALLINT(10)," +
                        "DexterityDuration SMALLINT(10)," +
                        "QuicknessBuff SMALLINT(10)," +
                        "QuicknessDuration SMALLINT(10)," +
                        "IntelligenceBuff SMALLINT(10)," +
                        "IntelligenceDuration SMALLINT(10)," +
                        "WisdomBuff SMALLINT(10)," +
                        "WisdomDuration SMALLINT(10)," +
                        "Primary Key(Id)" +
                        ");";

            return query;
        }

        public static string Players_Inventory()
        {
            string query = "CREATE TABLE IF NOT EXISTS players_inventory" +
                        "(" +
                        "PlayerName NVARCHAR(50),";

            int slot = 1;
            for (int i = 0; i < SQLWriter.MAX_INVENTORY_SLOTS; i++)
            {
                query += "ItemName" + slot + " NVARCHAR(50)," +
                        "ItemCount" + slot + " INT(11),";
                slot++;
            }

            query += "Primary Key(PlayerName)" +
                        ");";

            return query;
        }

        public static string Players_Equipment()
        {
            string query = "CREATE TABLE IF NOT EXISTS players_equipment" +
                        "(" +
                        "PlayerName NVARCHAR(50),";

            int slot = 1;
            for (int i = 0; i < SQLWriter.MAX_EQUIP_SLOTS; i++)
            {
                query += "EquipName" + slot + " NVARCHAR(50),";
                slot++;
            }

            query += "Primary Key(PlayerName)" +
                        ");";

            return query;

        }

        public static string Players_Skills()
        {
            string query = "CREATE TABLE IF NOT EXISTS players_skills" +
                        "(" +
                        "PlayerName NVARCHAR(50),";
            int slot = 1;
            for (int i = 0; i < SQLWriter.MAX_SKILL_SLOTS; i++)
            {
                query += "SkillName" + slot + " NVARCHAR(50)," +
                        "SkillLevel" + slot + " INT(11),";
                slot++;
            }
            query += "Primary Key(PlayerName)" +
                        ");";

            return query;
        }
    }
}
