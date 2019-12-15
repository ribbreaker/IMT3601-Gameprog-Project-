using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimatorState{
    Started,
    Finished
}


public class AnimatorMessage : Message
{
    public Animator Animator {get; private set;}
    public AnimatorState State{get; private set;}
    public string StateName{get; private set;}

    public AnimatorMessage(Animator animator, string stateName, AnimatorState state){
        Animator = animator;
        State = state;
        StateName = stateName;
    }
}
public class AnimationMessage : Message{
    public Animator Animator {get; private set;}
    public string EventName{get; private set;}
    public AnimationMessage(Animator animator, string eventName){
        Animator = animator;
        EventName = eventName;
    }
}
