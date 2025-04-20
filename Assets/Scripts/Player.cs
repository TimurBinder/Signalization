using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Signalization>(out var signalization))
            signalization.Play();
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<Signalization>(out var signalization))
            signalization.Stop(); 
    }
}
