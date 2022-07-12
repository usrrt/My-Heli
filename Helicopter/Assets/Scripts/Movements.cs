using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    public Transform Target;
    private HelicopterInput _input;
    private Rigidbody _rigidbody;
    public GameObject Rotor;
    public GameObject Rotor2;
    

    private float rotSpeed = 10f;
    private bool RotorOn = false;
    private float xSpeed;
    private float zSpeed;

    public float Speed = 1f;
    public float flySpeed = 15f;
    public bool canFly;
    public bool HeliRotate;
    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<HelicopterInput>();
        _rigidbody = GetComponent<Rigidbody>();
        canFly = false;
        HeliRotate = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(_input.isEngineOn)
        {
            RotorOn = !RotorOn;
        }

        if(RotorOn)
        {
            rotSpeed++;
            if(rotSpeed > 1000)
            {
                rotSpeed = 1500;
                canFly = true;
                HeliRotate = true;

            }
            Rotor.transform.Rotate(new Vector3(0f, rotSpeed * Time.deltaTime, 0f));
            Rotor2.transform.Rotate(new Vector3(0f, rotSpeed * Time.deltaTime, 0f));

            xSpeed = _input.X * Speed;
            zSpeed = _input.Z * Speed;
        }
        
        if(RotorOn == false)
        {
            --rotSpeed;
            if(rotSpeed < 2f)
            {
                rotSpeed = 0f;
                canFly = false;
                HeliRotate = false;
            }

            Rotor.transform.Rotate(new Vector3(0f, rotSpeed * Time.deltaTime, 0f));
            Rotor2.transform.Rotate(new Vector3(0f, rotSpeed * Time.deltaTime, 0f));
        }
        


        Vector3 locVel = transform.InverseTransformDirection(_rigidbody.velocity); // 월드 -> 로컬
        locVel.x = xSpeed;
        locVel.z = zSpeed;
        _rigidbody.velocity = transform.TransformDirection(locVel); // 로컬 -> 월드


        // _rigidbody.velocity = new Vector3(xSpeed, 0f, zSpeed);
        // _rigidbody.AddForce(xSpeed, 0f, zSpeed);

        if(canFly && _input.flyToTheSky)
        {
            _rigidbody.AddForce(0f, flySpeed, 0f);
            
        }

        // 헬기 제자리 선회
       if(HeliRotate)
       {
            if(_input.leftRotate)
            {
                _rigidbody.transform.Rotate(0f, -0.5f, 0f);
                
            }

            if(_input.rightRotate)
            {
                _rigidbody.transform.Rotate(0f, 0.5f, 0f);
            }

       }
       
    }
}
