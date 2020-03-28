using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoGordo : MonoBehaviour
{
    public EnemigoRapido enemigoRapido;
    public Transform spawnPosition;
    public Transform spawnPosition2;
    public EnemiesLife enemiesLifeScript;

    private void Start()
    {
        enemiesLifeScript = gameObject.GetComponent<EnemiesLife>();
    }

    
    public void Split()
    {
        Instantiate(enemigoRapido, spawnPosition.position, spawnPosition.rotation);
        Instantiate(enemigoRapido, spawnPosition2.position, spawnPosition2.rotation);
    }
}
