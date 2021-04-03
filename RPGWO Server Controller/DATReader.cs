using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Server_Controller
{
    public class DATReader
    {
        public static List<Rules> rules = new List<Rules>();
        public static List<MOTD> MOTD = new List<MOTD>();
        public static List<Player> players = new List<Player>();

        public static float durationOffset = 7.76f;

        public static void ReadRules()
        {
            rules.Clear();

            using (BinaryReader reader = new BinaryReader(File.OpenRead((Config.serverPath + Config.dataFolder + "/rules.dat"))))
            {
                int throwAway = reader.ReadInt32();

                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    Rules ruleType = new Rules
                    {
                        boolOffset = reader.ReadBoolean(),
                        boolOffset2 = reader.ReadBoolean(),
                        UUID = reader.ReadInt32(),
                        strRule = reader.ReadChars(200),
                        bByte = reader.ReadBytes(101),
                    };
                    rules.Add(ruleType);
                }
            }
        }

        public static void ReadMOTD()
        {
            MOTD.Clear();

            using (BinaryReader reader = new BinaryReader(File.OpenRead((Config.serverPath + Config.dataFolder + "/motd.dat"))))
            {
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    MOTD motd = new MOTD
                    {
                        motd = reader.ReadChars(200),
                    };
                    MOTD.Add(motd);
                }
            }
        }

        public static void ReadPlayers()
        {
            players.Clear();

            using (BinaryReader reader = new BinaryReader(File.OpenRead((Config.serverPath + Config.dataFolder + "/player.dat"))))
            {
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    List<byte> cache = new List<byte>();
                    List<byte> itemCache = new List<byte>();
                    byte[] bytes = new byte[5000];
                    Player player = new Player();

                    player.inventory = new ItemData[80];
                    player.equipped = new ItemData[14];
                    player.skills = new SkillData[60];

                    player.exists1 = reader.ReadBoolean();
                    player.exists2 = reader.ReadBoolean();

                    player.accountName = reader.ReadChars(20);

                    player.accountUUID = reader.ReadInt16();

                    bytes = reader.ReadBytes(2);
                    cache.AddRange(bytes);

                    player.playerName = reader.ReadChars(50);

                    player.xPosCurrent = reader.ReadInt16();
                    player.yPosCurrent = reader.ReadInt16();
                    player.zPosCurrent = reader.ReadInt16();

                    player.xPosPrevious = reader.ReadInt16();
                    player.yPosPrevious = reader.ReadInt16();
                    player.zPosPrevious = reader.ReadInt16();

                    bytes = reader.ReadBytes(14);
                    cache.AddRange(bytes);

                    player.currentLife = reader.ReadInt16();
                    player.maxLife = reader.ReadInt16();

                    bytes = reader.ReadBytes(2);
                    cache.AddRange(bytes);

                    player.currentStam = reader.ReadInt16();
                    player.maxStam = reader.ReadInt16();

                    bytes = reader.ReadBytes(4);
                    cache.AddRange(bytes);

                    player.currentMana = reader.ReadInt16();
                    player.maxMana = reader.ReadInt16();

                    bytes = reader.ReadBytes(2);
                    cache.AddRange(bytes);

                    player.strength = reader.ReadInt16();

                    bytes = reader.ReadBytes(2);
                    cache.AddRange(bytes);

                    player.dexterity = reader.ReadInt16();

                    bytes = reader.ReadBytes(2);
                    cache.AddRange(bytes);

                    player.quickness = reader.ReadInt16();

                    bytes = reader.ReadBytes(2);
                    cache.AddRange(bytes);

                    player.intelligence = reader.ReadInt16();

                    bytes = reader.ReadBytes(2);
                    cache.AddRange(bytes);

                    player.wisdom = reader.ReadInt16();

                    bytes = reader.ReadBytes(2);
                    cache.AddRange(bytes);

                    player.level = reader.ReadInt16();

                    player.neededXp = reader.ReadInt32();

                    player.skillPoints = reader.ReadInt16();

                    player.spendableXp = reader.ReadInt32();

                    player.totalXp = reader.ReadInt32();

                    bytes = reader.ReadBytes(4);
                    cache.AddRange(bytes);

                    player.xPosAttuned = reader.ReadInt16();
                    player.yPosAttuned = reader.ReadInt16();
                    player.zPosAttuned = reader.ReadInt16();

                    bytes = reader.ReadBytes(32);
                    cache.AddRange(bytes);

                    for (int i = 0; i < player.inventory.Length; i++)
                    {
                        ItemData itemData = new ItemData();

                        itemCache.Clear();

                        itemData.itemNumber = reader.ReadInt16();

                        bytes = reader.ReadBytes(18);
                        itemCache.AddRange(bytes);

                        itemData.itemCount = reader.ReadInt16();

                        bytes = reader.ReadBytes(159);
                        itemCache.AddRange(bytes);

                        itemData.fillerBytes = itemCache.ToArray();

                        player.inventory[i] = itemData;
                    }

                    for (int i = 0; i < player.equipped.Length; i++)
                    {
                        ItemData itemData = new ItemData();

                        itemCache.Clear();

                        itemData.itemNumber = reader.ReadInt16();

                        bytes = reader.ReadBytes(18);
                        itemCache.AddRange(bytes);

                        itemData.itemCount = reader.ReadInt16();

                        bytes = reader.ReadBytes(159);
                        itemCache.AddRange(bytes);

                        itemData.fillerBytes = itemCache.ToArray();

                        player.equipped[i] = itemData;
                    }

                    bytes = reader.ReadBytes(26);
                    cache.AddRange(bytes);

                    player.heroBuffAmount = reader.ReadByte();
                    player.heroBuffDuration = reader.ReadByte();

                    bytes = reader.ReadBytes(99);
                    cache.AddRange(bytes);

                    for (int i = 0; i < player.skills.Length; i++)
                    {
                        SkillData skill = new SkillData();

                        skill.skillLearned1 = reader.ReadBoolean();
                        skill.skillLearned2 = reader.ReadBoolean();
                        skill.skillLevelBase = reader.ReadInt16();
                        skill.skillLevelIncreased = reader.ReadInt16();

                        skill.fillerBytes = reader.ReadBytes(10);

                        skill.skillBonus = reader.ReadByte();

                        skill.fillerBytes = reader.ReadBytes(58);

                        if (skill.skillLearned1)
                            skill.skillLevelActual = (short)(skill.skillLevelBase + skill.skillLevelIncreased + player.heroBuffAmount + skill.skillBonus);

                        player.skills[i] = skill;
                    }

                    bytes = reader.ReadBytes(1271);
                    cache.AddRange(bytes);

                    player.strengthBuffAmount = reader.ReadInt16();
                    player.strengthBuffDuration = reader.ReadInt16();

                    player.dexterityBuffAmount = reader.ReadInt16();
                    player.dexterityBuffDuration = reader.ReadInt16();

                    player.quicknessBuffAmount = reader.ReadInt16();
                    player.quicknessBuffDuration = reader.ReadInt16();

                    player.intelligenceBuffAmount = reader.ReadInt16();
                    player.intelligenceBuffDuration = reader.ReadInt16();

                    player.wisdomBuffAmount = reader.ReadInt16();
                    player.wisdomBuffDuration = reader.ReadInt16();

                    bytes = reader.ReadBytes(3689);
                    cache.AddRange(bytes);

                    player.fillerBytes = cache.ToArray();
                    players.Add(player);
                }
            }

            SQLWriter.UpdatePlayerData();
        }

    }
}
