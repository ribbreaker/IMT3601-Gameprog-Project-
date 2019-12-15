using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventExamples : MonoBehaviour
{

    //Unity Events can be serialized in the scene file (serialise = convert data to another representation e.g. json text)
    [System.Serializable]
    public class BoolUnityEvent : UnityEvent<bool>{

    }

    //Unity Event that will be saved in the scene file
    [SerializeField]
    private BoolUnityEvent _onCompleteEvent;

    //System events will not be handled by unity. But this is an alternative method for callbacks in unity
    private System.Action<bool> _onCompleteAction;

    // Awake is called when the script if first initialized 
    private void Awake()
    {
        _onCompleteEvent.AddListener(OnCompleteCallback);
    }

    // Start is called before the first frame update
    void Start()
    {
        bool hasMetCriteria = true;
        Debug.Log("Firing event...");
        _onCompleteEvent.Invoke(hasMetCriteria);
    }

    private void OnCompleteCallback(bool success){
        Debug.Log("Event was completed");
    }
}
