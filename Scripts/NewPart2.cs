using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPart2 : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject obstaclePrefabs;
    [SerializeField] GameObject endPos;
    [SerializeField] GameObject startingObj;
    [SerializeField] float distanceFromP = 240f;
    [SerializeField] float newObstacleDistanceX = 40f;

    Camera mainCam;

    bool isPlaced = false;
    float startXPos;

    private void Start()
    {
        float distanceOfPlayerAndOb = player.transform.position.x - obstaclePrefabs.transform.position.x;
        startXPos = startingObj.transform.position.x;
        mainCam = Camera.main;
    }

    private void Update()
    {
        if (player.transform.position.x > endPos.transform.position.x - distanceFromP)
        {
            RandomObstaclePlacer();
        }
        DestroyPartOutOfView();
    }

    void RandomObstaclePlacer()
    {

        float randomY = endPos.transform.position.y + Random.Range(-10f, 10f);
        float setX = endPos.transform.position.x + newObstacleDistanceX;

        Vector3 obstacleNewPos = new Vector3(setX, randomY, 0f);

        endPos.transform.position = obstacleNewPos;
        Instantiate(obstaclePrefabs, obstacleNewPos, Quaternion.identity);

    }

    void DestroyPartOutOfView()
    {
        Vector3 camPos = mainCam.ScreenToViewportPoint(mainCam.transform.position);
        Debug.Log($"Camera pos: {camPos}");
        //if(obstaclePrefabs)
    }
}
