using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Collections;

namespace NKM.RPGFramework
{
    //Item Class is derived from Interactable Class and should be the base branch class for all Action items
    public class ActionItem : Interactable
    {
        //Handles all desired interactions when we deal with an ActionItem
        public override void Interact()
        {
            //If the stuff from the base class should happen additionaly 
            //uncomment this:-> base.Interact();
            Debug.Log("Interacting with Item");
        }

    }
}