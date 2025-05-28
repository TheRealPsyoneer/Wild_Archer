using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StepZone : MonoBehaviour
{
    const string PLAYER = "Player";

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER))
        {
            OnSteppedOn();
        }
    }


    public abstract void OnSteppedOn();
}
