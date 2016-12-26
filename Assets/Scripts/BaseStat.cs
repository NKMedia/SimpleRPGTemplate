using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NKM.RPGFramework
{
    public class BaseStat
    {
        #region public Properties
        public List<StatBonus> BaseAdditives { get; set; }
        public int BaseValue { get; set; }
        public string StatName { get; set; }
        public string StatDescription { get; set; }
        public int FinalValue { get; set; }
        #endregion

        #region BaseStat CTOR
        public BaseStat(int baseValue, string statName, string statDescription)
        {
            this.BaseAdditives = new List<StatBonus>();
            this.BaseValue = baseValue;
            this.StatName = statName;
            this.StatDescription = statDescription;
        }
        #endregion

        public void AddStatBonus(StatBonus statBonus)
        {
            this.BaseAdditives.Add(statBonus);
        }

        public void RemoveStatBonus(StatBonus statBonus)
        {
            this.BaseAdditives.Remove(BaseAdditives.Find(x=> x.BonusValue == statBonus.BonusValue));
        }

        public int GetCalcutatedStatValue()
        {
            this.FinalValue = 0;

            //Add all bonuses together
            this.BaseAdditives.ForEach(x => this.FinalValue += x.BonusValue);

            //Add the BaseValue
            FinalValue += BaseValue;
            return FinalValue;
        }

    }
}
