using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTriton : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    GameObject player;
    bool spawn;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            spawn = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            Instantiate(enemy, player.transform);
        }
    }
}
