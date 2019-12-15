using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] int thisIndex;
    GameObject player;
   
    bool pressed;          // To avoid functions being called several times (since it is in Update)
                           //// They are still called 2 times. Dunno why
    private void Start() {
        pressed = false;
        Time.timeScale = 0;     // To pause the game physics
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        player = GameObject.FindGameObjectWithTag("Player");
        if (menuButtonController.index == thisIndex) {
            GetComponent<RotateButton>().Rotate();
            animator.SetBool("selected", true);
            if (Input.GetAxisRaw("Submit") == 1) {
                animator.SetBool("pressed", true);

                if (thisIndex == 0 && pressed == false) {
                    // resume
                    Time.timeScale = 1;     // To un-pause the game physics
                    SceneManager.UnloadSceneAsync("PauseMenu");
                } else if (thisIndex == 1) {
                    // Go to level selection
                    GetComponentInParent<LevelTransition>().level = LevelTransition.Levels.worldMap;
                    GetComponentInParent<LevelTransition>().ScriptsON = false;
                    GetComponentInParent<LevelTransition>().fading = true;
                    //SceneTransition.Transition("worldMap", LoadSceneMode.Single);
                    Time.timeScale = 1;
                } else if (thisIndex == 2) {
                    // Go to main menu
                    GetComponentInParent<LevelTransition>().level = LevelTransition.Levels.MainMenu;
                    GetComponentInParent<LevelTransition>().ScriptsON = false;
                    GetComponentInParent<LevelTransition>().fading = true;
                    //SceneTransition.Transition("MainMenu", LoadSceneMode.Single);
                    Time.timeScale = 1;
                }

            } else if (animator.GetBool("pressed")) {
                animator.SetBool("pressed", false);
            }
        } else {
            GetComponent<RotateButton>().StopRotating();
            animator.SetBool("selected", false);
        }
    }
}
