using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Server_Controller
{
    public class Account //1588 Bytes Unused At Top (Client.Dat)
    {
        //Used for all the data currently unknown
        public byte[] fillerBytes = new byte[5100];

        public char[] accountName = new char[20];
        public char[] accountPassword = new char[20];
        public char[] accountEmail = new char[100];

        //45 Bytes to fillerBytes

        public char[] lastText = new char[300];

    }

    public class Rules
    {
        public bool boolOffset;
        public bool boolOffset2;
        public int UUID;
        public char[] strRule = new char[200];
        public byte[] bByte = new byte[101];
    }

    public class MOTD
    {
        public char[] motd = new char[200];
    }

    public class Player
    {
        //Used for all the data currently unknown
        public byte[] fillerBytes = new byte[5100];

        //Start of Player.Dat
        public bool exists1;
        public bool exists2;

        public char[] accountName = new char[20];

        public short accountUUID;
        
        //2 Bytes To fillerBytes

        public char[] playerName = new char[50];

        public short xPosCurrent;
        public short yPosCurrent;
        public short zPosCurrent;

        public short xPosPrevious;
        public short yPosPrevious;
        public short zPosPrevious;

        //14 Bytes to fillerBytes

        public short currentLife;
        public short maxLife;

        //2 Bytes to fillerBytes

        public short currentStam;
        public short maxStam;

        //4 Bytes to fillerBytes

        public short currentMana;
        public short maxMana;

        //2 Bytes to fillerBytes

        public short strength;

        //2 Bytes to fillerBytes

        public short dexterity;

        //2 Bytes to fillerBytes

        public short quickness;

        //2 Bytes to fillerBytes

        public short intelligence;

        //2 Bytes to fillerBytes

        public short wisdom;

        //2 Bytes to fillerBytes

        public short level;

        public int neededXp;

        public short skillPoints;

        public int spendableXp;

        public int totalXp;

        //4 Bytes to fillerBytes

        public short xPosAttuned;
        public short yPosAttuned;
        public short zPosAttuned;

        //32 Bytes to fillerBytes

        public ItemData[] inventory = new ItemData[SQLWriter.MAX_INVENTORY_SLOTS];
        public ItemData[] equipped = new ItemData[SQLWriter.MAX_EQUIP_SLOTS];

        //26 Bytes to fillerBytes

        public byte heroBuffAmount;

        public byte heroBuffDuration;

        //99 Bytes to fillerBytes

        public SkillData[] skills = new SkillData[SQLWriter.MAX_SKILL_SLOTS];

        //1270 Bytes to fillerBytes

        public short strengthBuffAmount;
        public short strengthBuffDuration;

        public short dexterityBuffAmount;
        public short dexterityBuffDuration;

        public short quicknessBuffAmount;
        public short quicknessBuffDuration;

        public short intelligenceBuffAmount;
        public short intelligenceBuffDuration;

        public short wisdomBuffAmount;
        public short wisdomBuffDuration;

        //3700 Bytes to fillerBytes
    }

    public class ItemData
    {
        //Used for all the data currently unknown
        public byte[] fillerBytes = new byte[177];

        public short itemNumber;

        //18 Bytes to fillerBytes

        public short itemCount;

        //159 Bytes to fillerBytes
    }

    public class SkillData
    {
        //Used for all the data currently unknown
        public byte[] fillerBytes = new byte[69];

        public bool skillLearned1;
        public bool skillLearned2;
        public short skillLevelBase;
        public short skillLevelIncreased;

        //10 Bytes to fillerBytes

        public byte skillBonus;

        //58 Bytes to fillerBytes

        //Will be used later for base + increased + hero bonus
        public short skillLevelActual;

    }

    public class SkillIniData
    {
        public string name;
        public byte strength;
        public byte dexterity;
        public byte quickness;
        public byte intelligence;
        public byte wisdom;
        public byte divisor;
    }

    public class ItemIniData
    {
        public string itemName;
        public List<int> itemImages;
    }
}