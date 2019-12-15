using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectleController : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z > 0)
        rb.AddForce(new Vector2(-1, 0) * speed,ForceMode2D.Impulse);
        else
            rb.AddForce(new Vector2(1, 0) * speed, ForceMode2D.Impulse);
    }
}
