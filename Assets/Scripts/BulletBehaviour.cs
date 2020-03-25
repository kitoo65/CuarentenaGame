using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed;
    public float damage;

    private void Awake()
    {
        damage = 10f;
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);   //Direccion, velocidad de la bala.             
        Destroy(gameObject, 3f);       //La bala se destruye a los 3 segundos 
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy")) //Si la bala colisiona con el enemigo entonces...
        {
            other.gameObject.GetComponent<EnemiesLife>().life = other.gameObject.GetComponent<EnemiesLife>().life - damage; //Accedo al script enemigo, a la variable vida y le resto mi variable damage
            Destroy(gameObject); //Y destruyo la bala
        }       
    }
}
