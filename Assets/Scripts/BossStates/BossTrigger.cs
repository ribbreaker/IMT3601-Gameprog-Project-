using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour {

    [SerializeField] Transform bossBoundaries;
    //[SerializeField] float extraSpace;        // To adjust the place where the boundaries spawn (x)
    [SerializeField] GameObject boss;
    [SerializeField] Transform bossArea;
    bool spawned = false;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Player" && !spawned) {
            spawned = true; // To stop double-spawning

            float left = bossArea.position.x - (bossArea.localScale.x / 2) - (bossBoundaries.transform.localScale.x / 2);// - extraSpace;
            float right = bossArea.position.x + (bossArea.localScale.x / 2) + (bossBoundaries.transform.localScale.x / 2);// + extraSpace;
            float top = bossArea.position.y + (bossArea.localScale.y / 2) + (bossBoundaries.transform.localScale.x / 2);// + extraSpace;
            float bottom = bossArea.position.y - (bossArea.localScale.y / 2) - (bossBoundaries.transform.localScale.x / 2) - 0.5f;// - extraSpace;

            Instantiate(bossBoundaries, new Vector3(left, bossArea.position.y, 0), Quaternion.identity);
            Instantiate(bossBoundaries, new Vector3(right, bossArea.position.y, 0), Quaternion.Euler(180, 0, 0));
            Instantiate(bossBoundaries, new Vector3(bossArea.position.x, top, 0), Quaternion.Euler(180, 0, 90));
            Instantiate(bossBoundaries, new Vector3(bossArea.position.x, bottom, 0), Quaternion.Euler(0, 0, 90));

            // Activate the boss' triggerzone/aggro-area
            if(boss != null)
            {
                if (!boss.active)
                    boss.active = true;
                boss.GetComponentInChildren<BoxCollider2D>().enabled = true;
                // Start the attack since the player no longer initiates the first OnTriggerEnter (because of above)
                boss.GetComponentInChildren<TriggerZone>().attack = true;
                boss.GetComponent<BossShowHP>().enabled = true;
            }
            // Destroy myself to not activate any more boss "events"
            Destroy(gameObject);
        }
    }
}
