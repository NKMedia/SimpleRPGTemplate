using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NKM.RPGFramework
{
    public class InventoryController : MonoBehaviour
    {
        public PlayerWeaponController playerWeaponController;
        public Item sword;

        void Start()
        {
            playerWeaponController = GetComponent<PlayerWeaponController>();
            List<BaseStat> swordStats = new List<BaseStat>();
            swordStats.Add(new BaseStat(6, "Power", "Your power level."));
            sword = new Item(swordStats, "sword");
        }

        void Update()
        {
            //Testing Weapon Epuiping Methodes
            if (Input.GetKeyDown(KeyCode.E))
            {
                playerWeaponController.EquipWeapon(sword);
            }
        }
    }
}
