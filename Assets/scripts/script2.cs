using System.Collections;
using UnityEngine;

public class script2 : MonoBehaviour
{
    [SerializeField] private GameObject end;

    [SerializeField] private AudioClip clip;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            Inputs.Instance.GetComponent<controller>().canMove = false;
            Inputs.Instance.GetComponent<scan>().enabled = false;
            soundManager.Instance.playSound(clip, cameraManager.Instance.transform.position);
            StartCoroutine(dialogue());
        }
    }

    private IEnumerator dialogue()
    {
        text.Instance.typeText("Looks like you spent all your energy helping others");
        yield return new WaitForSeconds(7f);
        text.Instance.typeText("Again");
        yield return new WaitForSeconds(6f);
        text.Instance.typeText("But what about you?");
        yield return new WaitForSeconds(6f);
        Inputs.Instance.GetComponent<Outline>().enabled = false;
        text.Instance.typeText("");
        end.SetActive(true);
    }
}
