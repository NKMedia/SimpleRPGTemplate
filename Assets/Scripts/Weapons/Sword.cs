using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NKM.RPGFramework
{
    public class Sword : MonoBehaviour, IWeapon
    {
        private Animator animator;
        public List<BaseStat> Stats{ get; set; }

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void PerformAttack()
        {
            Debug.Log(this.name + " performes a base attack!");
            animator.SetTrigger("Base_Attack");
        }

        public void PerformSpecialAttack()
        {
            Debug.Log(this.name + "performes a special attack!");
            animator.SetTrigger("Special_Attack");
        }

    }
}
