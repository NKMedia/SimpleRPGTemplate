using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Author: Nico Küchler 2016
/// 
/// Class to deal with raycasting into the gameworld and trigger interaction on mouse clicks.
/// </summary>

namespace NKM.RPGFramework
{
    public class WorldInteraction : MonoBehaviour
    {
        NavMeshAgent playerAgent;
        void Start()
        {
            playerAgent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            //make sure that the pointer is not over an UI Element
            bool checkIsOver = EventSystem.current.IsPointerOverGameObject();

            //If left mousbutton is clicked (down) and the pointer is not over an ui element
            if (Input.GetMouseButtonDown(0) && !checkIsOver)
            {
                //Check if we are interacting with something in the world
                GetInteraction();
            }
        }

        /// <summary>
        /// Method to check for world interaction not UI elements
        /// </summary>
        void GetInteraction()
        {
            //Cast a ray from the main camera thrue the mous pointer position into the game world
            Ray inactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Create a var to store raycast related information
            RaycastHit interactionInfo;

            //if our ray hits something 
            if (Physics.Raycast(inactionRay, out interactionInfo, Mathf.Infinity))
            {
                //store the GameObject that we hit in a var by getting it from the interactionInfo
                GameObject interactedObject = interactionInfo.collider.gameObject;

                if (interactedObject.tag == "Interactable Object")
                {
                    interactedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
                    Debug.Log("This GameObject is interactable!");
                }
                else
                {
                    playerAgent.stoppingDistance = 0f;
                    playerAgent.destination = interactionInfo.point;
                  
                }

            }
        }

    }
}
