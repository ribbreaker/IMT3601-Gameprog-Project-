using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateButton : MonoBehaviour
{
    //target rotation
    Quaternion target;
    [SerializeField] float rotateSpeed;
    [SerializeField] float rotateAngle;

    public void Rotate() {
        if (transform.rotation != target) {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target, rotateSpeed);
        }
        else {
            //Rotating to the left
            if (target == Quaternion.Euler(0, 0, -rotateAngle)) {
                target = Quaternion.Euler(0, 0, rotateAngle);
            }
            else {
                //Rotating to the right
                if (target == Quaternion.Euler(0, 0, rotateAngle)) {
                    target = Quaternion.Euler(0, 0, -rotateAngle);
                }
            }
        }
    }

    public void StopRotating() {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        if (rotateAngle == 0)
            rotateAngle = 25;
        if (rotateSpeed == 0)
            rotateSpeed = 25;
        target = Quaternion.Euler(0, 0, rotateAngle);
    }
}
