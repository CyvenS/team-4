using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGameCollection.Games2024.Team04
{
    public class Team04WarningTrigger : MonoBehaviour
    {
        public Canvas ui;
        private GameObject rectangle;
        public GameObject warningIcon; //Get the warning icon 
        [SerializeField] private float triggerTimer = 20f;

        public Vector2 signalPos = new Vector2(100, 100); //The position of the background
        public Vector2 signalSize = new Vector2(200, 100); //The size of the background
        public Color warningColor = Color.red; //Color of the icon background


        // Start is called before the first frame update
        void Start()
        {            
            warningIcon = GetComponent<GameObject>();
            warningIcon.gameObject.SetActive(false);            
        }

        // Update is called once per frame
        void Update()
        {
            triggerTimer -= Time.deltaTime;
            if(triggerTimer <= 0)
            {
                warningIcon.gameObject.SetActive(true);
                triggerTimer = 20;
            }
        }

        //Draw the warning icon background on the UI canvas
        void DrawRectangle(Vector2 position, Vector2 size, Color color)
        {
            //Create new game object for the rectangle background
            rectangle = new GameObject("Background", typeof(Image));
            rectangle.transform.SetParent(ui.transform);

            //Set the rectangles transform properties
            RectTransform rect = rectangle.GetComponent<RectTransform>();
            rect.anchoredPosition = position; //Position relative to canvas
            rect.sizeDelta = size; //Width and height

            //Set the image color
            Image image = rectangle.GetComponent<Image>();
            image.color = color;

        }
    }
}

