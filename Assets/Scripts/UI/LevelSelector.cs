using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void LevelOne()
    {
        SceneManager.LoadScene("Uno");
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene("LasersOne");
    }

    public void LevelThree()
    {
        SceneManager.LoadScene("Movement");
    }
}
