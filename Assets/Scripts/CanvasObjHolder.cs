using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasObjHolder : MonoBehaviour
{
    //FPS camera is assigned to canvas for better Input
    [SerializeField] Camera _mainCamera;
    [SerializeField] Canvas _canvas;
    void Start()
    {
        if (_mainCamera != null)
        {
            _mainCamera = FindObjectOfType<CharacterController>().GetComponentInChildren<Camera>();
            _canvas = GetComponent<Canvas>();
            _canvas.worldCamera = _mainCamera;
        }

    }
}
