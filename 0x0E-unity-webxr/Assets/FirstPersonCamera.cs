using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float sensitivity = 2.0f; // this is the mouse sensitivity

    private float mouseX, mouseY;

    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * sensitivity;
        mouseY -= Input.GetAxis("Mouse Y") * sensitivity;
        mouseY = Mathf.Clamp(mouseY, -90f, 90f); // this limits vertical rotation

        transform.eulerAngles = new Vector3(mouseY, mouseX, 0f);
    }
}