using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMdont : MonoBehaviour
{
    public Vector3 objectPosition;

    public static BGMdont instance;

    // Start is called before the first frame update
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
