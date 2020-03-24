using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    public int playerOneScore;

    public int playerTwoScore;

    public Vector3 ballspawnpoint;

    public Text playerOneText;
    public Text playerTwoText;
    public Text endGameText;

    public Vector3 center;
    public Vector3 size;

    int randomSpawnObInt;
    public GameObject[] obstacles;

    public GameObject ball;

    public float randomZPos;

    public GameObject camara;

    private void Start()
    {
        randomZPos = Random.Range(-10f, 10f);
        ballspawnpoint = new Vector3(0f, 1f, randomZPos);
        Instantiate(ball, ballspawnpoint, Quaternion.identity);
        camara.GetComponent<CameraFollow>().AddObjectsToList();
    }
    private void Update()
    {

        playerOneText.text = playerOneScore.ToString();
        playerTwoText.text = playerTwoScore.ToString();
        EndGame();
    }
    public void SpawnOb()
    {
        randomSpawnObInt = Random.Range(0, obstacles.Length);
        Vector3 pos = center + new Vector3(Random.Range(-size.x, size.x) / 2, Random.Range(-size.y, size.y) / 2, Random.Range(-size.z, size.z) / 2);
        Instantiate(obstacles[randomSpawnObInt], pos, Quaternion.identity);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 0, 1, 0.21f);
        Gizmos.DrawCube(center, size);
    }
    void EndGame()
    {
        if(playerOneScore >= 10f || playerTwoScore >= 10f)
        {
            Debug.Log("Adentro");
            ball = GameObject.FindGameObjectWithTag("Ball");
            Destroy(ball);
            if(playerOneScore >= 10f)
            {
                endGameText.text = "Player One Wins!";
                Debug.Log("P1Wins");
            }
            else if(playerTwoScore >= 10f)
            {
                endGameText.text = "Player Two Wins!";
                Debug.Log("PWins");
            }
            endGameText.enabled = true;
        }
    }
}
