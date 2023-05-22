using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TouchFireWorkLocation
{
    public int touchId;
    public GameObject scia;
    public TouchFireWorkLocation(int touchId, GameObject scia)
    {
        this.touchId = touchId;
        this.scia = scia;
    }
}
