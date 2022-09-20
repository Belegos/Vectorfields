using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gridfield
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public NodeGrid Grid => grid;

        [SerializeField]private NodeGrid grid;
        private RaycastHit hit;
        [SerializeField] LayerMask layerMask;
        [SerializeField] private Vector3 BrushDirection;
        private Vector3 mousePos;
        
        private void Awake()
        {
            Instance = this;
            grid.Init();
        }
        private void Update()
        {
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, layerMask))
            {
                mousePos = hit.point;
            }
            if (Input.GetKey(KeyCode.A) && mousePos != null)
            {
                Gridfield.Brush.SetNodeDirection(1f, mousePos, BrushDirection, BrushMode.DIRECT);
            }
        }
    }
}