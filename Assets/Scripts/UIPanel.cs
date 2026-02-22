using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    [SerializeField] private Button CheckTaskButton;
    [SerializeField] private TMP_Text TaskName;

    public void StartTask(string taskName, UnityAction onCheckTaskClick)
    {
        TaskName.text = taskName;
        CheckTaskButton.onClick.AddListener(onCheckTaskClick);
    }

    public void FailedText(string failedText)
    {
        TaskName.text = failedText;
    }
}