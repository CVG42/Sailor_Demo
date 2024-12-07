using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataOptions : MonoBehaviour
{
    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }
}
