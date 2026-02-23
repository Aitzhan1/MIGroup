using System;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
   [SerializeField] private List<Task> Tasks;
   private int _currentTaskIndex = 0;

   private void Start()
   {
      ActivateCurrentTask();
   }

   private void OnEnable()
   {
      foreach (var task in Tasks)
      {
         task.OnNextTask += CompleteCurrentTask;
      }
   }

   private void OnDisable()
   {
      foreach (var task in Tasks)
      {
         task.OnNextTask -= CompleteCurrentTask;
      }
   }

   private void ActivateCurrentTask()
   {
      Tasks[_currentTaskIndex].ActivateTask();
   }

   private void CompleteCurrentTask()
   {
      _currentTaskIndex++;

      if (_currentTaskIndex >= Tasks.Count)
      {
         Debug.Log("All tasks completed!");
         return;
      }

      ActivateCurrentTask();
   }

   public void RestartCurrentTask()
   {
      Tasks[_currentTaskIndex].ResetTask();
      Tasks[_currentTaskIndex].ActivateTask();
   }
}
