using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dont : MonoBehaviour
{
    public Vector3 objectPosition;

    public static dont instance;

    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
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
