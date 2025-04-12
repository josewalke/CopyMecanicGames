using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;           // El objeto que la cámara sigue (ej: la cabeza o un "camera pivot" en Kyle)
    public Vector3 offset = new Vector3(0, 2, -4); // Posición relativa a target
    public float rotationSpeed = 5f;   // Sensibilidad de rotación
    public float smoothSpeed = 10f;    // Suavidad de movimiento

    float yaw; // Rotación horizontal
    float pitch; // Rotación vertical

    void LateUpdate()
    {
        if (target == null) return;

        // Rotación con el mouse
        yaw += Input.GetAxis("Mouse X") * rotationSpeed;
        pitch -= Input.GetAxis("Mouse Y") * rotationSpeed;
        pitch = Mathf.Clamp(pitch, -30f, 60f); // Limita la rotación vertical

        // Calcula rotación y posición
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 desiredPosition = target.position + rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
        transform.LookAt(target);
    }
}
