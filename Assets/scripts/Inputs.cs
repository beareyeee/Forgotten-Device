using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Inputs : MonoBehaviour
{
    public static Inputs Instance;

    private InputActions InputActions;

    public Vibrate Vibrate;

    public Move Move;

    public Scan Scan;

    public AnyKey AnyKey;

    public void Initiate()
    {
        Instance = this;
    }


    public void OnEnable()
    {
        InputActions = new InputActions();
        InputActions.Player.Enable();
        InputActions.Player.Vibrate.performed += OnVibrate;
        InputActions.Player.Move.performed += OnMove;
        InputActions.Player.Move.canceled += OnMoveCanceled;
        InputActions.Player.Scan.performed += OnScan;
        InputActions.Player.AnyKey.performed += OnAnyKey;
    }

    public void OnDisable()
    {
        InputActions.Player.Disable();
        InputActions.Player.Vibrate.performed -= OnVibrate;
        InputActions.Player.Move.performed -= OnMove;
        InputActions.Player.Move.canceled -= OnMoveCanceled;
        InputActions.Player.Scan.performed -= OnScan;
        InputActions.Player.AnyKey.performed -= OnAnyKey;
    }

    private int i = 0;
    private void OnVibrate(InputAction.CallbackContext context)
    {
        if (vibrateTimer >= 0.3f)
        {
            Vibrate?.Invoke();
            vibrateTimer = 0;
        }
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Move?.Invoke(new Vector3(context.ReadValue<Vector2>().x, 0, context.ReadValue<Vector2>().y));
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        Move?.Invoke(Vector3.zero);
    }

    private float vibrateTimer = 0f;
    private float scanTimer = 0f;
    public float cameraChangeTimer = 0f;

    public void Update()
    {
        vibrateTimer += Time.deltaTime;
        scanTimer += Time.deltaTime;
        cameraChangeTimer += Time.deltaTime; 
    }

    public void OnScan(InputAction.CallbackContext context)
    {
        if (scanTimer >= 1.5f)
        {
            Scan?.Invoke();
            scanTimer = 0;
        }
    }

    public void OnAnyKey(InputAction.CallbackContext context)
    {
        AnyKey?.Invoke();
    }
}
public delegate void Vibrate();
public delegate void Move(Vector3 vibrateDirection);
public delegate void Scan();
public delegate void AnyKey();