using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    private const float playerDistanceSpawnLevel = 100f;

    [SerializeField] private Transform lvlPartStart;
    [SerializeField] private List<Transform> ObstaclesTempList;
    [SerializeField] private GameObject player;

    private Vector3 lastEndPos;

    private void Awake()
    {
        lastEndPos = lvlPartStart.Find("EndPos").position;
        SpawnLvlPart();
    }
    private void Update()
    {
        if(Vector3.Distance(player.GetComponent<Transform>().position,lastEndPos) < playerDistanceSpawnLevel)
        {
            //Spawn another lvl
            SpawnLvlPart();
        }
    }

    private void SpawnLvlPart()
    {
        Transform chosenLevelPart = ObstaclesTempList[Random.Range(0, ObstaclesTempList.Count)];
        Transform lastLvlPartTransform = SpawnLvlPart(chosenLevelPart, lastEndPos);
        lastEndPos = lastLvlPartTransform.Find("EndPos").position;
    }

    private Transform SpawnLvlPart(Transform levelPart, Vector3 spawnPos)
    {
        Transform lvlPartTransform = Instantiate(levelPart, spawnPos, Quaternion.identity);
        return lvlPartTransform;
    }
}
