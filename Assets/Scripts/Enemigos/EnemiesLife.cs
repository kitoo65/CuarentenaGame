using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesLife : MonoBehaviour
{
    public float life; //ahora lo modificamos en el editor
    public EnemigoGordo enemigoGordoScript;



    private void Update()
    {
        Death();
    }

    void Death()
    {
        if (life <= 0f)
        {
            if (this.gameObject.GetComponent<EnemigoGordo>() == null)
            {

            }
            else
            {
                enemigoGordoScript.Split(); //Ejecuta la funcion para spawnear nuevos enemigos
            }
          
                Destroy(this.gameObject);
           
            

        }
    }
}
