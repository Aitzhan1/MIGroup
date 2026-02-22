using System;
using System.Collections.Generic;
using Unity.VRTemplate;
using UnityEngine;

public class Gas : Task
{
    [SerializeField] private List<InteractableKnobSettings> GasKnobs;
    [SerializeField] private List<InteractableGrabObjectSettings> InteractableGrabObjects;
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
        if (TaskResult)
        {
            FailedTask();
        }
    }

    protected override void ResetTask()
    {
        base.ResetTask();
        ForEachKnob(k => k.ResetKnob());
        ForEachGrab(k=>k.ResetGrab());
        Burners.ForEach(b => b.IsFireEntered=false);
    }

    protected override void NextTask()
    {
        base.NextTask();
        ForEachKnob(k => k.DeactivateKnob());
        ForEachGrab(k=>k.DeactivateGrab());
        Burners.ForEach(b => b.ActivateCollider(false));
    }

    private void ForEachKnob(Action<InteractableKnobSettings> action)
    {
        foreach (var knob in GasKnobs)
        {
            action?.Invoke(knob);
        }
    }
    private void ForEachGrab(Action<InteractableGrabObjectSettings> action)
    {
        foreach (var grab in InteractableGrabObjects)
        {
            action?.Invoke(grab);
        }
    }
}