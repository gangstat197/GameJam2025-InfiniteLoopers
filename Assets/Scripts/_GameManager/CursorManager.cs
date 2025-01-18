using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{ 
    private void Awake() {
      GameManager.OnGameStateChanged += HandleGameStateChanged;
    }
    
    private void OnDestroy() {
      GameManager.OnGameStateChanged -= HandleGameStateChanged;
    }

    private void HandleGameStateChanged(GameState newState) {
      // Quản lý trạng thái con trỏ tùy theo GameState
      if (newState == GameState.PlayState)
      {
        // Tắt con trỏ khi ở trạng thái PlayState
        Cursor.visible = false;
      }
      else
      {
        // Bật con trỏ trong các trạng thái khác
        Cursor.visible = true;
      }
    }   
}
