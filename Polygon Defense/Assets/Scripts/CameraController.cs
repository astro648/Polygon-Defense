using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float panSpeed = 30f;

    void Update()
    {

        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward);
        }

    }

}
