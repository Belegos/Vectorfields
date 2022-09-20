using System;
using UnityEngine;


namespace Gridfield
{
    public class NodeGrid : MonoBehaviour
    {
        public Node[,] Nodes => nodearray;
        private Node[,] nodearray;
        [SerializeField] public bool showGizmos;
        [SerializeField] public Vector2Int size;
        [SerializeField] private Transform DEBUG;
        public void Init()
        {
            nodearray  = new Node[size.x,size.y];
            for (int x = 0; x < size.x; x++)
            {
                for(int y = 0; y < size.y; y++)
                {
                    //todo isStatic setzen wenn Node am Rand des Grids befindet
                    Vector2Int gridpos = new Vector2Int(x,y);
                    Vector3 worldpos = transform.position + new Vector3(x+0.5f,0,y+0.5f);
                    nodearray[x,y] = new Node(gridpos,worldpos);
                }
            }
        }
        private void OnDrawGizmos()
        {
            if (showGizmos)
            {
                if (nodearray is not null)
                {
                    foreach (var node in nodearray)
                    {
                        Gizmos.color = Color.blue;
                        Gizmos.DrawWireCube(node.WorldPosition, Vector3.one*0.9f);
                        Gizmos.color = Color.red;
                        Gizmos.DrawLine(node.WorldPosition, node.WorldPosition + node.Direction); 
                    }
                }
            }
        }

        private void Update()
        {
            Node tmp = null;
            GetNodeFromWorld(out tmp, DEBUG.position);
            //Debug.Log(tmp.GridPosition);
        }

        public bool GetNodeFromWorld(out Node _node, Vector3 WorldPosition)
        {
            WorldPosition = transform.InverseTransformPoint(WorldPosition); //WorldPosition in GridSpace
            if(WorldPosition.x >= 0 && WorldPosition.x < size.x && WorldPosition.z >= 0 && WorldPosition.z < size.y)
            {
                _node = nodearray[(int)WorldPosition.x, (int)WorldPosition.z];
                return true;
            }
            _node = null;
            return false;
        }
    }
}