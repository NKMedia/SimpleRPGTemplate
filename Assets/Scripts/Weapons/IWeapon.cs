using System.Collections.Generic;

namespace NKM.RPGFramework
{
    /// <summary>
    /// Author: Nico Küchler 2016
    /// 
    /// Interface for all GameObjects of type weapon.
    /// 
    /// Additional description:
    /// Interfaces serve as a contract and needs to be implemented to be used.
    /// All weapon objects need to implement this interface to make sure they have the desired components.
    /// This means they need to have a List of Stats and at least have a Methode to Perform an Attack.
    /// </summary>
    public interface IWeapon
    {
        List<BaseStat> Stats { get; set; }
        void PerformAttack();
        void PerformSpecialAttack();

    }
}
