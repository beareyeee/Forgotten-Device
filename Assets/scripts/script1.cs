using System.Collections;
using UnityEngine;

public class script1 : MonoBehaviour
{
    [SerializeField] private GameObject TV;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            TV.transform.GetChild(0).gameObject.SetActive(true);
            StartCoroutine(cd());
        }
    }

    private IEnumerator cd()
    {
        text.Instance.typeText("Use CTRL to interact with TV");
        yield return new WaitForSeconds(3f);
        text.Instance.typeText("");
        Destroy(this);
    }
}
