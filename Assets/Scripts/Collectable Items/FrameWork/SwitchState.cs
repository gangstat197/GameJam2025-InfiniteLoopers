using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchState : MonoBehaviour
{   
    public GameState newState;
    public Button button;

    public void Start() {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => Switch(newState));
    }

    public void Switch(GameState state){
        GameManager.instance.UpdateGameState(state);
    }
}
