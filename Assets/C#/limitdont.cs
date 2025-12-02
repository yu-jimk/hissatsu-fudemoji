using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limitdont : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        BGMManager.Instance.PlayBGM3();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
