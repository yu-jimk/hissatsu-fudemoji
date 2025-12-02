using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brushHitBox : MonoBehaviour
{

    public bool IsTouch = false;
    public Vector2 BrushPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerStay(Collider other)
    {
        IsTouch = true;
        float canvasSize = other.gameObject.transform.localScale.x;
        BrushPos.x = transform.position.x;
        BrushPos.y = transform.position.y;
    }

     void OnTriggerExit(Collider other)
    {
        IsTouch = false;
    }

}
