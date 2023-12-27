using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { PLAY, HIT, CLEAR };
public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    [field: SerializeField] public BulletManager BulletManager { get; private set; }
    [field: SerializeField] public EnemySpawnManager EnemySpawnManager { get; private set; }
    [field: SerializeField] public GameObject Player { get; private set; }
    [field: SerializeField] public ObjectPool ObjectPool { get; private set; }


    public GameState CurrentGameState { get; private set; }
    private void Awake()
    {
        _instance = this;
        CurrentGameState = GameState.PLAY;
    }
    private void Start()
    {
        SpawnEnemy();
    }
    public void ClearStage()
    {
        CurrentGameState = GameState.CLEAR;
    }

    public void ShootBullet(Vector3 startPostiion, Quaternion startRotation)
    {
        BulletManager.ShootBullet(startPostiion, startRotation);
    }

    public void SpawnEnemy()
    {
        EnemySpawnManager.SpawnEnemy();
    }

    public void StateHit()
    {
        CurrentGameState = GameState.HIT;
    }

    public void StatePlay()
    {
        CurrentGameState = GameState.PLAY;
    }
}
