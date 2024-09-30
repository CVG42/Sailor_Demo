using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    bool isOnPlay;

    [Header("space between menu items")]
    [SerializeField] Vector2 spacing;

    [Space]
    [Header("Main button rotation")]
    [SerializeField] float rotationDuration;
    [SerializeField] Ease rotationEase;

    [Space]
    [Header("Animation")]
    [SerializeField] float expandDuration;
    [SerializeField] float collapseDuration;
    [SerializeField] Ease expandEase;
    [SerializeField] Ease collapseEase;

    [Space]
    [Header("Fading")]
    [SerializeField] float expandFadeDuration;
    [SerializeField] float collapseFadeDuration;

    Button mainButton;
    PauseItem[] menuItems;

    bool isExpanded = false;

    Vector2 mainButtonPosition;
    int itemsCount;

    private void Start()
    {
        GameManager.GetInstance().onGameStateChanged += OnGameStateChanged;

        itemsCount = transform.childCount - 1;
        menuItems = new PauseItem[itemsCount];
        for (int i = 0; i < itemsCount; i++)
        {
            menuItems[i] = transform.GetChild(i + 1).GetComponent<PauseItem>();
        }

        mainButton = transform.GetChild(0).GetComponent<Button>();
        mainButton.onClick.AddListener(ToggleMenu);
        mainButton.transform.SetAsLastSibling();

        mainButtonPosition = mainButton.GetComponent<RectTransform>().anchoredPosition;

        ResetPositions();
    }

    void ResetPositions()
    {
        for (int i = 0; i < itemsCount; i++)
        {
            menuItems[i].rectTrans.anchoredPosition = mainButtonPosition; menuItems[i].img.DOFade(0f, expandFadeDuration).From(0f);
        }
    }

    void ToggleMenu()
    {
        isExpanded = !isExpanded;

        if (isExpanded)
        {
            GameManager.GetInstance().ChangeGameState(GAME_STATE.PAUSE);
            //menu opened
            for (int i = 0; i < itemsCount; i++)
            {
                menuItems[i].rectTrans.DOAnchorPos(mainButtonPosition + spacing * (i + 1), expandDuration).SetEase(expandEase);
                menuItems[i].img.DOFade(1f, expandFadeDuration).From(0f);
            }
        }
        else
        {
            GameManager.GetInstance().ChangeGameState(GAME_STATE.PLAY);
            //menu closed
            for (int i = 0; i < itemsCount; i++)
            {
                menuItems[i].rectTrans.DOAnchorPos(mainButtonPosition, collapseDuration).SetEase(collapseEase);
                //Fade to alpha=0
                menuItems[i].img.DOFade(0f, collapseFadeDuration);
            }
        }

        mainButton.transform.DORotate(Vector3.forward * 180f, rotationDuration).From(Vector3.zero).SetEase(rotationEase);
    }

    public void OnItemClick(int index)
    {
        //here you can add you logic 
        switch (index)
        {
            case 0:
                //first button
                SceneManager.LoadScene("Menu");
                GameManager.GetInstance().ChangeGameState(GAME_STATE.PLAY);
                Debug.Log("Main Menu");
                break;
            case 1:
                //second button
                Debug.Log("Settings");
                break;
        }
    }

    void OnDestroy()
    {
        mainButton.onClick.RemoveListener(ToggleMenu);
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
