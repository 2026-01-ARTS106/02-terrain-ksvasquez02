using UnityEngine;
using UnityEngine.InputSystem;

public class Looker : MonoBehaviour
{
    private InputAction ia_look;

    [SerializeField]
    private float lookSpeed = 180;

    public Vector3 LookDirection { get; set; }

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
        Vector2 rotate = dir * lookSpeed * Time.deltaTime;
        angles += new Vector3(rotate.y, rotate.x, 0);
        LookDirection = angles;
        transform.eulerAngles = angles;
    }
}
