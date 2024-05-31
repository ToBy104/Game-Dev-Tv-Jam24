using UnityEngine;

public class Player_Cam_ : MonoBehaviour
{
    public Vector2 turn;
    private float sensitivity_X = 5f;
    private float sensitivity_y = 5f;

    private Transform player;

    private void Awake() => player = transform.parent;
    //private void Start() => Cursor.lockState = CursorLockMode.Locked;
    private void Update() => FowlloMouse();
    public void FowlloMouse()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity_X;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity_y;

        //turn.x = Mathf.Clamp(turn.x, -60, 50);
        turn.y = Mathf.Clamp(turn.y, -45, 45);

        transform.rotation = Quaternion.Euler(-turn.y, turn.x, 0);
        player.rotation = Quaternion.Euler(0, turn.x, 0);
    }
}
