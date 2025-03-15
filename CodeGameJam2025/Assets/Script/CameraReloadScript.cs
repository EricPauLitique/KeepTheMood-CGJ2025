using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReloadScript : MonoBehaviour
{
    public Camera mainCamera;
    void Start()
    {
        DontDestroyOnLoad(mainCamera.gameObject);
    }
}
