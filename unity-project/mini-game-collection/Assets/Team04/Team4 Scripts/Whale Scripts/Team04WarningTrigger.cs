using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGameCollection.Games2024.Team04
{
    public class Team04WarningTrigger : MonoBehaviour
    {
        [SerializeField]private GameObject background; //Get the background game object
        [SerializeField] private GameObject warningIcon; //Get the warning icon 
        [SerializeField] private float triggerTimer = 20f; //Time until the game object activates

        public Vector2 iconPos = new Vector2(100, 100); //The position of the icon
        public Vector2 iconSize = new Vector2(100, 50); //The size of the icon
        public Vector2 backPos; //Position of the backkground
        public Vector2 backSize = new Vector2(200, 100); //Size of the background

        public Color warningColor = Color.red; //Color of the icon background

        Team04WhaleSpawner whaleSpawn; 
        WhaleInteractions whale;

        // Start is called before the first frame update
        void Start()
        {            
            warningIcon = GetComponent<GameObject>();
            warningIcon.gameObject.SetActive(false);
            background = GetComponent<GameObject>();    
            backPos = iconPos; //Make sure that the back object follows the icon position

            whaleSpawn = FindAnyObjectByType<Team04WhaleSpawner>();
            whale = FindAnyObjectByType<WhaleInteractions>();
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

        //
        void IconProperties()
        {

        }

        //Draw the warning icon background on the UI canvas
        void DrawRectangle(Vector2 position, Vector2 size, Color color)
        {
            ////Create new game object for the rectangle background
            //rectangle = new GameObject("Background", typeof(Image));
            //rectangle.transform.SetParent(ui.transform);

            ////Set the rectangles transform properties
            //RectTransform rect = rectangle.GetComponent<RectTransform>();
            //rect.anchoredPosition = position; //Position relative to canvas
            //rect.sizeDelta = size; //Width and height

            ////Set the image color
            //Image image = rectangle.GetComponent<Image>();
            //image.color = color;

        }
    }
}

