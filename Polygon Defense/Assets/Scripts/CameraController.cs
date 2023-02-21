using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float panSpeed = 30f;

    void Update()
    {

        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World); // Time.deltaTime makes speed independent of framerate, Space.World makes it relative to the world coordinates so the movement is independent to the rotation of the camera
        }

    }

}
