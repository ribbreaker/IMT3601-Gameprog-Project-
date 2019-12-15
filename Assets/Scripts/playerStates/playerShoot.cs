using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{
    public Transform projectileLocation;
    public GameObject projectile;
    [SerializeField]float fireRate = 0.5f;
    float nextFire = 0f;
    float projectileAliveTime;
    public int maxProjectiles;
    private float myTime;
    private playerStats stats;
    private bool fireButtonIsPressed;
    
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<playerStats>();
        projectileAliveTime = projectile.GetComponent<destroyMe>().aliveTime;
    }

    // Update is called once per frame
    void  Update()
    {
        //shoots if you got ammo and you're just pressing the button, not holding it down
        if (Input.GetAxisRaw("Fire1") > 0 && stats.GetOrbs() > 0 && fireButtonIsPressed == false) {
            fireRocket();
            fireButtonIsPressed = true;
        }
        if (Input.GetAxisRaw("Fire1") == 0) {
            fireButtonIsPressed = false;
        }
    }

    void fireRocket() {
        if(Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            //multiply the player's x local scale by -1
            Vector3 theScale = transform.localScale;
            //facing right
            if(theScale.x == 1) {
                Instantiate(projectile, projectileLocation.position, Quaternion.Euler (new Vector3(0,0,0)));
            }
            //facing left
            else if (theScale.x == -1) {
                Instantiate(projectile, projectileLocation.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
            stats.DecreaseOrbs();
        }
    }
}
