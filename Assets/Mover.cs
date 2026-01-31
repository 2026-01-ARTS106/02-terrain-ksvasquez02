using UnityEngine;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{
    private InputAction ia_move;
    private InputAction ia_jump;
    private InputAction ia_sprint;

    private Vector3 dir;
    private Vector3 vel;

    [SerializeField]
    private float speed = 50;

    [SerializeField]
    private Looker looker;


    private void Awake()
    {
        looker = looker != null ? looker : gameObject.GetComponentInChildren<Looker>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ia_move = InputSystem.actions.FindAction("Move");
        ia_jump = InputSystem.actions.FindAction("Jump");
        ia_sprint = InputSystem.actions.FindAction("Sprint");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        Vector2 d_hori = ia_move.ReadValue<Vector2>();
        float d_up = ia_jump.IsPressed() ? 1 : 0;
        float d_down = ia_sprint.IsPressed() ? 1 : 0;

        dir = (new Vector3(d_hori.x, d_up - d_down, d_hori.y)).normalized;

        Quaternion faceRotate = Quaternion.AngleAxis(looker.LookDirection.y + 180, Vector3.up);
        dir = faceRotate * dir;

        vel = speed * Time.deltaTime * dir;
        pos += vel;

        transform.position = pos;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + vel.normalized);
    }
}
