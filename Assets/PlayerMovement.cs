using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float velocity = 5;
    public float turnSpeed = 2;

    private PlayerInput playerInput;
    private CharacterController controller;

    public float movex;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Gather Input
        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);

        Debug.Log("movex");
        // move player forward
        transform.Translate(Vector3.forward * velocity * Time.deltaTime);

        // move player side to side
        transform.Translate(move * turnSpeed * Time.deltaTime);
    }
}
