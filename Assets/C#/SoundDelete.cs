using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDelete : MonoBehaviour
{
    public GameObject someGameObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (DataManager.Instance.isSound == 1)
        {
            DataManager.Instance.isSound = 0;
            Destroy(this.gameObject);
            Destroy(this.someGameObject);

        }
    }
}
