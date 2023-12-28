using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image _fadeImage;

    public void DoFadeOut()
    {
        StartCoroutine(CoFadeOut());
    }

    public void DoFadeIn()
    {
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
}
