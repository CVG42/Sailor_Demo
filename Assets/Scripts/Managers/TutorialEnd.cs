using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialEnd : MonoBehaviour
{
    bool isOnPlay;
    public string nextSceneName;
    public int levelIndex;
    public GameObject gameOver;

    [SerializeField] SceneController sceneAnim;

    void Start()
    {
        GameManager.GetInstance().onGameStateChanged += OnGameStateChanged;
        OnGameStateChanged(GameManager.GetInstance().currentGameState);
    }

    void Update()
    {
        if (!isOnPlay) return;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("Lv" + levelIndex, 1);
            gameOver.SetActive(true);
            //SceneManager.LoadScene(nextSceneName);
            Debug.Log("Teleport to next scene");
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    void OnGameStateChanged(GAME_STATE _gs)
    {
        isOnPlay = _gs == GAME_STATE.PLAY;
    }
}
