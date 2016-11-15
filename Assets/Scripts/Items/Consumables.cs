using UnityEngine;
using System.Collections;
using EquitBag.Base;

namespace EquitBag.Items
{
    public class Consumables : BaseItem
    {

        public int BackHP
        {
            get;
            private set;
        }
        public int BackMP
        {
            get;
            private set;
        }

        public Consumables(int id,string type, string name, string description, int buyPrice, int sellPrice, string icon, int backHP, int backMP) : base(id,type, name, description, buyPrice, sellPrice, icon)
        {
            BackHP = backHP;
            BackMP = backMP;
        }

        public override string getMessage()
        {
            return base.getMessage() + BackHP + " " +BackMP;
        }
    }

}

