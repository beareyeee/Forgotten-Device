using UnityEngine;
using Cysharp.Threading.Tasks;
using NUnit.Framework;
using System.Collections.Generic;

public class soundManager : MonoBehaviour
{
    public static soundManager Instance;

    private AudioSource source;

    [SerializeField] private List<AudioClip> vibrationSounds;

    public void Initiate()
    {
        Instance = this;
        source = GetComponent<AudioSource>();
    }

    public void playSound(AudioClip sound, Vector3 soundPos)
    {
        playing(sound, soundPos).Forget();
    }

    private async UniTask playing(AudioClip sound, Vector3 soundPos)
    {
        AudioSource currentSource = Instantiate(source);
        currentSource.transform.position = soundPos;
        currentSource.PlayOneShot(sound);
        await UniTask.Delay((int)(sound.length * 1000));
        Destroy(currentSource);
    }

    public void playVibration(Vector3 pos)
    {
        playSound(vibrationSounds[Random.Range(0, vibrationSounds.Count)], pos);
    }
}
