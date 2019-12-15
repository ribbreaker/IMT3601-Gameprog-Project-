using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPositioner : MonoBehaviour
{
    /*For setting the position of child objects in certain groups,
     due to Unity's view often messing up the axis of most objects.*/
    public virtual void SetPosition(){
    }
}
