using UnityEngine;

public class timecreate : MonoBehaviour
{
    public GameObject objectToDisplay;
    public float delay = 3f;

    private void Start()
    {
        Invoke("DisplayObject", delay);
    }

    void DisplayObject()
    {
        objectToDisplay.SetActive(true);
    }
}