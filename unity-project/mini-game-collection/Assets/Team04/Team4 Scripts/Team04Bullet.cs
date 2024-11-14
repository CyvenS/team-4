using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MiniGameCollection.ArcadeInput;

public class Team04Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.GetComponent<Rigidbody2D>().velocity.x != 0 || gameObject.GetComponent<Rigidbody2D>().velocity.y != 0)
        {
            Destroy(gameObject, 2);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Bulletproof")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}