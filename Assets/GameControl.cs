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

    private int _lastEffectIdx = 0;
    private GameObject[] _winEffects;

    private GameMode _mode = GameMode.StartScreen;

    void Awake()
    {
        _splatFolder = GameObject.FindWithTag("SplatFolder");
        _audioMgr = GameObject.FindObjectOfType<AudioManager>();

        _winEffects = GameObject.FindGameObjectsWithTag("win");
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
                    if(_winEffects.Length > 0)
                    {
                        _winEffects[_lastEffectIdx].SetActive(true);
                        var t = _winEffects[_lastEffectIdx].transform;
                        var newPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, t.position.z);
                        Debug.Log($"update location - current position = {t.position.x}, {t.position.y}; new = {newPos.x}, {newPos.y}");

                        t.position = newPos;
                        _lastEffectIdx++;
                        if (_lastEffectIdx >= _winEffects.Length)
                            _lastEffectIdx = 0;
                    }

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

        foreach (var we in _winEffects)
            we.SetActive(false);

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