using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    [Tooltip("In sec")][SerializeField] int timeToLoad = 5;

    void Start()
    {
        Invoke("LoadNextScene", timeToLoad);
    }

    private void LoadNextScene() //String refrence
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
