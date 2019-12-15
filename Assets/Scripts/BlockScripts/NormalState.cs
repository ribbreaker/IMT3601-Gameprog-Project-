using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : AbstractState
{
    public override void Execute(playerController player) {
        Debug.Log("Block is in Normal State");
    }

    public override void Exit() {
        _animator.SetBool("IsBreaking", true);
    }

}
