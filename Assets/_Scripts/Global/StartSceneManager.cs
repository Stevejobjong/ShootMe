using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{
    public static float EnemyBulletSpeed = 0;
    [SerializeField] private Rigidbody _easyStart;
    [SerializeField] private Rigidbody _hardStart;
    [SerializeField] private Rigidbody _exit;
    [SerializeField] private Image _fadeImage;
    private bool _isSelect = false;
    private void Update()
    {
        if (_isSelect)
            return;

        if(_easyStart.velocity.magnitude!=0)
        {
            _isSelect = true;
            EnemyBulletSpeed = 10f;
            StartCoroutine(CoLoadScene());
        }
        else if (_hardStart.velocity.magnitude != 0)
        {
            _isSelect = true;
            EnemyBulletSpeed = 100f;
            StartCoroutine(CoLoadScene());
        }
        else if(_exit.velocity.magnitude!=0)
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
