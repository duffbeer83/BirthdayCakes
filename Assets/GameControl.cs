using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public GameObject StartMenuUI;
    public GameObject PauseMenuUI;
    public GameObject StartingCake;

    private GameObject _splatFolder;
    private AudioManager _audioMgr;

    private GameMode _mode = GameMode.StartScreen;

    void Awake()
    {
        _splatFolder = GameObject.FindWithTag("SplatFolder");
        _audioMgr = GameObject.FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (_mode)
            {
                case GameMode.StartScreen:
                    StartGame();
                    _audioMgr.Play("click");
                    break;
                case GameMode.GameScreen:
                    _audioMgr.Play("click");
                    break;
                case GameMode.WinScreen:
                    break;
            }
        }
    }

    public void StartGame()
    {
        _mode = GameMode.GameScreen;

        _audioMgr.ScalePitch("theme", 1f);

        StartMenuUI.SetActive(false);
        PauseMenuUI.SetActive(false);

        foreach (Transform child in _splatFolder.transform)
            GameObject.Destroy(child.gameObject);
        
        Instantiate(StartingCake, new Vector3(0,0,0), Quaternion.identity);
    }

    public void Win()
    {
        _mode = GameMode.WinScreen;

        _audioMgr.ScalePitch("theme", 1f);

        PauseMenuUI.SetActive(true);
    }
}


public enum GameMode
{
    StartScreen,
    GameScreen,
    WinScreen
}