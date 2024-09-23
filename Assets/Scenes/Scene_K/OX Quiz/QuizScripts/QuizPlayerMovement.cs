using UnityEngine;

public class QuizPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 플레이어 이동 속도

    private Vector3 movement;

    void Update()
    {
        // 입력을 가져오기 (WASD 또는 방향키)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // 이동 방향 설정
        movement = new Vector3(moveHorizontal, 0, moveVertical);

        // 플레이어 이동
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }
}
