using System.Collections;
using DG.Tweening;
using UnityEngine;

public class radio : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject bigPhone;
    [SerializeField] private GameObject antenna;

    public AudioClip clip;

    public void Start()
    {
        GetComponent<windPlayer>().playClip(clip, 3);
    }

    private int i = 0;
    public void Interact()
    {
        switch (i)
        {
            case 0:
                text.Instance.typeText("Hey");
                break;
            case 1:
                text.Instance.typeText("I lost part of myself");
                break;
            case 2:
                text.Instance.typeText("Can you help me?");
                break;
            case 3:
                text.Instance.typeText("I need my antenna back");
                antenna.layer = 6;
                break;
            case 4:
                text.Instance.typeText("Please");
                StartCoroutine(cd());
                break;
        }
        if (!antenna.activeSelf)
        {
            bigPhone.transform.DOMoveY(50, 2f);
            text.Instance.typeText("Thank you, the way is cleared");
            StartCoroutine(cd());
            transform.GetChild(0).gameObject.SetActive(true);
        }
        i++; 
    }

    private IEnumerator cd()
    {
        yield return new WaitForSeconds(4);
        text.Instance.typeText("");
    }
}
