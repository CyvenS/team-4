using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team04
{
    public class WhaleInteractions : MonoBehaviour
    {
        public float whaleSpeed = 1.0f;
        public Vector2[] startingPos;
        private Vector2[] targetPos = new Vector2[] {new Vector2(128.24f, 35f), new Vector2(38.4f, -126f),
        new Vector2(-135f, -134.2f), new Vector2(-130.5f, -61.6f) };

        private Rigidbody rb;

        private Vector2 targetPosition;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>(); //Get the rigidbody component for the game object

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
            Vector2 currentPos = transform.position;
            Vector2 direction = (targetPosition - currentPos).normalized;
            transform.position += (Vector3)direction * whaleSpeed;
        }

        void Movement()
        {
            // Use the ArcadeInput system for movement
            float xInput = ArcadeInput.Player1.AxisX; // Get horizontal input for Player 1
            float yInput = ArcadeInput.Player1.AxisY; // Get vertical input for Player 1

            // Calculate the direction based on input
            Vector2 direction = new Vector2(xInput, yInput).normalized;

            // Move the whale in the specified direction
            transform.position += (Vector3)direction * whaleSpeed * Time.deltaTime;
        }

    }


}
