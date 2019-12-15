using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] int thisIndex;
    bool started;          // To avoid gameStart being called several times (since it is in Update)
    bool pressed;

    //// GameStart is still called 2 times. Dunno why
    private void Start() {
        started = false;
        GameEventManager.GameStart += GameStart;
    }

    // Update is called once per frame
    void Update() {
        if (menuButtonController.index == thisIndex) {
            animator.SetBool("selected", true);
            //make button rotate back and forth 
            GetComponent<RotateButton>().Rotate();
            if (Input.GetAxis("Submit") == 1 && !pressed) {
                pressed = true;
                animator.SetBool("pressed", true);

                if (thisIndex == 0 && started == false) {
                    started = true;
                    GameEventManager.TriggerGameStart();
                } else if (thisIndex == 1) {
                    Application.Quit();
                }

            } else if (animator.GetBool ("pressed")) {
                animator.SetBool("pressed", false);
            }
        } else {
            //reset the rotation and deselect the button
            GetComponent<RotateButton>().StopRotating();
            animator.SetBool("selected", false);
        }
    }

    public void GameStart() {
        SceneTransition.Transition("playerInit", LoadSceneMode.Single);
    }
}
