using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team04
{
    public class WhaleInteractions : MonoBehaviour
    {
        public float whaleSpeed = 5f;

        public Vector2[] startingPos; // Variable to hold multiple starting positions of the whale
        [SerializeField] private Vector2[] targetPos; // Variable to set the target positions

        private Vector2 targetPosition;
        private Vector2 currentPos;

        [SerializeField] private float timeUntilAction = 10f; // Time until the whale moves
        [SerializeField] private float timeUntilDespawn = 10f; // Time until the whale despawns
        public bool isDestroyed = false; // Check if the whale has been destroyed in the scene

        [SerializeField] private GameObject[] warningIcons; // Icons for trigger warnings
        [SerializeField] private Vector2[] warningIconPositions; // Positions of the warning icons

        // Start is called before the first frame update
        void Start()
        {
            SetupPosition();

            if (startingPos.Length > 0)
            {
                // This ensures the starting position has a connected target position
                int randomIndex = Random.Range(0, startingPos.Length);

                transform.position = startingPos[randomIndex];
                targetPosition = targetPos[randomIndex];

                // Trigger the warning for the spawn position
                TriggerWarning(randomIndex);
            }
        }

        // Update is called once per frame
        void Update()
        {
            Timer();
        }

        // Movement logic for the whale
        void Movement()
        {
            currentPos = transform.position;
            Vector2 direction = (targetPosition - currentPos).normalized;
            transform.position += (Vector3)direction * whaleSpeed;
        }

        // Timer for controlling movement and despawning
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

                    // Randomize new position
                    int randomIndex = Random.Range(0, startingPos.Length);

                    transform.position = startingPos[randomIndex];
                    targetPosition = targetPos[randomIndex];

                    // Trigger the warning for the new spawn position
                    TriggerWarning(randomIndex);
                }
            }
        }

        // Setup the starting and target positions
        private void SetupPosition()
        {
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
        }

        // Triggers a warning icon at the specific position
        private void TriggerWarning(int index)
        {
            // Disable all warning icons
            foreach (var icon in warningIcons)
            {
                icon.SetActive(false);
            }

            // Activate the correct warning icon and position it
            if (index >= 0 && index < warningIcons.Length)
            {
                warningIcons[index].SetActive(true);
                warningIcons[index].transform.position = warningIconPositions[index];
            }
            else
            {
                Debug.LogWarning("Invalid index for warning icon.");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            // If the whale hits any game object in its path
            if (other != null)
            {
                Destroy(other.gameObject); // Destroy the other game objects
            }

        }
    }
}
