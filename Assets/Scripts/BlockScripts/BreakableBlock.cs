using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BreakableBlock : MonoBehaviour
{
    [SerializeField]
    private AbstractState _currentState;
    [SerializeField]
    private List<AbstractState> _availableStates;

    public void SendAnimationMessage(string eventID){
        var animator = GetComponent<Animator>();
        var animationMessage = new AnimationMessage(animator, eventID);
        _currentState.SendMessage(animationMessage);
    }
    public AbstractState CurrentState { get { return _currentState; } }

   

    private void CacheAllStates() {
        _availableStates = GetComponentsInChildren<AbstractState>(true).ToList();
    }
    #region API
    public TState FindAvailableState<TState>()
        where TState : AbstractState {
        foreach (var availableState in _availableStates) {
            if (availableState.GetType() == typeof(TState)) {
                return availableState as TState;
            }
        }
        return null;
    }

    public void ChangeState(AbstractState newState) {
        if (_currentState == newState)
            return;
        //enter the new state
        _currentState.Exit();
        _currentState = newState;
        newState.Enter();
    }
    #endregion API
    void Awake() {
        CacheAllStates();
        _currentState = GetComponentInChildren<normalState>();
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<canBreakStuff>() != null)
            if (other.GetComponent<canBreakStuff>().canBreak) {
                var breakingState = _availableStates.Find(x => x.GetType() == typeof(BreakingState));

                ChangeState(breakingState);
            }
    }
}
