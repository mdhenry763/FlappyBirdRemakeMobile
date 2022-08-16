using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMover : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector2 move;

    public int score = 0;

    void Update()
    {
        Vector3 playerPos = player.transform.position;
        transform.position = new Vector3(playerPos.x + move.x, playerPos.y + move.y, gameObject.transform.position.z);
    }

    public void IncreaseScore()
    {
        score++;
        Debug.Log(score);
    }
}
