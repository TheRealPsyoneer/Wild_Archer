using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StepZone : MonoBehaviour
{
    const string PLAYER = "Player";

    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER))
        {
            OnSteppedOn();
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(PLAYER))
        {
            OnSteppedOff();
        }
    }

    public abstract void OnSteppedOn();
    public abstract void OnSteppedOff();
}
