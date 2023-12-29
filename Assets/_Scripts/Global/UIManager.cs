using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image _fadeImage;
    [SerializeField] private GameObject _endPanel;
    public TMP_Text scoreText;
    public void DoFadeOut()
    {
        StopAllCoroutines();
        StartCoroutine(CoFadeOut());
    }

    public void DoFadeIn()
    {
        StopAllCoroutines();
        StartCoroutine(CoFadeIn());
    }
    IEnumerator CoFadeOut()
    {
        Color c = _fadeImage.color;
        while (c.a <= 1.0f)
        {
            c.a += Time.deltaTime;
            _fadeImage.color = c;
            yield return null;
        }
    }
    IEnumerator CoFadeIn()
    {
        Color c = _fadeImage.color;
        while (c.a >= 0f)
        {
            c.a -= Time.deltaTime;
            _fadeImage.color = c;
            yield return null;
        }
    }
    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void ActivateEndPanel()
    {
        _endPanel.SetActive(true);
    }
}
