using System.Collections;
using TMPro;
using UnityEngine;

public class text : MonoBehaviour
{
    public static text Instance;

    [SerializeField] private TextMeshProUGUI caption;

    [SerializeField] private AudioSource source;

    [SerializeField] private AudioClip clip;

    public void Initiate()
    {
        Instance = this;
    }

    public void typeText(string textToType)
    {
        StartCoroutine(textCoroutine(textToType));
    }

    private IEnumerator textCoroutine(string textToType)
    {
        source.PlayOneShot(clip);
        caption.maxVisibleCharacters = 0;
        caption.text = textToType;
        for (int i = 0; i < textToType.Length; i++) 
        {
            caption.maxVisibleCharacters = i + 1;
            yield return new WaitForSeconds(0.05f);
        }
        source.Stop();
    }
}
