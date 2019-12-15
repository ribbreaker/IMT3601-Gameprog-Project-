using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSimple : AbstractEnemyMovement
{
    public float speed;
    public float distance;
    [Tooltip("Note: Begins in the left direction")]
    public bool goingInX;
    [Tooltip("Note: Begins in the down direction")]
    public bool goingInY;
    Vector3 StartPosition;
    Vector3 EndPosition;

    void Awake() {
        //Where the movement loop starts
        StartPosition = transform.position;
        EndPosition = StartPosition;
    }

    // Update is called once per frame
    void FixedUpdate() {
        Move();
    }

    public override void Move(){
        //If it's going in x, add movementSpeed until it reaches startposition+distance
        if (goingInX)
            EndPosition.x = StartPosition.x + distance;
      
        //Same with y, you can do both at the same time to get a diagonal direction
        if (goingInY)
            EndPosition.y = StartPosition.y + distance;
     
        transform.position = Vector3.MoveTowards(transform.position, EndPosition, speed);
        //Reverse direction
        if (transform.position == EndPosition)
            distance *= -1;
    }
}

