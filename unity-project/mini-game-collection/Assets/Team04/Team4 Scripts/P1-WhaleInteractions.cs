using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team04
{
    public class WhaleInteractions : MonoBehaviour
    {
        public float whaleSpeed = 5.0f;
        public Vector2[] startingPos;
        private Vector2[] targetPos = new Vector2[] {new Vector2(128.24f, 35f), new Vector2(38.4f, -126f),
        new Vector2(-135f, -134.2f), new Vector2(-130.5f, -61.6f) };

        // Start is called before the first frame update
        void Start()
        {
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
            }

        }

        // Update is called once per frame
        void Update()
        {

        }
    }


}
