using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team04
{
    public class WhaleInteractions : MonoBehaviour
    {
        public float whaleSpeed = 5f;

        //[SerializeField] private int playerID = 0; //Get the player ID 
        public Vector2[] startingPos; //Variable to hold multiple starting positions of the whale
        [SerializeField] private Vector2[] targetPos; //Variable to set the target positions

        private Vector2 targetPosition;
        private Vector2 currentPos;

        [SerializeField]
        private float timeUntilAction = 10f; //The time it will take until the whale moves

        [SerializeField]
        private float timeUntilDespawn = 10f; //The time it will take until the whale despawns

        public bool isDestroyed = false; //Check if the whale has been destroyed in scene

        // Start is called before the first frame update
        void Start()
        {
            //player = GameObject.Find("Player1");

            SetupPosition();            

            //Setting the random positions for the starting positions
            if(startingPos.Length > 0)
            {
                //This is all to make sure that the starting position has a connected target position
                int randomIndex = Random.Range(0, startingPos.Length);

                transform.position = startingPos[randomIndex];

                targetPosition = targetPos[randomIndex];
            }

            
            
        }

        // Update is called once per frame
        void Update()
        {
            Timer();           

        }

        //When this function is triggered, move the whale towards the target position
        void Movement()
        {
            //Tracking the position of the whale when it spawns to the target position
            currentPos = transform.position;
            Vector2 direction = (targetPosition - currentPos).normalized;
            //Vector2 direction = ((Vector2)player.transform.position - currentPos).normalized;
            transform.position += (Vector3)direction * whaleSpeed;
        }

        //Timer to control movement and despawning
        void Timer()
        {
            timeUntilAction -= Time.deltaTime;

            if (timeUntilAction <= 0)
            {
                timeUntilDespawn -= Time.deltaTime;
                Movement();

                if (timeUntilDespawn <= 0)
                {
                    isDestroyed = true;
                    timeUntilAction = 10.0f;
                    timeUntilDespawn = 10.0f;
                    Destroy(gameObject);                  
                    
                }
            }
        }

        //Setup the starting and target positions based on PlayerID
        private void SetupPosition()
        {
            //Set the different starting vector positions for the whale
            startingPos = new Vector2[]
            {
                     new Vector2(-129.44f, 35f),
                    new Vector2(38.4f, 134.2f),
                    new Vector2(135f, 134.2f),
                    new Vector2(135f, -61.6f)
            };

            targetPos = new Vector2[]
            {
                new Vector2(128.24f, 35f), new Vector2(38.4f, -126f),
                new Vector2(-135f, -134.2f), new Vector2(-130.5f, -61.6f)
            };

            //*Don't need positions based on playerID but just in case.*
            //if (playerID == 1)
            //{
            //    //Set the different starting vector positions for the whale
            //    startingPos = new Vector2[]
            //    {
            //         new Vector2(-129.44f, 35f),
            //        new Vector2(38.4f, 134.2f),
            //        new Vector2(135f, 134.2f),
            //        new Vector2(135f, -61.6f)
            //    };

            //    targetPos = new Vector2[]
            //    {
            //    new Vector2(128.24f, 35f), new Vector2(38.4f, -126f),
            //    new Vector2(-135f, -134.2f), new Vector2(-130.5f, -61.6f)
            //    };
            //}


            //if (playerID == 2)
            //{
            //    //Set the different starting vector positions for the whale
            //    startingPos = new Vector2[]
            //    {
            //         new Vector2(1764.15f, 35f),
            //        new Vector2(1954f, 134.2f),
            //        new Vector2(2054f, 134.2f),
            //        new Vector2(2054f, -61.6f)
            //    };

            //    targetPos = new Vector2[]
            //    {
            //    new Vector2(2054f, 35f), new Vector2(1954f, -126f),
            //    new Vector2(1782f, -134f), new Vector2(-130.5f, -61.6f)
            //    };
            //}
        }

        private void OnTriggerEnter(Collider other)
        {
            //If the whale hits any game object in its path
            bool hitsObject = other.gameObject;

            if (hitsObject)
            {
                Destroy(other.gameObject); //Destroy the other game objects
            }
        }

    }


}
