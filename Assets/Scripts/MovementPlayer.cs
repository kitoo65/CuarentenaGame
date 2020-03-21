using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public Rigidbody rbPlayer;
    public float playerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = gameObject.GetComponent<Rigidbody>();
        playerSpeed = 2;
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoHorizontal();
        MovimientoVertical();

    }

    private void MovimientoHorizontal()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
        }

        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
        }
    }
    private void MovimientoVertical()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.Translate(Vector3.back * playerSpeed * Time.deltaTime);
        }

        else if (Input.GetAxis("Vertical") < 0)
        {
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        }
    }
}
