using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuController : MonoBehaviour {

    private int currentLevel;
    public int index;
    [SerializeField] bool keyDown;
    [SerializeField] int maxIndex;
    //You don't want the player to suddenly select the inacessible levels from the second and third map
    private int minIndex;
    //the icon the player actually sees on the map
    GameObject playerIcon;
    GameObject transition;
    GameObject player;
    float[] lvlX;
    float[] lvlY;
    bool pressed = false;
    private Vector3 targetPos;
    [SerializeField] float moveSpeed;
    [SerializeField]Texture2D orbTexture;
    bool fortress;
    bool mountainTop;
    private string sceneName;
    

    private void Start() {
        minIndex = 0;
        transition = GameObject.Find("Transition");
        lvlX = new float[12];
        lvlY = new float[12];
        playerIcon = GameObject.Find("playerIcon");
        player = GameObject.Find("Player");
        targetPos = playerIcon.transform.position;
        sceneName = SceneManager.GetActiveScene().name;
        currentLevel = player.GetComponent<playerController>().mapPosition;

        lvlX[0] = -0.6f;    // Lvl 1
        lvlY[0] = -3.4f;

        lvlX[1] = -2.9f;    // Lvl 2
        lvlY[1] = -1.5f;

        lvlX[2] = -4.3f;    // Lvl 3
        lvlY[2] = 0.5f;

        lvlX[3] = -0.4f;    // Lvl 4
        lvlY[3] = 3.2f;

        lvlX[4] = 0.03f;    // fortress map
        lvlY[4] = 0.05f;

        lvlX[5] = 0;       //Back to the overworld map
        lvlY[5] = -4.19f;

        lvlX[6] = -3.85f;   //Lvl 5-1
        lvlY[6] = -2.61f;

        lvlX[7] = 2.77f;    //Lvl 5-2
        lvlY[7] = -1.09f;

        lvlX[8] = 0;       //Lvl 5-3 
        lvlY[8] = 1;

        lvlX[9] = -0.41f;   //To the mountain top
        lvlY[9] = 2.91f;

        lvlX[10] = -0.57f;  //Back to the fortress map
        lvlY[10] = -4.48f;

        lvlX[11] = 1.57f;   //final showdown
        lvlY[11] = 0.61f;
        //back to fortress select

        //Set the indexes depending on which map is in use
        if (sceneName.Equals("FortressMap")) {
            fortress = true;
            minIndex = 5;
            maxIndex = 9;
            // If the player has been on this map before then place him on the lvl he came from
            if (currentLevel > 5 && currentLevel <= 9) {
                index = currentLevel;
            } else { // If not then place him at the start
                index = 5;
            }
        } else if (sceneName.Equals("MountainMap")) {
            mountainTop = true;
            minIndex = 10;
            maxIndex = 11;
            // If the player has been on this map before then place him on the lvl he came from
            //// This one is simpler because it is only two places to go
            if (currentLevel == 11) {
                index = currentLevel;
            } else { // If not then place him at the start
                index = 10;
            }
        } else {
            minIndex = 0;
            maxIndex = 4;
            // If the player has been on this map before then place him on the lvl he came from
            if (currentLevel > 0 && currentLevel <= 4) {
                index = currentLevel;
            } else { // If not then place him at the start
                index = 0;
            }
        }

        //Debug.Log(player.GetComponent<playerController>().mapPosition);
        //index = player.GetComponent<playerController>().mapPosition;
    }

    // This does so that the user cannot spam the menu
    private void FixedUpdate() {
        //Move towards the new position
        if (playerIcon.transform.position != new Vector3(lvlX[index], lvlY[index])) {
            targetPos = new Vector3(lvlX[index], lvlY[index]);
            playerIcon.transform.position = Vector3.MoveTowards(playerIcon.transform.position, targetPos, moveSpeed * Time.deltaTime);
        }

        if (Input.GetAxisRaw("Horizontal") == -1 && playerIcon.transform.position == targetPos) {
            if (index > minIndex) {
                index--;
            }
        }

        //try going to the next level
        else if (Input.GetAxisRaw("Horizontal") == 1 && playerIcon.transform.position == targetPos) {

            //If the player has unlocked the level
            //for the list of levels beaten
            //if you come across a zero, break out. and make that your maxIndex
            if(player != null)
            {
                
                for (int i = minIndex; i <= player.GetComponent<playerController>().MAXLEVELS; i++)
                {

                    //if it's a zero, get out of there. and set maxindex to be i
                    if (player.GetComponent<playerController>().levelsBeaten[i] == false)
                    {
                        maxIndex = i;
                        break;
                    }
                }
            }

            if (index < maxIndex) {
                index++;
            }
        }

        if (Input.GetButtonDown("Submit") && pressed == false) {
    
            //the transition object handles reactivating the player 
            switch (index) {
                   //fade away, Scotty

                case 0:
                    transition.GetComponent<LevelTransition>().level = LevelTransition.Levels.Level1;
                    transition.GetComponent<LevelTransition>().fading = true;
                    break;
                case 1:
                    transition.GetComponent<LevelTransition>().level = LevelTransition.Levels.Level2;
                    transition.GetComponent<LevelTransition>().fading = true;
                    break;
                case 2:
                    transition.GetComponent<LevelTransition>().level = LevelTransition.Levels.Level3;
                    transition.GetComponent<LevelTransition>().fading = true;
                    break;
                case 3:
                    transition.GetComponent<LevelTransition>().level = LevelTransition.Levels.Level4;
                    transition.GetComponent<LevelTransition>().fading = true;
                    break;
                case 4:
                    transition.GetComponent<LevelTransition>().level = LevelTransition.Levels.FortressMap;
                    transition.GetComponent<LevelTransition>().fading = true;
                    break;
                case 5:
                    transition.GetComponent<LevelTransition>().level = LevelTransition.Levels.worldMap;
                    transition.GetComponent<LevelTransition>().fading = true;
                    break;
                case 6:
                    transition.GetComponent<LevelTransition>().level = LevelTransition.Levels.Level5FortressStage1;
                    transition.GetComponent<LevelTransition>().fading = true;
                    break;
                case 7:
                    transition.GetComponent<LevelTransition>().level = LevelTransition.Levels.Level5FortressStage2;
                    transition.GetComponent<LevelTransition>().fading = true;
                    break;
                case 8:
                    transition.GetComponent<LevelTransition>().level = LevelTransition.Levels.Level5FortressStage3;
                    transition.GetComponent<LevelTransition>().fading = true;
                    break;
                case 9:
                    transition.GetComponent<LevelTransition>().level = LevelTransition.Levels.MountainMap;
                    transition.GetComponent<LevelTransition>().fading = true;
                    break;
                case 10:
                    transition.GetComponent<LevelTransition>().level = LevelTransition.Levels.FortressMap;
                    transition.GetComponent<LevelTransition>().fading = true;
                    break;
                case 11:
                    transition.GetComponent<LevelTransition>().level = LevelTransition.Levels.FinalShowdown;
                    transition.GetComponent<LevelTransition>().fading = true;
                    break;

            }
            pressed = true;
            // Update players position on the map
            player.GetComponent<playerController>().mapPosition = index;
        }
    }
    private void OnGUI()
    {
        if(player != null)
        {
            player.GetComponent<playerStats>().GetTotalOrbs();
            GUI.DrawTexture(new Rect(50, 700, 50, 50), orbTexture);
            GUI.Label(new Rect(110, 713, 50, 50), player.GetComponent<playerStats>().GetTotalOrbs().ToString());
        }
 
    }

    //Player is on the map, add his orbs to the total
    private void AddOrbs(){
        //this one does everything.
        player.GetComponent<playerStats>().TallyOrbs();
    }
}
