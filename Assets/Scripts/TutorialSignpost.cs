using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSignpost : MonoBehaviour {

    private MeshRenderer text;
    private SpriteRenderer background;

    // Start is called before the first frame update
    void Start() {
        text = GetComponentInChildren<MeshRenderer>();
        background = text.GetComponentInChildren<SpriteRenderer>();
        text.enabled = false;
        background.enabled = false;
        // This does so that the text goes in front the background sprite
        text.sortingLayerName = "Background";
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Player") {
            text.enabled = true;
            background.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.name == "Player") {
            text.enabled = false;
            background.enabled = false;
        }
    }
}
