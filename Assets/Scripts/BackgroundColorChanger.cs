using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorChanger : MonoBehaviour
{
    [SerializeField] private Color[] colors;
    [SerializeField] private float colorChangeSpeed;
    [SerializeField] private float time;

    private Camera cam;
    private float currentTime;
    private int colorIndex;

    private void Awake()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        ChangeColor();
        ChangeColorTime();
    }
    private void ChangeColor()
    {
        cam.backgroundColor = Color.Lerp(cam.backgroundColor, colors[colorIndex], colorChangeSpeed * Time.deltaTime);
    }
    private void ChangeColorTime()
    {
        if(currentTime <= 0)
        {
            colorIndex++;
            CheckColorIndex();
            currentTime = time;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }
    private void CheckColorIndex()
    {
        if(colorIndex >= colors.Length)
        {
            colorIndex = 0;
        }
    }

}
