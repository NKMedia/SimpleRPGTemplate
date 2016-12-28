using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NKM.RPGFramework
{
    public class PlayerWeaponController : MonoBehaviour
    {
        public GameObject playerHand;
        public GameObject EquippedWeapon { get; set; }

        public IWeapon iWeapon;

        CharacterStats charakterStats;
        void Start()
        {
            charakterStats = GetComponent<CharacterStats>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                PerformWeaponAttack();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                PerformSpecialAttack();
            }
        }

        public void EquipWeapon(Item itemToEquip)
        {
            //If there is a weapon equipped at the moment...
            if (EquippedWeapon != null)
            {
                //...remove its bonuses (Stats) from the charakterStats and Destory the weapon in the charakters hand.
                charakterStats.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
                Destroy(playerHand.transform.GetChild(0).gameObject);

            }//Hand is now empty or was empty already

            //Add new Weapon to the hand
            EquippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug), playerHand.transform.position, playerHand.transform.rotation);
            iWeapon = EquippedWeapon.GetComponent<IWeapon>();

            //Add the stats of the new Weapon
            iWeapon.Stats = itemToEquip.Stats;
            charakterStats.AddStatBonus(itemToEquip.Stats);

            //Parent the new item to the player hand item slot
            EquippedWeapon.transform.SetParent(playerHand.transform);
        }

        public void PerformWeaponAttack()
        {
            iWeapon.PerformAttack();
        }

        public void PerformSpecialAttack()
        {
            iWeapon.PerformSpecialAttack();
        }
    }
}
