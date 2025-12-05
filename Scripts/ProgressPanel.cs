using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressPanel : MonoBehaviour
{
    [Header("UI References")]
    public Image progressFill;
    public TMP_Text percentageText;

    private int totalSteps = 0;
    private int completedSteps = 0;

    public void Initialize(int stepCount)
    {
        totalSteps = stepCount;
        completedSteps = 0;
        UpdateUI();
        Show();
    }

    public void UpdateProgress(int stepsCompleted)
    {
        completedSteps = Mathf.Clamp(stepsCompleted, 0, totalSteps);
        UpdateUI();
    }

    private void UpdateUI()
    {
        float progress = totalSteps > 0 ? (float)completedSteps / totalSteps : 0f;

        // Update fill
        progressFill.fillAmount = progress;

        // Update text
        percentageText.text = Mathf.RoundToInt(progress * 100) + "%";
    }

    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);
}
