using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] UIManager uiManager;
    
    bool isStarted = false;
    float elapsedTime = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (isStarted)
        {
            elapsedTime += Time.deltaTime;
            uiManager.UpdateTimerUi(elapsedTime);
        }
    }

    public void StartTimer()
    {
        isStarted = true;
    }
}