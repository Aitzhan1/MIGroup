using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class AnalyzerTask : Task
{
    [SerializeField] private List<Burner> Burners;
    [SerializeField] private AudioSource Source;
    [SerializeField] private AudioClip WrongSound;
    public override void ActivateTask()
    {
        base.ActivateTask();
        UIPanel.StartTask(TaskName, CheckTask);
        ForEachGrab(k=>k.ActivateGrab());
        Burners.ForEach(b => b.ActivateCollider(true));
        foreach (var burner in Burners)
        {
            burner.OnWrong += ErrorBurner;
        }
    }

    private void ErrorBurner(Burner  burner)
    {
        burner.InteractableKnob.ActivateKnob();
        Source.PlayOneShot(WrongSound);
    }

    private void CheckTask()
    {
        foreach (var burner in Burners)
        {
            if (burner.KnobValue > 0 && !burner.GasActived)
            {
                FailedTask();
                return;
            }
            burner.OnWrong -= ErrorBurner;
        }
        CongratulateTask();
    }
}
