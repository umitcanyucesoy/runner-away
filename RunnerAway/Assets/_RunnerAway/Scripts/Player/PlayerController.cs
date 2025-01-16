using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [Header("--------- Player Elements ---------")]
    private CrowdSystem _crowdSystem;
    
    [Header("--------- Player Settings ---------")] 
    [SerializeField] private float moveSpeed;
    [SerializeField] private int roadWidth = 10;

    [Header("---------- Control Settings---------")]
    [SerializeField] private float dragSpeed;
    private Vector3 _clickedScreenPosition;
    private Vector3 _clickedPlayerPosition;

    private void Awake()
    {
        _crowdSystem = GetComponent<CrowdSystem>();
    }

    private void Update()
    {
        MoveForward();
        DragControl();
    }

    private void MoveForward()
    {
        transform.position += transform.forward * (moveSpeed * Time.deltaTime);
    }

    private void DragControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _clickedScreenPosition = Input.mousePosition;
            _clickedPlayerPosition = transform.position;
        }
        else if (Input.GetMouseButton(0))
        {
            float xScreenDifference = Input.mousePosition.x - _clickedScreenPosition.x;
            
            xScreenDifference /= Screen.width;
            xScreenDifference *= dragSpeed;
            
            Vector3 position = transform.position;
            position.x = _clickedPlayerPosition.x + xScreenDifference;
            
            position.x = Mathf.Clamp(position.x, (-roadWidth / 2 + _crowdSystem.GetCrowdRadius()),
                (roadWidth / 2 - _crowdSystem.GetCrowdRadius()));
            
            
            transform.position = position;
        }
    }
}
