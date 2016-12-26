using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Collections;


namespace NKM.RPGFramework
{
    //Class that all interactable objects can derive from
    public class Interactable : MonoBehaviour
    {
        [HideInInspector]
        public NavMeshAgent playerAgent;
        private bool hasInteracted;



        void Update()
        {
            //If we have not yet interacted! Check if there is a playerAgent and if the Path to the target has been calculated already.
            if (!hasInteracted && playerAgent != null && !playerAgent.pathPending)
            {
                //If we then have reached the target...
                if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
                {

                    //...interact with it and set the flag.
                    Interact();
                    hasInteracted = true;
                }
            }
        }

        //When clicked on an interactable object we pass the active playerAgent to this GO and let the playerAgent move to this objects position
        public virtual void MoveToInteraction(NavMeshAgent playerAgent)
        {
            hasInteracted = false;
            this.playerAgent = playerAgent;

            //Make the agent stop 2 units before it reaches the object.
            playerAgent.stoppingDistance = 2f;

            //Make the player move to the object
            playerAgent.destination = this.transform.position;
        }


        public virtual void Interact()
        {
            Debug.Log("Interacting with base class Interact");
        }
    }
}
