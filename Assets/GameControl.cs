using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public GameObject StartMenuUI;
    public GameObject PauseMenuUI;
    public GameObject StartingCake;

    public void StartGame()
    {
        StartMenuUI.SetActive(false);
        PauseMenuUI.SetActive(false);

        Instantiate(StartingCake, new Vector3(0,0,0), Quaternion.identity);
    }

    public void Win()
    {
        PauseMenuUI.SetActive(true);
    }
}
