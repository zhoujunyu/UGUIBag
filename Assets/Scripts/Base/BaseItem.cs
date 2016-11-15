using UnityEngine;
using System.Collections;

namespace EquitBag.Base
{
    public class BaseItem
    {
        public int ID
        {
            get;
            private set;
        }

        public string Type
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;

        }

        public string Description
        {
            get;
            private set;
        }
        public int BuyPrice
        {
            get;
            private set;
        }

        public int SellPrice
        {
            get;
            private set;
        }

        public string Icon
        {
            get;
            private set;
        }

        public BaseItem(int id,string type, string name, string description, int buyprice, int sellprice, string icon)
        {
            ID = id;
            Type = type;
            Name = name;
            Description = description;
            BuyPrice = buyprice;
            SellPrice = sellprice;
            Icon = icon;

        }

        public virtual string getMessage()
        {
            return ID + " " +Type + " "+ Name + " " + Description + " " + BuyPrice + " " + SellPrice + " " + Icon + " "; 
        }

    }

}
