using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;

    // 共有したい変数を宣言
    public int yoko = 0;
    public int comboCount = 0;
    public int maxcombo = 0;
    public int comboReset = 0;
    public int isCorrect = 0;
    public int isFalse = 0;
    public int comand = 0;
    public int max = 0;
    public int score_first = 0;
    public int create = 0;
    public int isdivide = 0;
    public int isScene = 0;
    public int isReset = 0;
    public int isBGM = 0;
    public int isScore = 0;
    public int isSound = 0;
    public int isCount = 0;

    public static DataManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataManager>();

                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(DataManager).Name;
                    instance = obj.AddComponent<DataManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
