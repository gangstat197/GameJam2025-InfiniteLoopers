using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static event Action<GameState> OnGameStateChanged;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        UpdateGameState(GameState.StartState);
    }

    public void UpdateGameState(GameState newState) {
        OnGameStateChanged?.Invoke(newState); // -> null
    }
}
