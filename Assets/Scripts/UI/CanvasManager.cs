using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{   
    public GameObject deadCanvas;
    public GameObject playCanvas;

    // Update is called once per frame
    private void Awake() {
        GameManager.OnGameStateChanged += CanvasManagerOnStateChanged;
    }

    private void OnDestroy() {
        GameManager.OnGameStateChanged -= CanvasManagerOnStateChanged;
    }

    private void CanvasManagerOnStateChanged(GameState newState) {
        if (newState == GameState.PlayState) {
            playCanvas.gameObject.SetActive(true);
            deadCanvas.gameObject.SetActive(false);
        } else
        if (newState == GameState.DeadState) {
            playCanvas.gameObject.SetActive(false);
            deadCanvas.gameObject.SetActive(true);
        } else {
            playCanvas.gameObject.SetActive(false);
            deadCanvas.gameObject.SetActive(false);
        }
    }
}
