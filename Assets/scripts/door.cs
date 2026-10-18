using UnityEngine;
using DG.Tweening;

public class door : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject doorObj;
    public void Interact()
    {
        openTheDoor();
    }

    public void openTheDoor()
    {
        doorObj.transform.DOMove(new Vector3(transform.position.x, 20f, transform.position.z), 5f);
    }
}
