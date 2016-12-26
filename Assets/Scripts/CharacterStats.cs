using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NKM.RPGFramework
{
    public class CharacterStats : MonoBehaviour
    {

        public List<BaseStat> stats = new List<BaseStat>();

        void Start()
        {
            stats.Add(new BaseStat(4, "Power", "Your power level."));
            stats.Add(new BaseStat(2, "Vitality", "Your vitality level."));
           
        }

        public void AddStatBonus(List<BaseStat> statBonuses)
        {
            foreach (BaseStat statBonus in statBonuses)
            {
                //Look for the Charakterstat in stats that matches this statBonus.StatName and add this.statBonus.BaseValue to it.
                //This can be used with all kinds of items, but for example will be called when we equipt a weapon. 
                stats.Find(x=> x.StatName == statBonus.StatName).AddStatBonus(new StatBonus(statBonus.BaseValue));
            }
        }

        public void RemoveStatBonus(List<BaseStat> statBonuses)
        {
            foreach (BaseStat statBonus in statBonuses)
            {
                //Look for the Charakterstat in stats that matches this statBonus.StatName and remove this.statBonus.BaseValue form it.
                //This can be used with all kinds of items, but for example will be called when we unequipt a weapon. 
                stats.Find(x => x.StatName == statBonus.StatName).RemoveStatBonus(new StatBonus(statBonus.BaseValue));

            }
        }
    }
}