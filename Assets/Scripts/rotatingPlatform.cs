using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingPlatform : MonoBehaviour
{

    [SerializeField] float Degree;
    Vector2 pivot;
    void Start() {
        pivot = gameObject.transform.parent.position;
    }
    // Update is called once per frame
    void Update(){
        pivot = gameObject.transform.parent.position;
        transform.position = RotateAroundPivot(transform.position, pivot,Degree);
    }
    Vector2 RotateAroundPivot(Vector2 position, Vector2 pivot, float degree) {
        position -= pivot;
        float a = degree * Mathf.Deg2Rad;
        float s = Mathf.Sin(a);
        float c = Mathf.Cos(a);
        return pivot + new Vector2(
            position.x * c - position.y * s,
            position.y * c + position.x * s);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        collision.collider.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision) {
        collision.collider.transform.SetParent(null);
    }
}
