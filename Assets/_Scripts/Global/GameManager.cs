using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public enum GameState { PLAY, CLEAR};
    public GameState CurrentGameState { get; private set; }
    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ClearStage()
    {
        CurrentGameState = GameState.CLEAR;
    }
}
