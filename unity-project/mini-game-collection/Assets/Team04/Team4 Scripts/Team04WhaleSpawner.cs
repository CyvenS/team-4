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
        private float minTimer; //Setting the minimum time to spawn 

        [SerializeField]
        private float maxTimer; //Setting the maximum time to spawn 

        private float timeUntilSpawn; //Amount of time until whale spawns

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            timeUntilSpawn -= Time.deltaTime;

            if (timeUntilSpawn <= 0)
            {
                GameObject spawnWhale = Instantiate(whale, transform.position, Quaternion.identity);
                spawnWhale.GetComponent<WhaleInteractions>();
                SetSpawnTime();
            }                       

        }

        private void SetSpawnTime()
        {
            timeUntilSpawn = Random.Range(minTimer, maxTimer); //Randomize the time until spawn
        }
    }
}


