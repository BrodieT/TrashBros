using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //player ID to track which player is controlling this character
    public int PlayerID = 1;

    //Speed that the player moves at
    float MovementSpeed = 1.0f;
    //The force applied to the player jump
    float JumpForce = 42.5f;
    //Check for if the player is touching the ground
    public bool IsGrounded = false;
    //Movement direction indicated by the left analogue stick
    Vector3 MovementDirection = new Vector2();
    //Aim direction indicated by the right analogue stick
    Vector3 AimDirection = new Vector2();
    //The force applied to the trash when thrown
    float ThrowForce = 5.0f;
    //Reference to the picked up piece of trash
    public GameObject Trash;
    //Tracks the button state of the left trigger
    bool LeftTriggerDown = false;
    //Layer Mask to detect other players and trash
    public LayerMask ColsMask;
    //How frequently the impulse can be triggered
    public float ImpulseAttackSpeed = 0.05f;
    //Cooldown timer for the impulse
    float ImpulseCooldown = 0.0f;
    //Stores the previous trigger state of the left trigger
    float PreviousTriggerState = 0.0f;
    float Impulse = 75.0f;
    bool IsHolding = false;

    float fallvalue = 0.025f;
    float pFallValue = 0.8f;

    //audio variables

    public AudioClip jumpingAudio;
    public AudioClip impulseAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void HandleInput()
    {
        //Set the movement direction along the x-axis using the left analogue stick 
        MovementDirection = new Vector3(Input.GetAxisRaw("Player" + PlayerID + "LH"), 0.0f, 0.0f);

        
        //Set the aim direction using the right analogue stick
        AimDirection = new Vector3(Input.GetAxisRaw("Player" + PlayerID + "RH"), Input.GetAxisRaw("Player" + PlayerID + "RV"), 0.0f);

        if(Input.GetButtonDown("Player" + PlayerID + "RB") && ImpulseCooldown <= 0)
        {
            isPulse = true;
        }

        if (Input.GetAxisRaw("Player" + PlayerID + "LT") != 0)
        {
            LeftTriggerDown = true;
        }
        else if (Input.GetAxisRaw("Player" + PlayerID + "LT") == 0)
        {
            LeftTriggerDown = false;
        }


        //If the right trigger is pressed throw the trash
        if (Input.GetAxisRaw("Player" + PlayerID + "RT") != 0 && Trash != null)
        {
            isThrow = true;
        }

        //If the A button is pressed then jump
        if (Input.GetButtonDown("Player" + PlayerID + "A"))
        {
            isJump = true;
        }
    }

    enum AnimationStates { IDLE, IDLEHOLD, RUN, RUNHOLD, JUMP  };
    AnimationStates CurrentAnim = AnimationStates.IDLE;
    // Update is called once per frame
    void Update()
    {
        //Ignore Collisions with players and trash
        CollidersInRadius = Physics.OverlapSphere(transform.position, 5.0f, ColsMask);

        if (CollidersInRadius.Length > 0)
        {
            foreach (Collider c in CollidersInRadius)
            {
                Physics.IgnoreCollision(c, this.GetComponent<Collider>());
            }
        }


        //Subtract delta time from the impulse cooldown
        ImpulseCooldown -= Time.deltaTime;

        //Recieve all inputs
        HandleInput();

        //Handle the picking up/holding of the trash

        if (LeftTriggerDown && PreviousTriggerState != 0 && Trash != null)
        {
            IsHolding = true;
            //If the Left Trigger is held down move the trash object above the player
            Trash.transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z), Trash.transform.rotation);
        }
        else if (LeftTriggerDown && PreviousTriggerState == 0)
        {
            //If the left trigger is pressed after being in the released state pickup the trash
            PickupTrash();
        }
        else
        {
            IsHolding = false;
            //If the left trigger is released, remove the reference to the trash object and allow it to fall in place
            Trash = null;
        }

        //Player movement along the x-axis


        if (!IsGrounded)
        {
            CurrentAnim = AnimationStates.JUMP;
        }
        else if(!IsHolding)
        {
            if(MovementDirection.x != 0)
            {
                CurrentAnim = AnimationStates.RUN;
            }
            else
            {
                CurrentAnim = AnimationStates.IDLE;
            }
        }
        else
        {
            if (MovementDirection.x != 0)
            {
                CurrentAnim = AnimationStates.RUNHOLD;
            }
            else
            {
                CurrentAnim = AnimationStates.IDLEHOLD;
            }
        }


        switch(CurrentAnim)
        {
            case AnimationStates.IDLE:
               GetComponent<Animator>().Play("Idle");
                break;
            case AnimationStates.IDLEHOLD:
                GetComponent<Animator>().Play("IdleHold");
                break;
            case AnimationStates.RUN:
                GetComponent<Animator>().Play("Walk");
                if(MovementDirection.x > 0)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
                break;
            case AnimationStates.RUNHOLD:
                GetComponent<Animator>().Play("WalkHold");
                if (MovementDirection.x > 0)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
                break;
            case AnimationStates.JUMP:
                GetComponent<Animator>().Play("Jump");
                if (MovementDirection.x > 0)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
                break;
            default:
                break;

        }

       
      
        //Store the current state of the left trigger for use in the next frame
        PreviousTriggerState = Input.GetAxisRaw("Player" + PlayerID + "LT");
    }

    Vector3 totalForce = new Vector3();
    private void FixedUpdate()
    {
        //totalForce = Vector3.zero;

        //totalForce += (MovementDirection * MovementSpeed);
        GetComponent<Rigidbody>().AddForce(MovementDirection * MovementSpeed, ForceMode.VelocityChange);

        if(!IsGrounded)
        {
            GetComponent<Rigidbody>().AddForce(-Vector3.up * pFallValue, ForceMode.VelocityChange);
            //totalForce += (-Vector3.up * pFallValue);
        }

        if (IsGrounded && isJump)
        {

            GetComponent<Rigidbody>().AddForce(JumpForce * Vector3.up, ForceMode.Impulse);
            IsGrounded = false;
            isJump = false;

           // totalForce += (Vector3.up * JumpForce);
            this.GetComponent<AudioSource>().PlayOneShot(jumpingAudio);
        }

        if(!IsGrounded)
        {
            isJump = false;
        }


        if(isThrow)
        {
            isThrow = false;
            ThrowTrash();
        }

        if(isPulse)
        {
            isPulse = false;
            ActivateImpulse();
        }

       // GetComponent<Rigidbody>().AddForce(totalForce, ForceMode.VelocityChange);
    }

    bool isJump = false;
    bool isPulse = false;
    bool isThrow = false;
    Collider[] CollidersInRadius;

    //This function will apply an upward force to the player if they are not midair when called
    void Jump()
    {
       
    }
       
    //This function will cheack a nearby radius around the player for trash and pick it up when called
    void PickupTrash()
    {
        //Get an array of all the nearby colliders, whose game objects are on the trash layer
        //  Collider[] trashProximity = Physics.OverlapSphere(transform.position, 1, trashMask);

        //Check that a piece of trash is found
        if (CollidersInRadius.Length > 0)
        {
            foreach (Collider c in CollidersInRadius)
            {
                if (c.gameObject.tag == "Trash" && Vector3.Distance(c.gameObject.transform.position, transform.position) <= 1.5f)
                {
                    IsHolding = true;
                    //Store a local reference to the trash game object

                    Trash = c.gameObject;
                    //Move the piece of trash to be above the players head
                    Trash.transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z), Trash.transform.rotation);
                    Trash.GetComponent<Ownership>().SetOwnership(PlayerID);
                    return;
                }
            }
        }
        else
        {
            //Set the local reference to null if no trash is found
            Trash = null;
        }
    }

    //This function will apply the throw force to the trash object when called
    void ThrowTrash()
    {
        LeftTriggerDown = false;
        //Normalise the aim direction and invert the y value 
        AimDirection.Normalize();
        AimDirection.y *= -1;
        //Apply the force
        Trash.GetComponent<Rigidbody>().AddForce(AimDirection * ThrowForce, ForceMode.Impulse);
    }

    //This function will activate the players impulse when called
    void ActivateImpulse()
    {
        ImpulseCooldown = 1.0f / ImpulseAttackSpeed;

        if (CollidersInRadius.Length > 0)

        {
            this.GetComponent<AudioSource>().PlayOneShot(impulseAudio);
            foreach (Collider c in CollidersInRadius)
            {
                if (c.gameObject.tag == "Player" && c.gameObject != gameObject)
                {
                    Vector2 direction = c.gameObject.transform.position - transform.position;
                    direction.Normalize();
                    c.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(direction.x * 10, direction.y, 0) * Impulse );
                    
                    c.gameObject.GetComponent<CharacterController>().Trash = null;
                }
            }
        }
       
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Building")
        {
            Debug.Log("Grounded");
            IsGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Building")
        {
            IsGrounded = false;
        }
    }
    //The following functions detect if the player is colliding with the ground
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Building" && !IsGrounded)
        {
            Vector3 dir = new Vector3();
            dir = (collision.gameObject.transform.position - transform.gameObject.transform.position);
            dir.y = -1.0f;
            GetComponent<Rigidbody>().AddForce(dir * fallvalue);
        }
    }

    //The following functions detect if the player is colliding with the ground
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Building" && !IsGrounded)
        {
            Vector3 dir = new Vector3();
           // dir = (collision.gameObject.transform.position - transform.gameObject.transform.position);
            dir.y = -1.0f;
            GetComponent<Rigidbody>().AddForce(dir * fallvalue);
        }
    }

}
