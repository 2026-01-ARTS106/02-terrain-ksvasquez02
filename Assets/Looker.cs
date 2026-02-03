using UnityEngine;
using UnityEngine.InputSystem;

public class Looker : MonoBehaviour
{
    private InputAction ia_look;
    private const float LOCK_ANGLE = 2.5f;

    [SerializeField]
    private float lookSpeed = 180;

    private Vector3 lookDirection = Vector3.zero;

    public Vector3 LookDirection { get { return lookDirection; } }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ia_look = InputSystem.actions.FindAction("Look");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 angles = transform.eulerAngles;
        Vector2 dir = ia_look.ReadValue<Vector2>();
        Vector2 rotate = lookSpeed * Time.deltaTime * dir;
        angles += new Vector3(rotate.y, rotate.x, 0);
        lookDirection = angles;

        if (lookDirection.x < 180) lookDirection.x = Mathf.Min(90 - LOCK_ANGLE, lookDirection.x);
        else if (lookDirection.x > 180) lookDirection.x = Mathf.Max(270 + LOCK_ANGLE, lookDirection.x);
        else Debug.LogWarning($"Look angle out of bounds: {lookDirection.x}");

        transform.eulerAngles = lookDirection;
    }
}
