using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour {

    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] int thisIndex;
    bool pressed;          // To avoid functions being called several times (since it is in Update)
                           //// They are still called 2 times. Dunno why
    
    private void Start() {
        pressed = false;
    }

    // Update is called once per frame
    void Update() {
        if (menuButtonController.index == thisIndex) {
            animator.SetBool("selected", true);
            if (Input.GetAxis("Submit") == 1) {
                animator.SetBool("pressed", true);

                if (thisIndex == 0 && pressed == false) {
                    SceneTransition.Transition("Level1", LoadSceneMode.Single);
                } else if (thisIndex == 1) {
                    SceneTransition.Transition("Level2", LoadSceneMode.Single);
                } else if (thisIndex == 2) {
                    SceneTransition.Transition("Level3", LoadSceneMode.Single);
                } else if (thisIndex == 3) {
                    SceneTransition.Transition("Level4", LoadSceneMode.Single);
                }

            } else if (animator.GetBool("pressed")) {
                animator.SetBool("pressed", false);
            }
        } else {
            animator.SetBool("selected", false);
        }
    }
}
