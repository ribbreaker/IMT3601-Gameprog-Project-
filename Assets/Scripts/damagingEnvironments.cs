using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagingEnvironments : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void onTriggerEnter( Collider other){
        //if what it's colliding with is dangerous
        if(other.gameObject.CompareTag("Danger")){
            //The entity takes damage
            GetComponent<entity>().takeDamage(1);
        }
    }
}
