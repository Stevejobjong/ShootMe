using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{
    [SerializeField] private Rigidbody _start;
    [SerializeField] private Rigidbody _exit;
    [SerializeField] private Image _fadeImage;
    private bool _isSelect = false;
    private void Update()
    {
        if(!_isSelect && _start.velocity.magnitude!=0)
        {
            _isSelect = true;
            StartCoroutine(CoLoadScene());
        }else if(!_isSelect && _exit.velocity.magnitude!=0)
        {
            _isSelect = true;
            Application.Quit();
        }
    }
    IEnumerator CoLoadScene()
    {
        Color c = _fadeImage.color;
        while(c.a <= 1.0f)
        {
            c.a += Time.deltaTime;
            _fadeImage.color = c;
            yield return null;
        }
        SceneManager.LoadScene("MainScene");
    }
}
