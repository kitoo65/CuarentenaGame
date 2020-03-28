using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyBehaviour : MonoBehaviour
{
    public float speed;
    public float damage;

    private void Awake()
    {
        damage = 10f;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);   //Direccion, velocidad de la bala.             
        Destroy(gameObject, 3f);       //La bala se destruye a los 3 segundos 
    }

    private void OnCollisionEnter(Collision other)
    {
        
        Destroy(gameObject); //Y destruyo la bala
    }
}
