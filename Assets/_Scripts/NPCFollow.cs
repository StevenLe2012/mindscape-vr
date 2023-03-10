using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This works great, but I think this will break once
 * we have obstacles with rigid bodies/collisions in the way.
 * Perhaps make it so the NPC can just go through walls?
 */
namespace Companion
{
    public class NPCFollow : MonoBehaviour
    {
        public GameObject Player;
        public float minDistance;
        public float maxDistance;
        public float followSpeedPercent;

        [SerializeField] private LayerMask _playerMask;
        

        private float targetDistance;

        private void Start()
        {
            _playerMask = ~_playerMask;
        }

        // Update is called once per frame
        void Update()
        {
            transform.LookAt(Player.transform);
            // moves towards player
            //TODO: Create a mask for the player only
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hitData;
            Debug.DrawRay(transform.position, transform.forward * 10000, Color.red);
            if (Physics.Raycast(ray, out hitData))
            {
                Debug.DrawRay(transform.position, transform.forward * 10000, Color.red);
                targetDistance = hitData.distance;
                print(targetDistance);
                //Debug.Log(targetDistance);
                if (targetDistance > minDistance)
                {
                    //gameObject.GetComponent<Animation>().Play("running");  //TODO: Change to correct name
                    var newPosition = Player.transform.position;
                    newPosition.y += 0.55f;  // padding to have NPC not in ground
                    transform.position = Vector3.Lerp(transform.position, newPosition, followSpeedPercent);
                }
                else
                {
                    //gameObject.GetComponent<Animation>().Play("idle");  //TODO: Change to correct name
    
                }
                
                // checks for too far from player
                if (targetDistance > maxDistance)
                {
                    var newPosition = Player.transform.position;
                    newPosition.y += 0.55f;
                    transform.position = newPosition;
                }
            }
        }
    }
}

