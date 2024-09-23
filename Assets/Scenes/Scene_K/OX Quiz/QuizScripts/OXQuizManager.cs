using System.Collections;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class OXQuizManager : MonoBehaviour
{
    public GameObject Player;
    public QuizPlayerMovement playerMovement;
    public Vector3 startPosition = new Vector3(0, 1, 0);

    public Text questionText;
    public Text countdownText;
    public Text ScoreText;
    public GameObject oZone;   // O 구역
    public GameObject xZone;   // X 구역

    // O와 X 구역의 하위 오브젝트(정답 시 활성화될 구역)
    public GameObject oZoneAnswerArea;
    public GameObject xZoneAnswerArea;

    public string[] questions =
    {
        "1번 문제 : ",
        "2번 문제 : ",
        "3번 문제 : "

    };
    public bool[] correctAnswers =
    {
        false,
        true,
        true
    };
    private int currentQuestionIndex = 0;

    public float countdownTime = 10f;
    private float currentCountdown;

    // 플레이어 점수
    private int playerScore = 0;

    void Start()
    {
        StartQuiz();
        UpdateScoreText();
        playerMovement.enabled = true;
    }

    void StartQuiz()
    {
        currentQuestionIndex = 0;
        if (questions.Length > 0)
        {
            ShowNextQuestion();
        }
        else
        {
            Debug.LogError("퀴즈 질문이 없습니다 질문 배열을 확인하세요.");
            EndQuiz();
        }

    }

    void ShowNextQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            questionText.text = questions[currentQuestionIndex];
            currentCountdown = countdownTime;

            // O와 X 구역의 하위 오브젝트를 모두 비활성화
            oZoneAnswerArea.SetActive(false);
            xZoneAnswerArea.SetActive(false);

            StartCoroutine(CountdownAndCheckAnswer());
        }
        else
        {
            EndQuiz();
        }
    }

    IEnumerator CountdownAndCheckAnswer()
    {
        while (currentCountdown > 0)
        {
            if (currentCountdown <= 5)
            {
                countdownText.text = Mathf.FloorToInt(currentCountdown).ToString();
            }
            else
            {
                countdownText.text = "";
            }
            yield return new WaitForSeconds(1f);
            currentCountdown--;
        }
        
        // 카운트가 끝났을 때 플레이어 움직임 제한 및 위치 이동
        playerMovement.enabled = false; // 플레이어 움직임 비활성화
        countdownText.text = ""; // 카운트 다운 텍스트 숨김
        
        ActivateCorrectZone();
    }

    void ActivateCorrectZone()
    {
        if (correctAnswers[currentQuestionIndex])
        {
            questionText.text = "O 입니다!";
            // O 구역이 정답이면 O 구역의 하위 오브젝트 활성화
            oZoneAnswerArea.SetActive(true);
        }
        else
        {
            questionText.text = "X 입니다!";
            // X 구역이 정답이면 X 구역의 하위 오브젝트 활성화
            xZoneAnswerArea.SetActive(true);
        }

        StartCoroutine(WaitAndShowNextQuestion());
    }

    // 플레이어 점수 증가 
    public void IncreasePlayerScore()
    {
        playerScore++;
        UpdateScoreText();
    }

    void StartNextQuestion()
    {
        currentCountdown = 10f;
        StartCoroutine(CountdownAndCheckAnswer());
    }



    IEnumerator WaitAndShowNextQuestion()
    {
        yield return new WaitForSeconds(2f); // 2초 대기
        currentQuestionIndex++; // 다음 문제로 넘어감

        Player.transform.position = startPosition; // 플레이어 위치 초기화
        playerMovement.enabled = true; // 플레이어 움직임 활성화
        ShowNextQuestion(); // 다음 문제 시작
    }


    public bool IsCorrectAnswer(GameObject zone)
    {
        if (correctAnswers[currentQuestionIndex])
        {
            return zone.CompareTag("O_Zone");
        }
        else
        {
            return zone.CompareTag("X_Zone");
        }
    }

    // 플레이어 점수 표시 텍스트
    void UpdateScoreText()
    {
        ScoreText.text = " 점수 :" + playerScore;
    }

    void EndQuiz()
    {
        questionText.text = "퀴즈를 모두 완료했습니다!";
        countdownText.text = "";
    }
}
