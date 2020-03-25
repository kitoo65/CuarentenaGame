using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersLife : MonoBehaviour
{
    public float life;

    private void Awake()
    {
        life = 100f;
    }
}
