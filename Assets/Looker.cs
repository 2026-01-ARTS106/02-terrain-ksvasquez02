using UnityEngine;
using UnityEngine.InputSystem;

public class Looker : MonoBehaviour
{
    private InputAction ia_look;

    [SerializeField]
    private float lookSpeed = 180;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ia_look = InputSystem.actions.FindAction("Look");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = ia_look.ReadValue<Vector2>();
        Vector2 rotate = new Vector2(-dir.y, dir.x) * lookSpeed * Time.deltaTime;
        transform.Rotate(rotate);
    }
}
