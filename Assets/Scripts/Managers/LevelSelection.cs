using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private bool isUnlocked;
    public Image locked;

    void Start()
    {
        //PlayerPrefs.DeleteAll();
    }

    void Update()
    {
        UpdateUnlockStatus();
    }

    private void UpdateUnlockStatus()
    {
        int levelNum = int.Parse(gameObject.name) - 1;

        if(PlayerPrefs.GetInt("Lv" + levelNum.ToString()) > 0)
        {
            isUnlocked = true;
        }

        if(!isUnlocked)
        {
            locked.gameObject.SetActive(true);
        }
        else
        {
            locked.gameObject.SetActive(false);
        }
    }

    public void LevelSelected(string _LevelName)
    {
        if (isUnlocked)
        {
            SceneManager.LoadScene(_LevelName);
        }
    }
}
