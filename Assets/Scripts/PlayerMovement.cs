using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerInput input;
    InputAction move;
    InputAction sprint;

    public float moveSpeed;
    float sprintSpeed;
    public bool isSprinting;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = GetComponent<PlayerInput>();

        move = input.actions.FindAction("Move");
        sprint = input.actions.FindAction("Sprint");

        sprint.performed += x => isSprinting = true;
        sprint.canceled += x => isSprinting = false;
        sprintSpeed = moveSpeed + 5;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 direction = move.ReadValue<Vector2>();
        if (isSprinting)
        {
            transform.position += new Vector3(direction.x, 0, direction.y) * sprintSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += new Vector3(direction.x, 0, direction.y) * moveSpeed * Time.deltaTime;
        }
    }
}
