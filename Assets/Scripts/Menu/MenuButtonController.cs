using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonController : MonoBehaviour {

    public int index;
    [SerializeField] bool keyDown;
    [SerializeField] int maxIndex;

    private void Start() {
        GameEventManager.GameStart += GameStart;
    }

    // Move up and down on the menu
    private void Update() {        
        if (Input.GetButtonDown("Vertical")) {
            if (!keyDown) {
                if (Input.GetAxisRaw("Vertical") < 0) {
                    if (index < maxIndex) {
                        index++;
                    } else {
                        index = 0;
                    }
                } else if (Input.GetAxisRaw("Vertical") > 0) {
                    if (index > 0) {
                        index--;
                    } else {
                        index = maxIndex;
                    }
                }
                keyDown = true;
            }
        } else {
            keyDown = false;
        }
    }

    public void ButtonPressed(int index) {
        if (index == 0) {
            GameEventManager.TriggerGameStart();
        } else if (index == 1) {
            Application.Quit();
        }
    }

    public void GameStart() {
        SceneTransition.Transition("playerInit", LoadSceneMode.Single);
    }
}
