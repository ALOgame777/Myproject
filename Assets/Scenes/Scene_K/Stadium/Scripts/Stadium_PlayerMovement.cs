using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stadium_PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody를 가져옵니다.
    }

    void Update()
    {
        // 이동
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        transform.Translate(move, Space.World);

        // 점프
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    // 바닥과 접촉 여부 확인
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
