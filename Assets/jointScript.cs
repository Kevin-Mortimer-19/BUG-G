using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jointScript : MonoBehaviour
{
    private HingeJoint2D hinge;

    public float angle;

    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //angle = hinge.jointAngle;
        //angle = hinge.motor.speed;
        angle = hinge.motor.motorSpeed;
        //hinge.motor.maxMotorTorque = 0;
    }
}
