using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour { 

//    //These are the translation and rotation variables.
    Vector2 input_movement;
    float input_torqueR;
    float input_torqueL;
    public Rigidbody cubeRigidbody;
        
        [Range(1f, 10f)]
    public float moveSpeed;

    [Range(1f, 10f)]
    public float torque;

    //These are the color change variables.
    public GameObject Fx;
    public Color color;
    public Color colorfx;

    //These are the OnKick function variables.
    RaycastHit hit;
    public float rayMaxDistance;
    public float hitForce;
    public LayerMask rayLayerMask;

    private float currentHitDistance;
    private Vector3 currentHitDirection;
    private bool isKickable;
    private Rigidbody rbBall;

    public GameObject camara;

    void Start()
    {
        transform.gameObject.tag = "Player";
        cubeRigidbody = gameObject.GetComponent<Rigidbody>();
    }
    //Now I can look and add velocity to the player through the sticks vectors.
    //In both cases vector2 x and y values, are the vector3 x and z values (gravity is y in the vector3).
    private void Update()
    {
        
    }
    /*
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(input_movement.x * moveSpeed, 0, input_movement.y * moveSpeed);
        cubeRigidbody.AddForce(movement * moveSpeed * Time.deltaTime, ForceMode.Impulse);
     //   Vector3 look = new Vector3(input_look.x, 0, input_look.y);
        transform.LookAt(transform.position + look * torque * Time.deltaTime) ;


        Vector3 torqueRight = new Vector3(0, input_torqueR, 0);
        cubeRigidbody.AddTorque(torqueRight * torque * Time.deltaTime, ForceMode.Impulse);
        Vector3 torqueLeft = new Vector3(0, -input_torqueL, 0);
        cubeRigidbody.AddTorque(torqueLeft * torque *Time.deltaTime, ForceMode.Impulse);

    }
    /*
    //Own Voids
    //I call the player input void "On Move" to get the Left stick vector values.
    private void OnMove(InputValue vectorValue)
    {
        input_movement = vectorValue.Get<Vector2>();
    }
    //I call the player input void "On Look" to get the Right stick vector values.
    //private void OnLook(InputValue lookVector )
    //{
    //    input_look = lookVector.Get<Vector2>();
    //}
    private void OnTurnRight(InputValue turnRight)
    {
        input_torqueR = turnRight.Get<float>();
    }
    private void OnTurnLeft(InputValue turnLeft)
    {
        input_torqueL = turnLeft.Get<float>();
        //turningLeft= true;

    }
    private void OnKick(InputValue kickValue)
    {
        if (isKickable != false)
        {
            rbBall.AddForceAtPosition(currentHitDirection * hitForce, hit.point, ForceMode.VelocityChange);
        }
    }
    //I draw some gizmos to see the raycast working.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(transform.position, transform.position + transform.right * currentHitDistance);
    }
    */
}