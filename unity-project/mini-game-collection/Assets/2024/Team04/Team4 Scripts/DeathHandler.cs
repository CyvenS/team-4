using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathHandler : MonoBehaviour
{
    public GameObject playerWin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerWin.activeSelf)
        {
            gameObject.transform.position = new Vector3(0, 0, -6);
            gameObject.transform.localScale = new Vector3(2, 2, gameObject.transform.localScale.z);
            

            if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.Period) && Input.GetKey(KeyCode.Comma))
            {
                string currentSceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(currentSceneName);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (playerWin.activeSelf == false && collision.gameObject.name != "2024-team04-wall1" && collision.gameObject.name != "2024-team04-wall2" && collision.gameObject.name != "2024-team04-wall3" && collision.gameObject.name != "2024-team04-wall4" && collision.gameObject.name != "2024-team04-bullet(Clone)")
        {
            playerWin.SetActive(true);
            Debug.Log(gameObject.name);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerWin.activeSelf == false && collision.gameObject.name == "2024-team04-whale-1" || collision.gameObject.name == "2024-team04-whale-2" || collision.gameObject.name == "2024-team04-whale-3" || collision.gameObject.name == "2024-team04-whale-4")
        {
            playerWin.SetActive(true);
            Debug.Log(gameObject.name);
            Destroy(gameObject);
        }
    }
}
