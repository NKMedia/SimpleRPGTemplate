using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NKM.RPGFramework
{
    public class Goblin : MonoBehaviour, IEnemy
    {
        public float maxHealth;
        public float power;
        public float toughness;

        private float currentHealth;

        void Start()
        {
            currentHealth = maxHealth;
        }

        public void PerformAttack()
        {
            Debug.Log("Not yet implemented");
        }

        public void TakeDamage(int amount)
        {
            currentHealth -= amount;
            Debug.Log("Goblin took 2 damage! Hit him harder!");
            if (currentHealth <= 0)
            {
                HandleDeath();
            }
        }

        public void HandleDeath()
        {
            Debug.Log("You murdered the poor Goblin! He didn´t even do anything to you! Maybe thats because he can´t at the moment :-)");
            Destroy(this.gameObject);
        }
    }
}

