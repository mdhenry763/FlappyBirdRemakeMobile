using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 25f;
    [SerializeField] float jumpFactor = 0.2f;
    [SerializeField] float speedMultiplier = 0.1f;
    [SerializeField] GameObject player;
    [SerializeField] float lerpMulti = 1f;

    private void Start()
    {
        EnableGrav(true);
    }

    // Update is called once per frame
    void Update()
    {
        playerSpeed += (speedMultiplier*Time.deltaTime);
        transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);

        
        if (!Touchscreen.current.primaryTouch.press.isPressed)
        {
            EnableGrav(true);
            player.GetComponent<Rigidbody>().isKinematic = false;
            return;
        }

        PlayerJump();

    }

    private void OnTriggerEnter(Collider other)
    {
        /*if(other.name == "Obstacles")
        {*/
            Debug.Log("I have been hit");
        //}
    }

    void EnableGrav(bool gravity)
    {
        player.GetComponent<Rigidbody>().useGravity = true;
    }

    void PlayerJump()
    {
        EnableGrav(false);
        float newYPosAfterJump = transform.position.y + jumpFactor;
        Vector3 newPosAfterJump = new Vector3(transform.position.x, newYPosAfterJump, transform.position.z);
        //Rigidbody rb = GetComponentInChildren<Rigidbody>();
        transform.position = Vector3.Lerp(transform.position, newPosAfterJump, 50f * Time.deltaTime);
        player.GetComponent<Rigidbody>().isKinematic = true;
        
    }
}
