using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI point;
    public List<int> points;
    public static event Action<GameState> OnGameStateChanged;

    private void Awake() {
        instance = this;
    }

    private void Update() {
        point.text = points[0].ToString();
    }
    public void AddScore(int scoreIndex, int val) {
        Debug.Log("Hey Hey");
        points[scoreIndex] += val;
    }

    private void Start() {
        UpdateGameState(GameState.StartState);
    }

    public void UpdateGameState(GameState newState) {
        OnGameStateChanged?.Invoke(newState); // -> null
    }
}
