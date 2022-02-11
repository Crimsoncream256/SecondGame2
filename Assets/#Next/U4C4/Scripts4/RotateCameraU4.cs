using UnityEngine;
public class RotateCameraU4 : MonoBehaviour
{
    public float rotationSpeed = 120;
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}