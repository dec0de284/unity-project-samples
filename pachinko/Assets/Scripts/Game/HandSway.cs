using UnityEngine;

public class HandSway : MonoBehaviour
{
    [Header("Initialization")]
    Rigidbody2D thisRigidBody;

    [Header("Sway")]
    [SerializeField] bool isSwaying = true;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float boundX = 6f;
    [SerializeField] bool isSwayingRight = true;

    void Awake()
    {
        thisRigidBody = GetComponent<Rigidbody2D>();
        thisRigidBody.gravityScale = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isSwaying)
        {
            if (isSwayingRight)
            {
                SwayRight();
            }
            else
            {
                SwayLeft();
            }
            if (transform.position.x <= -boundX)
            {
                isSwayingRight = true;
            }
            else if (transform.position.x >= boundX)
            {
                isSwayingRight = false;
            }
        }
        else
        {
            thisRigidBody.gravityScale = 1;
        }
    }

    void SwayRight()
    {
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
    }
    void SwayLeft()
    {
        transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
    }
    public void TurnOffSway()
    {
        if (!PauseButton.gamePaused)
        {
            isSwaying = false;
        }
    }
}
