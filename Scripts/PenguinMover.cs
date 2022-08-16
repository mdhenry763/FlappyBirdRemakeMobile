using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PenguinMover : MonoBehaviour
{
    [SerializeField] float speedPenguin = 5f;

    [SerializeField] GameObject player;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speedPenguin);
        KeepPenguinOnScreen();
    }

    void KeepPenguinOnScreen()
    {
        float posOfPenAndPlayer = transform.position.x - player.transform.position.x;
        float repositionPenguin = player.transform.position.x + 120;
       // Debug.Log(transform.position);
        //Debug.Log($"Distance between: {posOfPenAndPlayer}");

        if ( posOfPenAndPlayer  < -50)
        {
            transform.position = new Vector3(repositionPenguin, transform.position.y, transform.position.z);
        }
    }
}
