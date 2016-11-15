using UnityEngine;
using System.Collections;
using EquitBag.Base;

namespace EquitBag.Items
{

    public class Armors : BaseItem
    {

        public int Defense
        {
            get;
            private set;
        }

        public Armors(int id, string type,string name, string description, int buyPrice, int sellPrice, string icon, int defense) : base(id, type,name, description, buyPrice, sellPrice, icon)
        {
            Defense = defense;
        }

        public override string getMessage()
        {
            return base.getMessage() + Defense;
        }

    }

}

