using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1000f;
    [SerializeField] Rigidbody rb;
    [SerializeField] Animator animator;
    [SerializeField] GameObject gameScreen;
    [SerializeField] GameObject pauseScreen;

    private Plane groundPlane;

    private void Start()
    {
        groundPlane = new Plane(Vector3.up, Vector3.zero);
    }

    private void Update()
    {
        MovementControl();
        MouseRotation();
        PauseMenu();
    }

    private void MovementControl()
    {
        Vector3 velocity = Vector3.zero;
        velocity += (Vector3.forward * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal")) * moveSpeed;
        rb.velocity = velocity;
        if(velocity == Vector3.zero)
        {
            animator.SetBool("isMoving",false);
        }
        else
        {
            animator.SetBool("isMoving",true);
        }
    }

    private void MouseRotation()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float rayLenght;
        if (groundPlane.Raycast(cameraRay, out rayLenght))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLenght);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }

    private void PauseMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameScreen.activeSelf)
            {
                Time.timeScale = 0f;
                gameScreen.SetActive(false);
                pauseScreen.SetActive(true);
            }
            else if(pauseScreen.activeSelf)
            {
                Time.timeScale = 01f;
                gameScreen.SetActive(true);
                pauseScreen.SetActive(false);
            }
        }
    }
}
