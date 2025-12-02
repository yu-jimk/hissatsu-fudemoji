using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time : MonoBehaviour
{

    public float delay = 3f;

    private void Start()
    {
        Invoke("DestroyGameObject", delay);
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
