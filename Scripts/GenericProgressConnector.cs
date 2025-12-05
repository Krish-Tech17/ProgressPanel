using UnityEngine;
using UnityEngine.Events;

[System.Serializable] public class IntEvent : UnityEvent<int> {}

public class GenericProgressConnector : MonoBehaviour
{
    public ProgressPanel progressPanel;
    public IntEvent OnInitialize;
    public IntEvent OnProgressUpdate;

    private void Awake()
    {
        if (OnInitialize == null) OnInitialize = new IntEvent();
        if (OnProgressUpdate == null) OnProgressUpdate = new IntEvent();

        // Default binding to progress panel
        OnInitialize.AddListener((t) => progressPanel?.Initialize(t));
        OnProgressUpdate.AddListener((c) => progressPanel?.UpdateProgress(c));
    }

    public void InitializePanel(int totalSteps) => OnInitialize.Invoke(totalSteps);
    public void NotifyStepCompleted(int completedSteps) => OnProgressUpdate.Invoke(completedSteps);
}
