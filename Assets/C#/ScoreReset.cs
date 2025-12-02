using UnityEngine;

public class ScoreReset : MonoBehaviour
{
    // スコアをリセットするメソッド
    public static void ResetScore()
    {
        DataManager.Instance.max = 0;
        DataManager.Instance.score_first = 0;
        DataManager.Instance.isBGM = 1;
        DataManager.Instance.isSound = 1;
        DataManager.Instance.create = 1;
    }

    public static float getScore()
    {
        return DataManager.Instance.score_first;
    }

    public static float getCombo()
    {
        return DataManager.Instance.comboCount;
    }

    void Start()
    {
        ResetScore();
    }
}