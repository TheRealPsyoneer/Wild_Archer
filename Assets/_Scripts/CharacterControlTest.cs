using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlTest : MonoBehaviour
{
    CharacterController charControl;
    [SerializeField] float speed;

    private void Awake()
    {
        charControl = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            charControl.Move(Vector3.left * speed);
        }
    }
}
