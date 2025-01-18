using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadMenu : MonoBehaviour
{
    public GameObject deadMenu;

    private void Awake() {
        GameManager.OnGameStateChanged += DeadMenuOnStateChanged;
    }

    private void OnDestroy() {
        GameManager.OnGameStateChanged -= DeadMenuOnStateChanged;
    }

    private void DeadMenuOnStateChanged(GameState newState) {
        if (newState == GameState.DeadState) {
            deadMenu.SetActive(true);
        } else {
            deadMenu.SetActive(false);
        }
    }
}
