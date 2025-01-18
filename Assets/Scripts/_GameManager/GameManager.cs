using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<int> points;

    public static event Action<GameState> OnGameStateChanged;

    private void Awake() {
        instance = this;
    }

    private void AddScore(int scoreIndex, int val) {
        points[scoreIndex] += val;
    }

    private void Start() {
        UpdateGameState(GameState.PlayState);
    }

    public void UpdateGameState(GameState newState) {
        OnGameStateChanged?.Invoke(newState); // -> null
    }
}
