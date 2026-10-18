using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class cameraPoint : MonoBehaviour
{
    [SerializeField] private Vector3 camPos;

    [SerializeField] private Vector3 camRot;
    public void OnTriggerStay(Collider collider) 
    {
        if (collider.gameObject.layer == 3)
        {
            if (cameraManager.Instance.transform.position != camPos && Inputs.Instance.cameraChangeTimer >= 1f)
            {
                cameraChange();
                Inputs.Instance.cameraChangeTimer = 0f; 
            }
        }
    }


    public void cameraChange()
    {
        cameraManager.Instance.changeCamera(camPos, Quaternion.Euler(camRot));
    }
}
