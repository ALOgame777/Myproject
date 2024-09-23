using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizPlayer : MonoBehaviour
{
    private OXQuizManager quizManager;

    void Start()
    {
        quizManager = FindObjectOfType<OXQuizManager>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어가 O,X 존에 들어갈때
        if (other.gameObject.CompareTag("O_Zone") || other.gameObject.CompareTag("X_Zone"))
        {
            if (quizManager.IsCorrectAnswer(other.gameObject))
            {
                quizManager.IncreasePlayerScore();
            }
        }    

    }
}
