using UnityEngine;

public abstract class AbstractState : MonoBehaviour
{
    [SerializeField]
    protected Animator _animator;

    public virtual void Enter(){
        
    }

    public virtual void Exit(){
        
    }
    public virtual void SendMessage(Message message){

    }

    public abstract void Execute(playerController player);

}
