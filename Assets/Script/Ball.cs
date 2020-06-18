using UnityEngine;
using UnityEngine.WSA;
using Vector2 = UnityEngine.Vector2;

public class Ball : MonoBehaviour
{
    //config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.5f;


    //state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    //Cached component references

    AudioSource myAudioSouce;
    Rigidbody2D myRigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSouce = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted == false)
        {
                LockBallToPaddle();
                LaunchOnMouseClick();
        }
    }

    public void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        }
    }

    public void PushBallOnPad()
    {
        myRigidBody2D.AddForce(transform.up * 1f,ForceMode2D.Impulse);
    }

    public void LockBallToPaddle()
    {
        myRigidBody2D.velocity = Vector3.zero;
        myRigidBody2D.angularVelocity = 0f;
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (Random.Range(-randomFactor, randomFactor),
            Random.Range(-randomFactor, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            GetComponent<AudioSource>().PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        } 
    }

    public void backHasStared()
    {
        hasStarted = false;
    }


}
