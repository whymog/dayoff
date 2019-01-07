using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;

    private float horizontal;
    private float vertical;
    private float moveLimiter = 0.7f;
    private bool canMove;
    private bool isMoving;
    
    public Sprite playerFaceUp;
    public Sprite playerFaceDown;
    public Sprite playerFaceLeft;
    public Sprite playerFaceRight;
    
    public float speed;

    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Ensure there's at least one sprite properly mapped before the scene runs
        if (spriteRenderer.sprite == null && playerFaceDown != null) {
            spriteRenderer.sprite = playerFaceDown;
        }

        canMove = false;
        isMoving = false;

        // Check for invalid or missing speed values
        if (speed < 0f) {
            Debug.LogError("[PLAYER] Player speed is not set correctly — it should be a positive value.");
        }

        StartCoroutine(PostStart());
    }

    private IEnumerator PostStart() {
        yield return null;
        canMove = !GameStateManager.isInteractMode;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical"); 

        // Check to see if interactMode has been enabled; if so, we should disable movement.
        if (canMove == GameStateManager.isInteractMode) {
            canMove = !GameStateManager.isInteractMode;
        }
    }

    void FixedUpdate()
    {
        // Debug.LogFormat("canMove is {0}", canMove);
        if (canMove == true) {
            if (horizontal != 0 || vertical != 0) {
                if (!isMoving) {
                    isMoving = true;

                    // Set direction of sprite
                    if (vertical > 0) {
                        spriteRenderer.sprite = playerFaceUp;
                    } else if (vertical < 0) {
                        spriteRenderer.sprite = playerFaceDown;
                    } else if (horizontal > 0) {
                        spriteRenderer.sprite = playerFaceRight;
                    } else if (horizontal < 0) {
                        spriteRenderer.sprite = playerFaceLeft;
                    }
                }
            
                // Make sure that if you're no longer diagonal we update the sprite direction

                if (vertical > 0 && horizontal == 0) {
                    spriteRenderer.sprite = playerFaceUp;
                } else if (vertical < 0 && horizontal == 0) {
                    spriteRenderer.sprite = playerFaceDown;
                } else if (horizontal > 0 && vertical == 0) {
                    spriteRenderer.sprite = playerFaceRight;
                } else if (horizontal < 0 && vertical == 0) {
                    spriteRenderer.sprite = playerFaceLeft;
                }
            } else {
                isMoving = false;
            }
            
            // Handle movement speed and direction
            if (horizontal != 0 && vertical != 0)
            {
                body.velocity = new Vector2((horizontal * speed) * moveLimiter, (vertical * speed) * moveLimiter);

            }
            else
            {
                body.velocity = new Vector2(horizontal * speed, vertical * speed);
            }
        } else {
            // Make sure no movement is happening when not possible (e.g., when in interact mode)
            body.velocity = new Vector2(0f, 0f);
        }
    }
}

