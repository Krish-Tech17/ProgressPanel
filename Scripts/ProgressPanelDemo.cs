using UnityEngine;

public class ProgressPanelDemo : MonoBehaviour
{
    public GenericProgressConnector connector;
    public int demoTotalSteps = 5;
    private int current = 0;

    void Start() => connector.InitializePanel(demoTotalSteps);

    public void Next()
    {
        if (current < demoTotalSteps) current++;
        connector.NotifyStepCompleted(current);
    }

    public void Prev()
    {
        if (current > 0) current--;
        connector.NotifyStepCompleted(current);
    }

    public void ResetDemo()
    {
        current = 0;
        connector.InitializePanel(demoTotalSteps);
    }
}
