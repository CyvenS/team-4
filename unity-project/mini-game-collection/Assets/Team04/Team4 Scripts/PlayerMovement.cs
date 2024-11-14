using MiniGameCollection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team04
{
    public class NewBehaviourScript : MonoBehaviour
    {
        public float playerSpeed = 5f;
        private Rigidbody rb;
        public int playerID = 0;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            float x = ArcadeInput.Players[playerID].AxisX;
            float y = ArcadeInput.Players[playerID].AxisY;

            Vector3 direction = new Vector3(x, y, 0) * playerSpeed * Time.deltaTime;

            transform.Translate(direction);
        }
    }
}

