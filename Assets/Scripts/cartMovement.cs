using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cartMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    public bool movingRight;
    // Start is called before the first frame update
    void Start()
    {
        if (speed == 0) {
            speed = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if a ground is touching the "nose", turn around
        if (movingRight == true) {
            transform.Translate(-(Vector2.right * -speed * Time.deltaTime));
        }
        else {
            transform.Translate(-(Vector2.right * speed * Time.deltaTime));
        }
    }
}
