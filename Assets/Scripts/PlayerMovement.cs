using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float shootSpeed;

    Rigidbody rb;

    Vector3 moveInput;
    Vector3 moveVelocity;

    public Transform shotPosition;
    public BulletBehaviour bullet;

    public ParticleSystem fx_Shot;  //(Valen) Aca declaro un particle system que va a ser el FX del disparo.
    


    PlayerControls controls;

    Vector2 move;
    Vector2 rotate;

    //Movimiento Relativo con respecto a la camara
    public Transform camTransform;
    public float forceMultiplier;


    private void Awake()
    {
        controls = new PlayerControls();

        controls.PlayerMovement.Shoot.performed += ctx => OnAttack();

        controls.PlayerMovement.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.PlayerMovement.Move.canceled += ctx => move = Vector2.zero;

        controls.PlayerMovement.Rotate.performed += ctx => rotate = ctx.ReadValue<Vector2>();
        controls.PlayerMovement.Rotate.canceled += ctx => rotate = Vector2.zero;
    }

    private void OnEnable()
    {
        controls.PlayerMovement.Enable();
    }

    private void OnDisable()
    {
        controls.PlayerMovement.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        camTransform = GameObject.FindObjectOfType<Camera>().gameObject.transform;

        fx_Shot = transform.GetChild(0).GetComponentInChildren<ParticleSystem>(); //(Valen)Acá busco en su primer child, un componente del tipo "ParticleSystem" dentro de sus children.

}


void Update()
    {
        Vector3 camF = -camTransform.forward;
        Vector3 camR = -camTransform.right;
        camF.y = 0;
        camR.y = 0;

        camF = camF.normalized;
        camR = camR.normalized;

        /*
        No lo voy a borrar porque es una joyita, pero no funca relativamente
        Vector3 m = new Vector3(move.x,0f, move.y) * moveSpeed * Time.deltaTime*-1f;
        transform.Translate(m,Space.World);
        */
        transform.position += (camR * move.x + camF * move.y) * moveSpeed *Time.deltaTime * -1f;

        if (rotate.magnitude > 0.1f)
        {
            float angle = Mathf.Atan2(rotate.y, rotate.x) * Mathf.Rad2Deg;
            float relativeAngle = Mathf.Atan2(camF.z, camR.x) * Mathf.Rad2Deg;
            //Si tenemos que modificar la rotacion, los valores que hay que modificar son el relative angle y el angulo de inicio (el 90, 270)
            this.transform.rotation = Quaternion.Euler(new Vector3(0, angle + 270f + relativeAngle, 0)*-1f);
        }
    }
     

    void OnAttack()
    {          
        BulletBehaviour bulletIns = Instantiate(bullet, shotPosition.position, shotPosition.rotation) as BulletBehaviour;
        bulletIns.speed = shootSpeed;

        fx_Shot.Play();  //(Valen)Acá le doy play al particle system y como no es loop, se hace one shot. Este fx no se destruye porque se usa varias veces, sino luego de darle play deberiamos destruirlo.

        //bulletIns.velocity = shootSpeed * Vector3.forward;
        //bulletIns.AddForce(Vector3.forward*shootSpeed, ForceMode.Impulse);
    }   
}
