using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team04
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject enemySpawnerPrefab;


        [SerializeField]
        private float enemySpawnerInterval = 2f;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(spawnEnemy(enemySpawnerInterval, enemySpawnerPrefab));
           
        }

        // Update is called once per frame
       private IEnumerator spawnEnemy( float interval, GameObject enemy)
        {
            yield return new WaitForSeconds(interval);
            GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(3f, 1), Random.Range(-3f, 1), 0), Quaternion.identity);
            StartCoroutine(spawnEnemy(interval, enemy));
        }
        

        
     }
}
