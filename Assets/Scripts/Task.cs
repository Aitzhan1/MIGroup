using UnityEngine;

public class Task : MonoBehaviour
{
   protected bool TaskResult;
   [SerializeField] protected string TaskName, FailedText;
   [SerializeField] protected UIPanel UIPanel;
   public virtual void ActivateTask()
   {
      
   }

   protected virtual void ResetTask()
   {
      
   }

   protected virtual void NextTask()
   {
      
   }

   protected virtual void FailedTask()
   {
      UIPanel.FailedText(FailedText);
   }
}