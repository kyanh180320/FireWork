using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLocation
{
    public int touchId;
    public GameObject scia;
    public ParticleSystem FireWork;

    public TouchLocation(int touchId, GameObject scia, ParticleSystem FireWork)
    {
        this.touchId = touchId;
        this.scia = scia;
        this.FireWork = FireWork;
    }
}
