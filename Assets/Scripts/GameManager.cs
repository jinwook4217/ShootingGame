using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject menuUI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        menuUI.SetActive(false);
    }

    public void StopGame()
    {
        Time.timeScale = 0;
        menuUI.SetActive(true);
        GameObject.Find("Joystick canvas XYBZ").SetActive(false);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Shooting");
    }
}
