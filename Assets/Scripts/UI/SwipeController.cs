using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeController : MonoBehaviour, IEndDragHandler
{
    [Header("Pages variables")]
    [Tooltip("Set maximum number of pages (levels/planets)")]
    [SerializeField] int maxPage;
    int currentPage;
    Vector3 targetPos;
    [Tooltip("Set next page Position")]
    [SerializeField] Vector3 pageStep;
    [Tooltip("Set pages scroll rect")]
    [SerializeField] RectTransform levelPagesRect;
    float dragThreshould;

    [Header("UI Navigation Buttons")]
    [Tooltip("Set corresponding UI buttons")]
    [SerializeField] Button previousBtn;
    [SerializeField] Button nextBtn;

    [Header("Active and inactive pages navigation")]
    [SerializeField] Image[] navImage;
    [SerializeField] Sprite activePage;
    [SerializeField] Sprite inactivePage;

    [Header("LeanTween variables")]
    [Tooltip("Time between each swipe transition")]
    [SerializeField] float tweenTime;
    [Tooltip("Type of transition")]
    [SerializeField] LeanTweenType tweenType;

    private void Awake()
    {
        currentPage = 1;
        targetPos = levelPagesRect.localPosition;
        dragThreshould = Screen.width / 15;
        UpdateButtonState();
    }

    void UpdateNavigation()
    {
        foreach(var item in navImage)
        {
            item.sprite = inactivePage;
        }
        navImage[currentPage - 1].sprite = activePage;
    }

    void UpdateButtonState()
    {
        nextBtn.interactable = true;
        previousBtn.interactable = true;
        if (currentPage == 1) previousBtn.interactable = false;
        else if (currentPage == maxPage) nextBtn.interactable = false;
    }

    public void Next()
    {
        if(currentPage < maxPage)
        {
            currentPage++;
            targetPos += pageStep;
            MovePage();
        }
    }

    public void Previous()
    {
        if(currentPage > 1)
        {
            currentPage--;
            targetPos -= pageStep;
            MovePage();
        }
    }

    void MovePage()
    {
        levelPagesRect.LeanMoveLocal(targetPos, tweenTime).setEase(tweenType);
        UpdateButtonState();
        UpdateNavigation();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(Mathf.Abs(eventData.position.x - eventData.pressPosition.x) > dragThreshould)
        {
            if (eventData.position.x > eventData.pressPosition.x) Previous();
            else Next();
        }
        else
        {
            MovePage();
        }
    }
}
