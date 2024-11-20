using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team04EnemyLogic : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    [SerializeField] private float enemySpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        TrackPlayers();        
    }

    void TrackPlayers()
    {
        
        Vector3 direction = (player1.transform.position - transform.position).normalized;
        transform.position += direction * enemySpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
