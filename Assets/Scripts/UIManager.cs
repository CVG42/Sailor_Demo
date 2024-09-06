using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    bool isOnPlay;

    private void Start()
    {
        GameManager.GetInstance().onGameStateChanged += OnGameStateChanged;
    }

    public void Pause()
    {
        GameManager.GetInstance().ChangeGameState(GAME_STATE.PAUSE);
    }

    public void Resume()
    {
        GameManager.GetInstance().ChangeGameState(GAME_STATE.PLAY);
    }

    void OnGameStateChanged(GAME_STATE _gs)
    {
        isOnPlay = _gs == GAME_STATE.PLAY;
    }
}
