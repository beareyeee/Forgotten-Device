using UnityEngine;

public class antenna : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        gameObject.SetActive(false);
    }
}
