using System;
using System.Collections.Generic;
using Unity.VRTemplate;
using UnityEngine;

public class GasTask : Task
{
    [SerializeField] private List<InteractableKnobSettings> GasKnobs;
    [SerializeField] private List<Burner> Burners;

    public override void ActivateTask()
    {
        base.ActivateTask();
        UIPanel.StartTask(TaskName, CheckTask);
        ForEachGrab(k=>k.ActivateGrab());
        ForEachKnob(k => k.ActivateKnob());
        Burners.ForEach(b => b.ActivateCollider(true));
    }

    private void CheckTask()
    {
        foreach (var burner in Burners)
        {
            if (burner.GasActived)
            {
                ForEachGrab(k=>k.DeactivateGrab());
                ForEachKnob(k => k.DeactivateKnob());
                Burners.ForEach(b => b.ActivateCollider(false));
                TaskResult = true;
                UIPanel.RemoveListener();
                NextTask();
                return;
            }
        }
        FailedTask();
    }

    public override void ResetTask()
    {
        base.ResetTask();
        ForEachKnob(k => k.ResetKnob());
        ForEachGrab(k=>k.ResetGrab());
        Burners.ForEach(b => b.GasActived=false);
    }

    protected override void NextTask()
    {
        ForEachKnob(k => k.DeactivateKnob());
        ForEachGrab(k=>k.DeactivateGrab());
        Burners.ForEach(b => b.ActivateCollider(false));
        base.NextTask();
    }

    private void ForEachKnob(Action<InteractableKnobSettings> action)
    {
        foreach (var knob in GasKnobs)
        {
            action?.Invoke(knob);
        }
    }
   
}