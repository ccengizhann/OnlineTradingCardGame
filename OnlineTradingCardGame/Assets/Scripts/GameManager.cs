using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonDestroy<GameManager>
{
    [SerializeField] public bool isGameStart = false;
    [SerializeField] public bool isGameStop = false;
    
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
}
