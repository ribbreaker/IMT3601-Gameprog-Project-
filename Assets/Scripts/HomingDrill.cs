using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingDrill : MonoBehaviour
{

    private Transform target;
    private Transform startPos;
    private Rigidbody2D rb;
    private EnemyController controller;
    private Vector2 dir;
    private float rotateAmount;
    [SerializeField] private float speed = 5f, rotateSpeed = 200f;
    float falltime;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform;
        controller = GetComponent<EnemyController>();
        rb = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {
        target = transform.parent.GetComponent<drillFall>().getTarget();
        /*if (target != null) {
            dir = (Vector2)target.position - rb.position;           // Set the direction
            dir.Normalize();
        }
    
        rotateAmount = Vector3.Cross(dir, -transform.right).z;          // -transform.right for transform.left

        rb.angularVelocity = -rotateAmount * rotateSpeed;       // Minus to move towards the goal, plus to move away
        rb.velocity = transform.up * speed;*/
        if(target != null)
        {
            Debug.Log("Shite's fuck'd, mate");
            //fall down, but don't fall down forever
            falltime += Time.deltaTime;
            rb.velocity = transform.up * speed;
            if(falltime >= 5)
            {
                target = null;
                transform.position = startPos.position;
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Player" || collision.gameObject.layer == LayerMask.NameToLayer("Ground")) {  // Was originally if/elseif for player and ground
            controller.takeDamage(1);
        }
    }
}
