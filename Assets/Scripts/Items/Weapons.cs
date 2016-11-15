using UnityEngine;
using System.Collections;
using EquitBag.Base;

namespace EquitBag.Items
{
    public class Weapons : BaseItem
    {

        public int Attack
        {
            get;
            private set;
        }

        public Weapons(int id,string type, string name, string description, int buyPrice, int sellPrice, string icon, int attack) : base(id, type,name, description, buyPrice, sellPrice, icon)
        {
            Attack = attack;
        }

        public override string getMessage()
        {
            return base.getMessage() + Attack;
        }


    }
}
