 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float speed;

    private Rigidbody2D myRigidBody;
    private Vector3 change;
    private Animator animator;

    public VectorValue startingPosition;
    

    private Vector3 MapMin;
    private Vector3 MapMax;

    [SerializeField]
    private Tilemap Map;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = startingPosition.initialValue;

        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        MapMax = Map.localBounds.max;
        MapMin = Map.localBounds.min;
        //Debug.Log(MapMin);


    }

    // Update is called once per frame
    void Update()
    {

        change = Vector3.zero;  
        change.x = Input.GetAxisRaw("Horizontal"); 
        change.y = Input.GetAxisRaw("Vertical");

        

        
        UpdateAnimationAndMove();
        
        
    }

    void UpdateAnimationAndMove()
    {

        if (change != Vector3.zero)
        {
            MoveCharachter();
            animator.SetFloat("MoveX", change.x);
            animator.SetFloat("MoveY", change.y);
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);

        }

    }

    void MoveCharachter()
    {

        Vector3 Limiter = transform.position; //workaound the transform.pos notbeing a var

        myRigidBody.MovePosition(transform.position + change * speed * Time.deltaTime);
        Limiter.x = Mathf.Clamp(Limiter.x, MapMin.x + 0.5f, MapMax.x- 0.5f);

        Limiter.y = Mathf.Clamp(Limiter.y, MapMin.y + 0.5f, MapMax.y - 0.5f);

        transform.position = Limiter;

        //Debug.Log(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name);     //returns the name of the clip beign played


        //Debug.Log("current clip: " + animator.GetComponent<Animation>().name;)

    }

}





