using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text currentScoreUI;
    private int currentScore;

    public Text bestScoreUI;
    private int bestScore;

    // 싱글톤 객체
    public static ScoreManager Instance = null;

    // Get/Set 프로퍼티
    public int Score
    {
        get
        {
            return currentScore;
        }
        set
        {
            // currentScore 속성에 값을 할당한다
            currentScore = value;

            // UI에 표시하기
            currentScoreUI.text = "현재점수 : " + currentScore;

            // 현재 점수가 최고 점수보다 크다면
            if (currentScore > bestScore)
            {
                // 최고 점수를 갱신한다
                bestScore = currentScore;
                // 최고 점수를 UI에 표시한다
                bestScoreUI.text = "최고점수 : " + bestScore;

                // 최고 점수를 내부에 저장한다
                PlayerPrefs.SetInt("BestScore", bestScore);
            }
        }
    }

    // 싱글톤 객체에 값이 없으면 생성된 자기 자신을 할당
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // 내부에서 최고 점수 데이터를 불러온다
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        // 최고 점수를 UI에 표시한다
        bestScoreUI.text = "최고점수 : " + bestScore;
    }
}
