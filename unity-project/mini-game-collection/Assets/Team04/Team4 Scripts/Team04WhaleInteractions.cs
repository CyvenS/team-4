using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team04
{
    public class WhaleInteractions : MonoBehaviour
    {
        public float whaleSpeed = 1.0f;
        public Vector2[] startingPos; //Variable to hold multiple starting positions of the whale
        private Vector2[] targetPos = new Vector2[] {new Vector2(128.24f, 35f), new Vector2(38.4f, -126f),
        new Vector2(-135f, -134.2f), new Vector2(-130.5f, -61.6f) }; //Variable to set the target positions

        [SerializeField]
        private GameObject whale;

        private Vector2 targetPosition;
        private Vector2 currentPos;

        [SerializeField]
        private float timeUntilAction = 10f; //The time it will take until the whale moves

        [SerializeField]
        private float timeUntilDespawn = 10f; //The time it will take until the whale moves again

        // Start is called before the first frame update
        void Start()
        {
            

            //Set the different starting vector positions for the whale
            startingPos = new Vector2[]
            {
            new Vector2(-129.44f, 35f),
            new Vector2(38.4f, 134.2f),
            new Vector2(135f, 134.2f),
            new Vector2(135f, -61.6f)
            };

            if(startingPos.Length > 0)
            {
                int randomIndex = Random.Range(0, startingPos.Length);

                transform.position = startingPos[randomIndex];

                targetPosition = targetPos[randomIndex];
            }

            
            
        }

        // Update is called once per frame
        void Update()
        {
            timeUntilAction -= Time.deltaTime;

            if (timeUntilAction <= 0)
            {
                timeUntilDespawn -= Time.deltaTime;
                Movement();

                if (timeUntilDespawn<= 0)
                {
                    Destroy(gameObject);
                    timeUntilAction = 10.0f;
                    timeUntilDespawn = 10.0f;
                }
            }  
            

        }

        void Movement()
        {
            currentPos = transform.position;
            Vector2 direction = (targetPosition - currentPos).normalized;
            transform.position += (Vector3)direction * whaleSpeed;
        }

        public void SpawnWhale()
        {

        }

    }


}
