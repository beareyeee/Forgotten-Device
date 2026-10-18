using UnityEngine;

public class cameraManager : MonoBehaviour
{
    public static cameraManager Instance;

    public void Initiate()
    {
        Instance = this;
    }

    public void changeCamera(Vector3 camPos, Quaternion camRot)
    {
        transform.position = camPos;
        transform.rotation = camRot;
    }
}
