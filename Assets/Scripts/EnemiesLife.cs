using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesLife : MonoBehaviour
{
    public float life;

    private void Awake()
    {
        life = 100f;
    }

    private void Update()
    {
        Death();
        Debug.Log(life);
    }

    void Death()
    {
        if (life <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
