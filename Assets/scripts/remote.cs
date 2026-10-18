using DG.Tweening;
using UnityEngine;

public class remote : MonoBehaviour, IInteractable
{
    [SerializeField] private TV tv;

    public AudioClip clip;
    public void Interact()
    {
        tv.remoted = true;
        soundManager.Instance.playSound(clip, cameraManager.Instance.transform.position);
        Destroy(tv.boxCollider);
        tv.transform.GetChild(3).gameObject.SetActive(false); 
        tv.transform.GetChild(4).gameObject.SetActive(false);
        tv.gameObject.layer = 0;
        gameObject.layer = 0;
        GetComponent<Outline>().enabled = false;
    }
}
