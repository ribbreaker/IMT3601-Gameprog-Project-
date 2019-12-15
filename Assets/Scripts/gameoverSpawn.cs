using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class gameoverSpawn : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //get the scene for use in gameovers
        player = GameObject.FindGameObjectWithTag("Player");
        //get the scene name (for use in gameovers)
        player.GetComponent<playerController>().respawnScene = SceneManager.GetActiveScene();
        player.GetComponent<playerController>().sceneName = player.GetComponent<playerController>().respawnScene.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
