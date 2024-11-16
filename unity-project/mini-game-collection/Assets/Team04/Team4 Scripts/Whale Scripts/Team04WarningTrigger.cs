using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGameCollection.Games2024.Team04
{
    public class Team04WarningTrigger : MonoBehaviour
    {
        [SerializeField] private float triggerTimer = 20f; //Time until the game object activates

        //Reference the warning trigger game objects 
        [SerializeField] private GameObject[] warningTriggers;

        public Color warningColor = Color.red; //Color of the icon background

        Team04WhaleSpawner whaleSpawn; 
        WhaleInteractions whale;

        // Start is called before the first frame update
        void Start()
        {
            whale = FindObjectOfType<WhaleInteractions>();
 
            //Set the triggers off as the scene starts
            foreach (var trigger in warningTriggers)
            {
                if(trigger != null)
                {
                    trigger.SetActive(false);
                }
                else
                {
                    Debug.LogWarning("A trigger reference is missing!");
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            IconTriggers();
        }

        void IconTriggers()
        {
            //Deactivate the triggers initially
            foreach (var trigger in warningTriggers)
            {
                if(trigger != null)
                {
                    trigger.SetActive(false);
                }
            }

            int index = whale.startingPos.Length;
            switch (index)
            {
                case 0:
                    warningTriggers[0].SetActive(true); break;
                case 1:
                    warningTriggers[1].SetActive(true); break;
                case 2:
                    warningTriggers[2].SetActive(true); break;
                case 3:
                    warningTriggers[3].SetActive(true); break;
            }
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

