using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDeath : MonoBehaviour {
    GameObject player;
    GameObject transition;

    int bossHealth;
    public enum Levels {Level1, Level2, Level3,  Level4, Level5FortressStage1, Level5FortressStage2, Level5FortressStage3, FinalShowdown};

    [SerializeField]Levels level;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transition = GameObject.FindGameObjectWithTag("Transition");
    }

    private void Update() {
        bossHealth = GetComponent<EnemyController>().HP;

        if (bossHealth <= 0) {
            //fades to the next scene.
            //TODO: destroy the boss in a fancy way, freeze the player while this is happening
            //fade away, Scotty
            transition.GetComponent<LevelTransition>().fading = true;
            player.GetComponent<playerController>().levelsBeaten[(int)level] = true;
        }
    }
}
