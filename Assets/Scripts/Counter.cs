using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter {
    float startT=0f;
    public float endT;
    bool triggered=false;
    public delegate void HolderMethod();
    public delegate void WaiterMethod();

    public IEnumerator Holder(HolderMethod holderMethod)
    {
        //when trigger is hold down and not reach the required hold time, counting
        if (triggered&&startT<endT)
        {
            startT+=Time.deltaTime;
            yield return new WaitForEndOfFrame();
            Holder(holderMethod);
        }
        //when trigger is hold down but reached the required hold time, reset time and set trigger to false
        else if(triggered && startT >=endT)
        {
            startT = 0f;
            triggered = false;
            //do something
            holderMethod();
            yield return null;
        }
        //else
        else {
            startT = 0f;
            triggered = false;
            yield return null;
        }
    }

    //trigger will call this even, but the counting do not requrie the trigger being kept holding
    public IEnumerator Waiter(WaiterMethod waiterMethod)
    {
        //keep count when this function is called;
        if (startT<endT)
        {
            startT += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            Waiter(waiterMethod);
        }
        else 
        {
            startT = 0f;
            //do something
            waiterMethod();
            yield return null;
        }
    }

    
}
