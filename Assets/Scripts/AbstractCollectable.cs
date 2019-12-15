using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCollectable : MonoBehaviour
{
    public virtual void Collected(playerStats Stats){
        
    }
    public virtual void SendMessage(Message message){

    }
}
