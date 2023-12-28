using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    private float lifeTime = 1.0f;
    [SerializeField] private TrailRenderer _trailRenderer;
    private void OnEnable()
    {
        ResetBullet();
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
    public override void ResetBullet()
    {
        base.ResetBullet();
        _trailRenderer.Clear();

        if (GameManager._instance != null && GameManager._instance.CurrentGameState == GameState.HIT)
            _speed = 50f;
        else
            _speed = 1000f;
        _rb.AddForce(transform.forward * _speed);
        //lifeTime = 1.0f;
    }
}
