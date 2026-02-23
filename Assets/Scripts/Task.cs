using System;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
   protected bool TaskResult;
   [SerializeField] protected string TaskName, FailedText;
   [SerializeField] protected UIPanel UIPanel;
   [SerializeField] protected List<InteractableGrabObjectSettings> InteractableGrabObjects;
   public Action OnNextTask;

   public virtual void ActivateTask()
   {
      
   }

   public virtual void ResetTask()
   {
      
   }

   protected virtual void NextTask()
   {
      OnNextTask?.Invoke();
   }

   protected void FailedTask()
   {
      UIPanel.SetText(FailedText);
   }

   protected void CongratulateTask()
   {
      UIPanel.SetText("Победа!");
   }
   protected void ForEachGrab(Action<InteractableGrabObjectSettings> action)
   {
      foreach (var grab in InteractableGrabObjects)
      {
         action?.Invoke(grab);
      }
   }
}