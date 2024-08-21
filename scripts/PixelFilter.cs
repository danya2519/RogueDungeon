using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelFilter : MonoBehaviour
{
    private Camera Cam;
    [SerializeField] private RenderTexture texture;
    void Start()
    {
        Cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        Cam.targetTexture = texture;
    }

    private void OnDestroy()
    {
        Cam.targetTexture = null;
    }
}
