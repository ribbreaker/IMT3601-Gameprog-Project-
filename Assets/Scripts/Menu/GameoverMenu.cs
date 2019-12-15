using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverMenu : MonoBehaviour {

    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] int thisIndex;
    GameObject player;

    bool pressed;

    // Start is called before the first frame update
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
                    SceneManager.UnloadSceneAsync("GameoverMenu");

                    player.GetComponent<playerController>().resurrected = true;
                    string name = player.GetComponent<playerController>().sceneName;
                    SceneManager.LoadScene(name, LoadSceneMode.Single);
                    
                } else if (thisIndex == 1) {
                    // Go to level selection
                    SceneTransition.Transition("worldMap", LoadSceneMode.Single);
                    Time.timeScale = 1;

                } else if (thisIndex == 2) {
                    Application.Quit();
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
