using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gridfield
{
    public class Node
    {
        public Vector3 Direction
        {
            get
            {
                return direction;
            }
            set
            {
                if (!isStatic) direction = value;
            }
        }
        public Vector2Int GridPosition => gridpos;
        public Vector3 WorldPosition => worldpos;

        private Vector2Int gridpos;
        private Vector3 worldpos;
        private Vector3 direction;
        private bool isStatic;

        public Node(Vector2Int gridpos, Vector3 worldpos, bool isStatic = false)
        {
            this.gridpos = gridpos;
            this.worldpos = worldpos;
            this.direction = direction;
            this.isStatic = isStatic;
        }
    }
}