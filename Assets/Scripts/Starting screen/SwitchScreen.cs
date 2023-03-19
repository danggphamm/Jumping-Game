using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitchScreen : MonoBehaviour
{
    public string theScreenToLoad;

    public void LoadScreen()
    {
        SceneManager.LoadScene(theScreenToLoad);
    }
}
