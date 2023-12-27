using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : Bullet
{
    [SerializeField] private Transform _body;
    [SerializeField] private GameObject _cam;
    private Transform _targetTransform;
    private bool iscolldier = false;

    private void Awake()
    {
        _speed = 10f;
        TurnOffCam();
    }
    private void OnEnable()
    {
        iscolldier = false;
        ResetBullet();
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
            print("게임 오버");
        }
        else
        {
            if (!iscolldier)
            {
                print("충돌");
                iscolldier = true;
                StartCoroutine(CoNextBullet(collision.gameObject));
            }
        }
    }
    //public void 
    public void TurnOnCam()
    {
        _cam.SetActive(true);
    }
    public void TurnOffCam()
    {
        _cam.SetActive(false);
    }

    public override void ResetBullet()
    {
        base.ResetBullet();
        if (GameManager._instance != null && GameManager._instance.CurrentGameState == GameState.HIT)
            _speed = 0f;
        else
            _speed = 10f;
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
        yield return new WaitForSeconds(3f);
        go.SetActive(false);
        gameObject.SetActive(false);
        GameManager._instance.SpawnEnemy();
    }
}
