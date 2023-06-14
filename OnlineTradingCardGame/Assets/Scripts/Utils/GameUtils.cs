using UnityEngine;

public class GameUtils
{
    #region Game Stop and Resume Functions

    public static void GameResume() =>
        Time.timeScale = 1f;

    public static void GameStop() =>
        Time.timeScale = 0f;

    public static bool IsGameStillPlay() => Time.timeScale != 0f;

    #endregion
}