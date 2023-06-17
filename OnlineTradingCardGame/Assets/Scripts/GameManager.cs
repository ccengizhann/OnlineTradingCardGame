using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : SingletonDestroy<GameManager>
{
    [SerializeField] public bool isGameStart = false;
    [SerializeField] public bool isGameStop = false;

    public TeamColor PlayableColor;
    public TeamColor PlayerColor;
    public void BeginGame()
    {
        GameUtils.GameResume();
        isGameStart = true;
        isGameStop = false;
    }
    
    public void PauseGame()
    {
        isGameStart = false;
        isGameStop = true;
        GameUtils.GameStop();
    }

    public void SwitchTurn()
    {
        switch (PlayableColor)
        {
            case TeamColor.Blue:
                PlayableColor = TeamColor.Red;
                break;
            case TeamColor.Red:
                PlayableColor = TeamColor.Blue;
                break;
        }
    }
}
