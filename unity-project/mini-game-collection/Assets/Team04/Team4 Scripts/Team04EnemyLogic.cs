using MiniGameCollection.Games2024.Team04;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team04
{
    public class Team04EnemyLogic : MonoBehaviour
    {
        public GameObject player1;
        public GameObject player2;

        [SerializeField] private float enemySpeed = 1f;
        [SerializeField] private int PlayerID;

        // Start is called before the first frame update
        void Start()
        {
            int randomNum = Random.Range(1, 3);
            PlayerID = randomNum;
        }

        // Update is called once per frame
        void Update()
        {

            TrackPlayers();
        }

        void TrackPlayers()
        {
            if (PlayerID == 1)
            {
                Vector3 direction1 = (player1.transform.position - transform.position).normalized;
                transform.position += direction1 * enemySpeed * Time.deltaTime;
            }

            if (PlayerID == 2)
            {
                Vector3 direction2 = (player2.transform.position - transform.position).normalized;
                transform.position += direction2 * enemySpeed * Time.deltaTime;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(gameObject);
        }
    }
}

