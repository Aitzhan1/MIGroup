using System;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
   [SerializeField] private List<Task> Tasks;

   private void Start()
   {
      Tasks[0].ActivateTask();
   }
}
