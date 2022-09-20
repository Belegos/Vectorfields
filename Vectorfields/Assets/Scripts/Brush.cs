using Gridfield;
using UnityEngine;

namespace Gridfield
{
    public enum BrushMode
    {
        DIRECT
    }
    public static class Brush 
    {
        public static void SetNodeDirection(float radius, Vector3 WorldPosition, Vector3 direction, BrushMode _mode)
        {
            foreach (var Node in GameManager.Instance.Grid.Nodes)
            {
                if (Vector3.Distance(Node.WorldPosition, WorldPosition) < radius)
                {
                    switch (_mode)
                    {
                        case BrushMode.DIRECT:
                            Node.Direction = direction;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}