using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public string targetTag = "";
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerExit;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (string.IsNullOrEmpty(targetTag) || collider.CompareTag(targetTag))
        {
            onTriggerEnter.Invoke();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (string.IsNullOrEmpty(targetTag) || collider.CompareTag(targetTag))
        {
            onTriggerExit.Invoke();
        }
    }
}
