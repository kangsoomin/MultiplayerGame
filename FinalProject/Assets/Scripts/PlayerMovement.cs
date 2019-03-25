using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField][Range(0, 20)]
    private float moveSpeed;

    private Rigidbody2D rb;
    [SerializeField]
    private float horizontalMove;
    private float verticalMove;

    private bool isFacingRight = true;

    private Animator anim;

    private Camera mainCam;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(horizontalMove * moveSpeed, verticalMove * moveSpeed);
        Vector3 cursorPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        

        //뒤로 가게 되는 방향이 되면 무빙속도를 줄여버리자!!
        //이건 좀 고민해봐야 될 문제인 듯 하다...
        if(cursorPos.x < transform.position.x && isFacingRight)
        {
            Flip();
        }
        else if(cursorPos.x > transform.position.x && !isFacingRight)
        {
            Flip();
        }

        if(isFacingRight && horizontalMove < 0f)
        {
            horizontalMove *= 0.35f;
        }
        else if(!isFacingRight && horizontalMove > 0f)
        {
            horizontalMove *= 0.35f;
        }
        /*
        if(isFacingRight && horizontalMove < 0)
        {
            Flip();
        }
        else if(!isFacingRight && horizontalMove > 0)
        {
            Flip();
        }
        */

        anim.SetFloat("Speed", Mathf.Abs(horizontalMove));

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + new Vector2(horizontalMove, verticalMove) * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Gate"))
        {
            Animator gateanim = coll.GetComponent<Animator>();
            gateanim.SetBool("IsOpen", true);

        }
            
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Gate"))
        {
            Animator gateanim = coll.GetComponent<Animator>();
            gateanim.SetBool("IsOpen", false);

        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 changeScale = transform.localScale;
        changeScale.x *= -1;
        transform.localScale = changeScale;

    }
}
