using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoDisparoUnico : MonoBehaviour
{
    public float startTimeShooting;
    private float timeShooting;
    public Transform shotPosition;
  


    public BulletEnemyBehaviour bulletEnemy;

    //aiming
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Shoot()
    {
        Aim();
        if (timeShooting <=0)
        {

            Debug.Log("Bam");
            //Spawn Bala
            Instantiate(bulletEnemy,shotPosition.position,shotPosition.rotation);
            timeShooting = startTimeShooting;

            
        }
        else
        {
            timeShooting -= Time.deltaTime;
        }
    }
    public void Aim()
    {
        transform.LookAt(target);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
