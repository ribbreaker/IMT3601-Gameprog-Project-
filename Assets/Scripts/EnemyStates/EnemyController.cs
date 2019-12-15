using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : entity
{
    Renderer rend;
    Color colorStart;
    Color colorEnd;
    [SerializeField] int damage;
    bool isDamaged;
    float flashTimer;
    // Start is called before the first frame update
    void Start(){
        //store the original color so we can make him flash when he takes damage
        rend = GetComponent<Renderer>();
        colorStart = rend.material.color;
        colorEnd = new Color(99, 99, 99, 1);
        if (HP == 0)
            HP = 3;
    }
    //Collision against something that can deal damage to it
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Ball")) {
            takeDamage(1);
            isDamaged = true;
        }
    }

    public int DealDamage() {
        return damage;
    }

    void FixedUpdate() {

        if (isDamaged) {
            flashTimer += Time.deltaTime;
            //rapidly switch between "colors" when damaged
            if (rend.material.color == colorStart) {
                rend.material.color = colorEnd;
            }
            else if (rend.material.color == colorEnd) {
                rend.material.color = colorStart;
            }
        }
        else {
            rend.material.color = colorStart;
        }

        //resets the invincibility time
        if (flashTimer >= 0.1) {
            isDamaged = false;
            flashTimer = 0;
        }

    }
}
