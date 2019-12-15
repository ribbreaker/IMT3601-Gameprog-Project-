using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserMovetowards : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveToHere(Vector3 target, float spd) {
        transform.position = Vector3.MoveTowards(transform.position,target,Time.deltaTime * spd);
    }
}
