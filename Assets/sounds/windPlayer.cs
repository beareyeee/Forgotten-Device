using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windPlayer : MonoBehaviour
{
    public void playClip(AudioClip clip, int delay)
    {
        StartCoroutine(clipCoroutine(clip, delay));
    }
    private IEnumerator clipCoroutine(AudioClip clip, int delay)
    {
        while (true)
        {
            GetComponent<AudioSource>().PlayOneShot(clip);
            yield return new WaitForSeconds(clip.length - delay); 
        }
    }
}
