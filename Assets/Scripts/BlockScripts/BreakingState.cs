using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingState : AbstractState
{
    public override void Execute(playerController player) {
        
    }
    public override void Exit() {
        Debug.Log("Block broke!");
        _animator.SetBool("IsBreaking", false);
    }
    
    public override void SendMessage(Message message)
    {
        var animatorMessage = message as AnimatorMessage;

        if(animatorMessage != null)
        {
            Debug.Log(animatorMessage.StateName + " is now " + animatorMessage.State, this);
        }
        else if(message is AnimationMessage)
        {
            var animationMessage = (AnimationMessage)message;
        }
        else
        {
            // DO NOTHING
        }
    }
}
