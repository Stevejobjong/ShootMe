using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    [SerializeField] private TrailRenderer _trailRenderer;
    private void OnEnable()
    {
        ResetBullet();
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
    }
}
