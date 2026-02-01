using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 10f;
    public float sprintMultiplier = 2f;

    [Header("Vertical Movement")]
    public float verticalSpeed = 10f;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // --- Horizontal movement (WASD) ---
        float h = Input.GetAxis("Horizontal");   // A / D
        float v = Input.GetAxis("Vertical");     // W / S

        Vector3 move = transform.forward * v + transform.right * h;

        // --- Vertical movement (Space + LeftShift) ---
        if (Input.GetKey(KeyCode.Space))
        {
            move += Vector3.up * verticalSpeed;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            move += Vector3.down * verticalSpeed;
        }

        // --- Sprinting (Hold Left Ctrl) ---
        float speed = moveSpeed;
        if (Input.GetKey(KeyCode.LeftControl))
        {
            speed *= sprintMultiplier;
        }

        controller.Move(move * speed * Time.deltaTime);
    }
}
