using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSetting : MonoBehaviour
{
    private Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    public void EnableCanvas()
    {
        canvas.enabled = true;
    }

    public void DisableCanvas()
    {
        canvas.enabled = false;
    }
}
