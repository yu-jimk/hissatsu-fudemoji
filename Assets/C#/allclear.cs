using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allclear : MonoBehaviour
{
    public GameObject someGameObject1;
    public GameObject someGameObject2;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (DataManager.Instance.create == 1)
        {
            DataManager.Instance.create = 0;
            Destroy(this.gameObject);
            Destroy(this.someGameObject1);
            Destroy(this.someGameObject2);

        }
    }
}