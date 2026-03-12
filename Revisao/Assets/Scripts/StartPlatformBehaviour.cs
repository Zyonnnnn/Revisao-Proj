using UnityEngine;

public class StartPlatformBehaviour : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("cumessou");
            GameManager.Instance.StartTimer();
        }
    }
}