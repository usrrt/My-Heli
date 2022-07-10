using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterInput : MonoBehaviour
{
    // 좌표로 움직임 표현
    public float X {get; private set;}
    public float Z {get; private set;}
    public bool isEngineOn;
    public bool flyToTheSky;

    public bool leftRotate {get; private set;}
    public bool rightRotate {get; private set;}


    // Update is called once per frame
    void Update()
    {
        X = Z = 0f;

        X = Input.GetAxis("Horizontal");
        Z = Input.GetAxis("Vertical");

        isEngineOn = Input.GetKeyDown(KeyCode.Z);
        flyToTheSky = Input.GetKey(KeyCode.Space);

        leftRotate = Input.GetKey(KeyCode.Q);
        rightRotate = Input.GetKey(KeyCode.E);
    }
}
