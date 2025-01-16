using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSystem : MonoBehaviour
{
   [Header("----- ELEMENTS ------")]
   [SerializeField] private Transform runnersParent;
   
   [Header("------ SETTINGS -----")] 
   [SerializeField] private float radius;
   [SerializeField] private float angle;


   private void Update()
   {
      PlaceRunners();
   }

   private void PlaceRunners()
   {
      for (int i = 0; i < runnersParent.childCount; i++)
      {
         Vector3 childLocalPosition = GetRunnerLocalPosition(i);
         runnersParent.GetChild(i).localPosition = childLocalPosition;
      }
   }

   private Vector3 GetRunnerLocalPosition(int index)
   {
      float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * angle * index);
      float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * angle * index);
      
      return new Vector3(x, 0, z);
   }
   
   public float GetCrowdRadius() => radius * Mathf.Sqrt(runnersParent.childCount);
}
