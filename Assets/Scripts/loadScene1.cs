using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loadScene1 : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Single);
        OnLoad();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnLoad()
    {
        //Player stuff
        Debug.Log("Game start!");
 
        if (player != null)
        {
            //The player can play the damn game   
            player.GetComponent<Rigidbody2D>().isKinematic = false;
            player.GetComponent<BoxCollider2D>().enabled = true;
            player.GetComponent<playerController>().enabled = true;
            player.GetComponent<playerStats>().enabled = true;
            player.GetComponent<PlayerMovement>().enabled = true;
            player.GetComponent<playerShoot>().enabled = true;
            player.GetComponent<canRideStuff>().enabled = true;
            player.GetComponent<canBreakStuff>().enabled = true;
                

        }
       

    }

}
