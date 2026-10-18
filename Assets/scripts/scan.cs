using System.Collections;
using DG.Tweening;
using NUnit.Framework.Constraints;
using UnityEngine;

public class scan : MonoBehaviour
{
    [SerializeField] private GameObject scanner;

    [SerializeField] private LayerMask interactableLayer;

    [SerializeField] private AudioClip scanClip;
    public void OnEnable()
    {
        Inputs.Instance.Scan += OnScan; 
    }

    public void OnDisable()
    {
        Inputs.Instance.Scan -= OnScan;
    }

    public void OnScan()
    {
        StartCoroutine(scanCoroutine());
    }

    private IEnumerator scanCoroutine()
    {
        soundManager.Instance.playSound(scanClip, transform.position);
        scanner.transform.DOScale(scanner.transform.localScale * 1000f, 0.25f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.25f);
        scanner.transform.localScale = scanner.transform.localScale / 1000;
        Collider[] colliders = Physics.OverlapSphere(scanner.transform.position, 5f, interactableLayer);
        foreach (Collider col in colliders)
        {
            col.GetComponent<IInteractable>().Interact();
        }

    }
}
