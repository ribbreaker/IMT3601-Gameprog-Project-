using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    bool warp;
    [SerializeField]GameObject warpPoint;
    GameObject warpee;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        warp = true;
        warpee = collision.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (warp){
            warpee.transform.position = new Vector3(warpPoint.transform.position.x, warpPoint.transform.position.y);
            warp = false;
        }
    }
}
