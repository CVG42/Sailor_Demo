using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonColorChange : MonoBehaviour
{
    bool isOnPlay;
    public bool isActivated;

    public GameObject laser;
    public Color newColor;

    void Start()
    {
        GameManager.GetInstance().onGameStateChanged += OnGameStateChanged;
        OnGameStateChanged(GameManager.GetInstance().currentGameState);
        isActivated = false;
    }

    void Update()
    {
        if (!isOnPlay) return;
    }

    void OnGameStateChanged(GAME_STATE _gs)
    {
        isOnPlay = _gs == GAME_STATE.PLAY;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActivated)
        {
            isActivated = true;
            Debug.Log("Button is activated");
            laser.gameObject.GetComponent<Renderer>().material.color = newColor;
            transform.position = new Vector3(0.0430000015f, -3.60299993f, -3.99399996f);
        }
    }
}
