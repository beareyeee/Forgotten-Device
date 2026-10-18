using System.Collections;
using UnityEngine;
using Cysharp.Threading.Tasks; 

public class controller : MonoBehaviour
{
    public Vector3 vibrationDirection;

    private Rigidbody rb;

    [SerializeField] private LayerMask floorLayer;

    public bool canMove = false;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(VibrateCooldown());
        StartCoroutine(vibCountCD());
    }

    private IEnumerator vibCountCD()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            if (vibrationCount == 2)
            {
                vibrationCount = Mathf.Clamp(vibrationCount - 1, 0, 2);
            }
        }
    }

    public void Initiate()
    {
        Inputs.Instance.Vibrate += OnVibrate;
        Inputs.Instance.Move += OnMove;
    }

    public void OnDisable()
    {
        Inputs.Instance.Vibrate -= OnVibrate;
        Inputs.Instance.Move -= OnMove;
    }

    public int vibrationCount = 0;

    private Vector3 tempPos;
    public void Vibrate() 
    {
        if (canMove)
        {
            if (vibrationCount < 2)
            {
                tempPos = transform.position;
                rb.linearVelocity = Vector3.zero;
                rb.AddForce(vibrationDirection * 5f, ForceMode.Impulse);
                soundManager.Instance.playVibration(transform.position);
                grounded = false;
            }
            vibrationCount = Mathf.Clamp(vibrationCount + 1, 0, 2);
        } 
    }

    private bool grounded = false;
    private IEnumerator VibrateCooldown()
    {
        while (true)
        {
            if (Physics.Raycast(transform.position, -Vector3.up, 3f, floorLayer)) 
            {
                vibrationCount = 0;
                //if (!grounded)
                //{
                //    vibrationDirection = Vector3.zero;
                //    grounded = true;
                //}
            }
            yield return new WaitForSeconds(0.1f); 
        }
    }

    public void OnVibrate()
    { 
        if (vibrationDirection == Vector3.zero)
        {
            vibrationDirection = new Vector3(vibrationDirection.x, 1f, vibrationDirection.z);
        }
        else
        {
            vibrationDirection = new Vector3(vibrationDirection.x, Mathf.Clamp(vibrationDirection.y + 0.5f, 0f, 1f), vibrationDirection.z);
        }
        Vibrate();
    }

    public void OnMove(Vector3 vibDir)
    {
        vibrationDirection = (vibDir.x * Vector3.ProjectOnPlane(cameraManager.Instance.transform.right, Vector3.up).normalized + vibDir.z * Vector3.ProjectOnPlane(cameraManager.Instance.transform.forward, Vector3.up).normalized);
    }

    public void Update()
    {
        if (transform.position.y < -0.5f)
        {
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        }
    }
}
