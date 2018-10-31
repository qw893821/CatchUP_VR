using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter {
    float startT=0f;
    public float endT;
    bool triggered=false;

    public void Holder()
    {
        //when trigger is hold down and not reach the required hold time, counting
        if (triggered&&startT<endT)
        {
            startT+=Time.deltaTime;
        }
        //when trigger is hold down but reached the required hold time, reset time and set trigger to false
        else if(startT>=endT)
        {
            startT = 0f;
            triggered = false;
            //do something 
        }
        //else
        else {
            startT = 0f;
            triggered = false;
        }
    }

    //trigger will call this even, but the counting do not requrie the trigger being kept holding
    public void Waiter()
    {
        //keep count when this function is called;
        if (startT<endT)
        {
            startT += Time.deltaTime;
        }
        else 
        {
            startT = 0f;
            //do something
        }
    }
}
