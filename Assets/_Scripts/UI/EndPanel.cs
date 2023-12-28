using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _bestScore;
    [SerializeField] private TMP_Text _currentScore;
    private void OnEnable()
    {
        int bestScore = 0;
        int currentScore = GameManager._instance.score;
        if (PlayerPrefs.HasKey("Score"))
            bestScore = PlayerPrefs.GetInt("Score");
        if (bestScore < currentScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("Score", currentScore);
        }
        _bestScore.text = $"최고 점수 : {bestScore}";
        _currentScore.text = $"현재 점수 : {currentScore}";
    }
}
