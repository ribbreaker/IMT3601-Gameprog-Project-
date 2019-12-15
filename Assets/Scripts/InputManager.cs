using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public enum Actions{
        IDLE,
        WALKING_LEFT,
        WALKING_RIGHT,
        JUMPING,
        KICKING
    }

    KeyCode[] bindings;

   /*  public KeyCode getKeyCodeFromPlayerPrefs(enum Actions, KeyCode, KeyCode){

    }*/

    /* public bool getActionPressed(Actions action){
        bindings = new KeyCode[System.Enum.GetValues(typeof(Actions)).Length];

        bindings[(int)Actions.WALKING_LEFT] = getKeyCodeFromPlayerPrefs(Actions.WALKING_LEFT, KeyCode, KeyCode.A);
        bindings[(int)Actions.WALKING_RIGHT] = getKeyCodeFromPlayerPrefs(Actions.WALKING_RIGHT, KeyCode, KeyCode.D);
        bindings[(int)Actions.JUMPING] = getKeyCodeFromPlayerPrefs(Actions.JUMPING, KeyCode, KeyCode.Space);
        bindings[(int)Actions.KICKING] = getKeyCodeFromPlayerPrefs(Actions.KICKING, KeyCode, KeyCode.P);
        return bindings;
    }*/
  

}
