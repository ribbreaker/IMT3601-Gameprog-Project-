using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnExit : StateMachineBehaviour
{
    [SerializeField]
    private string _stateID;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //Send message that it's entered the state
        var message = new AnimatorMessage(animator, _stateID, AnimatorState.Started);
        if (animator.gameObject.GetComponent<BreakableBlock>() != null) {
            animator.gameObject.GetComponent<BreakableBlock>().CurrentState.SendMessage(message);
        }
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (stateInfo.normalizedTime > 1) {
            animator.gameObject.SetActive(false);
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //it's destroyed upon the end of the animation, so sending a message here would do nothing.

    }

}
