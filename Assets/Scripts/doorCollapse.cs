using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorCollapse : MonoBehaviour
{
    [SerializeField] private bool gold;
    [SerializeField] private int specialCriteria;
    private playerStats stats;
    // Update is called once per frame
    void Start() {
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<playerStats>();
    }
    public void explodeMe() {
            if (gold) {
                if (stats.GetTotalOrbs() >= specialCriteria) {
                    gameObject.SetActive(false);
                    Debug.Log("Gold wall has exploded");
                }
            }
            else {
                gameObject.SetActive(false);
                Debug.Log("Wall has exploded");
            }
    }

    //if pressed, iterate through each child, and do explodeme if they have explodeme
}
