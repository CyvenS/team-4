using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team04
{
    public class Team04WhaleSpawner : MonoBehaviour
    {
        public GameObject whale; //Variable to get the whale game object

        [SerializeField]
        private float timeUntilSpawn = 10f; //Amount of time until whale spawns

        private bool isActivated = true; //Check if the spawn manager is activated

        WhaleInteractions whaleControls; //Call the whale interactions script

        [SerializeField]
        private float timeUntilDespawn = 20f; //The time it will take until the whale despawns


        // Start is called before the first frame update
        void Start()
        {
            whaleControls = FindAnyObjectByType<WhaleInteractions>();
        }

        // Update is called once per frame
        void Update()
        {
            if(isActivated)
            {
                SpawnObject();
            }
            if (!isActivated)
            {
                timeUntilDespawn -= Time.deltaTime;

                if (timeUntilDespawn <= 0)
                {
                    timeUntilDespawn = 10.0f;
                    isActivated = true;
                    Destroy(whale.gameObject);
                }
            }

        }

        public void SpawnObject()
        {
            timeUntilSpawn -= Time.deltaTime;

            if (timeUntilSpawn <= 0)
            {                
                Instantiate(whale, transform.position, Quaternion.identity);
                isActivated = false;
                timeUntilSpawn = 10;
            }            
        }
    }
}


