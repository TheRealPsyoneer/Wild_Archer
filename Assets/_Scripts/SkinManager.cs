using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public static SkinManager instance;

    public Transform[] skins;

    private void Awake()
    {
        instance = this;
        skins = GetComponentsInChildren<Transform>();
    }
}
