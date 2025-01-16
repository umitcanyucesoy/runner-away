using System;
using UnityEngine;

namespace Chunks
{
    public class Chunk : MonoBehaviour
    {
        [Header("------ ELEMENTS ------")] 
        [SerializeField] private Vector3 size;

        public float GetLength() => size.z;
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(transform.position, size);
        }
        
    }
}