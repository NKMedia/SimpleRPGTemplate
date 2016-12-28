using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NKM.RPGFramework
{
    //Interface for all enemies
    public interface IEnemy
    {
        void TakeDamage(int amount);
        void PerformAttack();

    }
}
