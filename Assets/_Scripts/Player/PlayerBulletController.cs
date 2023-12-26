using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    private float lifeTime = 1.0f;
    private Rigidbody _rb;
    private TrailRenderer _trailRenderer;
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _trailRenderer = GetComponent<TrailRenderer>();
    }
    private void OnEnable()
    {
        ResetBullet(1000f);
    }
    void Update()
    {
        //lifeTime -= Time.deltaTime;
        if (lifeTime < 0.0f)
        {
            _trailRenderer.Clear();
            gameObject.SetActive(false);
        }
    }
    public void ResetBullet(float speed)
    {
        _trailRenderer.Clear();
        _rb.velocity = Vector3.zero;
        //회전속도도 초기화
        _rb.angularVelocity = Vector3.zero;


        if (GameManager._instance.CurrentGameState == GameManager.GameState.CLEAR)
            speed = 50f;
        _rb.AddForce(transform.forward * speed);
        lifeTime = 1.0f;
    }
}
