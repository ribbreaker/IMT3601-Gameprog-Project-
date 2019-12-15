using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathState : AbstractState
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public override void Execute(playerController player){
        Debug.Log("Player is in death state");
    }
    public override void Exit(){
        _animator.SetBool("dead", false);
    }

}
