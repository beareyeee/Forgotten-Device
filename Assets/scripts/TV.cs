using System.Collections;
using DG.Tweening;
using UnityEngine;

public class TV : MonoBehaviour, IInteractable
{
    public GameObject boxCollider;
    [SerializeField] private GameObject remote;
    public bool remoted = false;
    public int i = 1; 
    public void Interact()
    {
        for (int j = 0; j < 3; j++)
        {
            transform.GetChild(j).gameObject.SetActive(false);
        }
        if (i < 4)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
        i++;
    }
}
