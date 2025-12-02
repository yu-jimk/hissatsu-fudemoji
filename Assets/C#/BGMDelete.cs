using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMDelete : MonoBehaviour
{
    public GameObject someGameObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DataManager.Instance.isBGM == 4)
        {
            DataManager.Instance.isBGM = 0;
            Destroy(this.gameObject);
            Destroy(this.someGameObject);

        }
    }
}
