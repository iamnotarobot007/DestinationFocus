
//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    #region PUBLIC_VARS
//    public bool isPlaying = false;
//    #endregion

//    #region PRIVATE_VARS
//    private Rigidbody2D rb;
//    private Vector2[] moveDirections = { new Vector2(0, -5), new Vector2(5, 0), new Vector2(0, 5), new Vector2(-5, 0) };
//    private int currentDirectionIndex = 0;
//    private float triangleRotation = 0f;
//    #endregion

//    #region UNITY_CALLBACKS
//    void Start()
//    { 
//        rb = GetComponent<Rigidbody2D>();
//    }

//    void Update()
//    {
//        if (isPlaying)
//        {

//            triangleRotation = transform.eulerAngles.z;


//            SetBallVelocity();
//        }
//    }

//    void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Base"))
//        {

//            ReverseDirection();
//        }
//        else if (collision.gameObject.CompareTag("Hypotenuse"))
//        {

//            ToggleDirection();

//        }
//    }
//    #endregion

//    #region PRIVATE_FUNCTIONS
//    void ToggleDirection()
//    {

//        currentDirectionIndex = (currentDirectionIndex + 1) % moveDirections.Length;
//        //  Debug.Log(currentDirectionIndex);

//    }

//    void ReverseDirection()
//    {

//        moveDirections[currentDirectionIndex] = -moveDirections[currentDirectionIndex];

//    }

//    void SetBallVelocity()
//    {

//        if (Mathf.Approximately(triangleRotation, 0f))
//        {
//            Debug.Log(triangleRotation);
//            currentDirectionIndex = 0;
//        }



//        rb.velocity = moveDirections[currentDirectionIndex];
//    }
//    #endregion
//}





using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isPlaying = false;

    private Rigidbody2D rb;
    private Vector2[] moveDirections = { new Vector2(0, -5), new Vector2(5, 0), new Vector2(0, 5), new Vector2(-5, 0) };
    private int currentDirectionIndex = 0;
    [SerializeField] private float triangleRotation;
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    void Update()
    {
        if (isPlaying)
        {
            SetBallVelocity();
        }       

    }

        void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Hypotenuse"))
        {
        

            var collideObj = collision.collider.gameObject.GetComponent<TriangleController>();
            if (collideObj == null)
            {
                collideObj = collision.collider.gameObject.GetComponentInParent<TriangleController>();
            }

            if (collideObj != null)
            {
                triangleRotation = collideObj.currentAngle;
                CheckAndSetBallDirection();
            }
          
        }
        else if (collision.collider.CompareTag("Base"))
        {
           
            ReverseDirection();
        }
    }


    public void CheckAndSetBallDirection()
    {
      

            Vector2 currentDirection = moveDirections[currentDirectionIndex];
            if (currentDirection == new Vector2(0, -5))
            {
                if (Mathf.Approximately(triangleRotation, 0f))
                {
                    currentDirectionIndex = 1; 
                   
                }
                else if (Mathf.Approximately(triangleRotation, 90f))
                {
                    currentDirectionIndex = 3;
                }
            }
            else if (currentDirection == new Vector2(5, 0))
            {
                if (Mathf.Approximately(triangleRotation, 90f))
                {
                    currentDirectionIndex = 2;
                }
                else if (Mathf.Approximately(triangleRotation, 180f))
                {
                    currentDirectionIndex = 0; 
                }
            }
            else if (currentDirection == new Vector2(0, 5))
            {
                if (Mathf.Approximately(triangleRotation, 180f))
                {
                    currentDirectionIndex = 3; 
                }
                else if (Mathf.Approximately(triangleRotation, 270f))    
                {
                    currentDirectionIndex = 1; 
                }
            }
            else if (currentDirection == new Vector2(-5, 0))
            {
                if (Mathf.Approximately(triangleRotation, 270f))
                {
                    currentDirectionIndex = 0; 
                }
                else if (Mathf.Approximately(triangleRotation, 0f))
                {
                    currentDirectionIndex = 2;
                    
                }
            }

    }

   public  void ReverseDirection()
    {
        switch (currentDirectionIndex)
        {
            case 0:
                currentDirectionIndex = 2 ; 
                break;
            case 1:
                currentDirectionIndex = 3;
                break;
            case 2:
                currentDirectionIndex = 0; 
                break;
            case 3: 
                currentDirectionIndex = 1;
                break;
        }

    }

    void SetBallVelocity()
    {
        rb.velocity = moveDirections[currentDirectionIndex];

    }



}

//if (triangleTransform != null)
//{
//float triangleRotation = triangleTransform.rotation.eulerAngles.z;

//var collideObj = collision.collider.gameObject.GetComponent<TriangleController>();
//if (collision.gameObject.CompareTag("Base"))
//{

//    ReverseDirection();
//}
//else if (collision.gameObject.CompareTag("Hypotenuse"))
//{

//    triangleRotation = collideObj.currentAngle;
//    CheckAndSetBallDirection();
//    Debug.Log(triangleRotation);
//}