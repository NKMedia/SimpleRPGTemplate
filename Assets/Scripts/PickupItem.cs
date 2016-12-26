using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Collections;

namespace NKM.RPGFramework
{
    //Item Class is derived from Interactable Class
    [System.Serializable]
    public class PickupItem : Interactable
    {
        public string itemName;    //Name of the item
        public string itemWeight;  //Weight of the item
        public string itemPrice;   //Price of the item

        public string descriptionText; // Additional information on this item

        public bool isStackable = true; // can this item be stacked in the inventory
        public bool isCombineable = false; //can something be crafted with this item. Default false

        //Handles all desired interactions when we deal with an PickupItem
        public override void Interact()
        {
            
            Debug.Log("Interacting with " + itemName);


        }

    }
}