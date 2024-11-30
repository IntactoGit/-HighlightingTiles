using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class MouseTargetChangeColor : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    private Color _originalColor;
    [SerializeField] private LayerMask _layerMask;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _originalColor = _renderer.material.color;
        _layerMask = LayerMask.GetMask("LayerForRay");
    }

    private void Update()
    {
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 50f, _layerMask))
        {
            var hitObject = hitInfo.transform.GetComponent<Renderer>();
            hitObject.material.color = Color.magenta;
           
            if (_renderer != null && _renderer != hitObject)
            {
                _renderer.material.color = _originalColor;
            }

        }
        else
        {
            _renderer.material.color = _originalColor;
        }
    }
}
