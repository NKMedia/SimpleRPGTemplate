using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Collections;


namespace NKM.RPGFramework
{
    //NPC Class is derived from Interactable Class
    public class NPC : Interactable
    {
        public string npcName;
        public string[] dialogue;

        //Handles all desired interactions when we deal with an NPC
        public override void Interact()
        {
            DialougeSystem.Instance.AddNewDialouge(dialogue, npcName);

            Debug.Log("Interacting with NPC" + npcName);
        }
        
    }
}
