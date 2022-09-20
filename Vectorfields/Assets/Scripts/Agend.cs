using System.Collections;
using System.Collections.Generic;
using Gridfield;
using UnityEngine;

namespace Vectorfield
{
    public class Agend : MonoBehaviour
    {
        public Node node = null;

        // Update is called once per frame
        void Update()
        {
            if (GameManager.Instance.Grid.GetNodeFromWorld(out node, transform.position))
            {
                transform.position += node.Direction * Time.deltaTime;
            }
        }
    }
}