using System.Collections;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Inputs Inputs;

    [SerializeField] private cameraManager cameraManager;

    [SerializeField] private GameObject controller;

    [SerializeField] private soundManager soundManager;

    [SerializeField] private text text;

    [SerializeField] private windPlayer windPlayer;

    [SerializeField] private AudioClip wind;

    [SerializeField] private cameraPoint camPoint;

    public void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Inputs.Initiate();
        cameraManager.Initiate();
        soundManager.Initiate();
        text.Initiate();
        windPlayer.playClip(wind, 8);
        controller.GetComponent<controller>().Initiate();
        StartCoroutine(cor());
    }

    private IEnumerator cor()
    {
        yield return new WaitForSeconds(3f);
        text.typeText("Press any key to wake up");
        Inputs.AnyKey += OnAnyKey;
    }

    public void OnAnyKey()
    {
        text.Instance.typeText("Press Space to jump");
        Inputs.Vibrate += OnFirstVibrate;
        controller.GetComponent<controller>().gameObject.layer = 3;
        controller.GetComponent<scan>().enabled = true;
        controller.GetComponent<Outline>().enabled = true;
        controller.GetComponent<controller>().canMove = true;
        camPoint.cameraChange();
        Inputs.AnyKey -= OnAnyKey;
    }

    public void OnFirstVibrate()
    {
        text.Instance.typeText("Use WASD to choose direction");
        Inputs.Vibrate -= OnFirstVibrate; 
        StartCoroutine(textCD());
    }
    private IEnumerator textCD()
    {
        yield return new WaitForSeconds(3f);
        text.Instance.typeText("");
    }
}
