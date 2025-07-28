using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public string message; // Message to display when interacted with

    public UnityEvent onInteraction; // Event to trigger when interacted with

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Interact()
    {
        onInteraction.Invoke(); // Invoke the interaction event
    }
}
