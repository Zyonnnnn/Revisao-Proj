using System.Globalization;
using TMPro;
using Unity.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    public void UpdateTimerUi(float newTime)
    {
        int minutes = (int)(newTime / 60);
        int seconds = (int)(newTime % 60);
        timeText.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
