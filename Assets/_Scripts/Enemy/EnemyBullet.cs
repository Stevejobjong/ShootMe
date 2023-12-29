using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : Bullet
{
    [SerializeField] private Transform _body;
    [SerializeField] private GameObject _mesh;
    private Transform _targetTransform;

    //중복 충돌을 방지
    private bool iscolldier = false;

    private void Awake()
    {
        _speed = StartSceneManager.EnemyBulletSpeed;
        if (_speed != 10 || _speed != 50)
            Debug.LogWarning("StartScene에서 시작해주세요.");
    }
    private void OnEnable()
    {
        iscolldier = false;
        StopAllCoroutines();
        ResetBullet();
        TurnOnCam();
    }
    private void Start()
    {
        SetTarget();
    }
    private void Update()
    {
        _body.Rotate(new Vector3(20f * Time.deltaTime, 0, 0));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager._instance.StateGameOver();
            _mesh.gameObject.SetActive(false);
        }
        else
        {
            if (!iscolldier)
            {
                GameManager._instance.StateHit();
                ResetBullet();
                iscolldier = true;
                StartCoroutine(CoNextBullet(collision.gameObject));
            }
        }
    }
    public void TurnOnCam()
    {
        GameManager._instance.FadeIn();
    }
    public void TurnOffCam()
    {
        GameManager._instance.FadeOut();
    }

    public override void ResetBullet()
    {
        base.ResetBullet();
        if (GameManager._instance != null && GameManager._instance.CurrentGameState == GameState.HIT)
            _speed = 0f;
        else
            _speed = StartSceneManager.EnemyBulletSpeed;
        SetTarget();
    }

    public void SetTarget()
    {
        _targetTransform = GameManager._instance.Player.transform;
        transform.LookAt(_targetTransform.position + new Vector3(0, 1.5f, 0));
        _rb.AddForce(transform.forward * _speed);
    }
    IEnumerator CoNextBullet(GameObject go)
    {
        yield return new WaitForSeconds(1f);
        TurnOffCam();
        yield return new WaitForSeconds(2f);
        go.SetActive(false);
        gameObject.SetActive(false);
        GameManager._instance.SpawnEnemy();
    }
}
