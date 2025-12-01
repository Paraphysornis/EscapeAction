using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jump;
    Rigidbody2D rbody;
    public LayerMask groundLayer;
    bool onGround = false;
    bool gameoverflag = false;
    public RuntimeAnimatorController movingAnime, gameoverAnime;
    Animator animator;

    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        if (!gameoverflag)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.localScale = new Vector2(-1, 1);
                animator.runtimeAnimatorController = movingAnime;
                animator.speed = 1;
                this.transform.position += Vector3.left * speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.localScale = new Vector2(1, 1);
                animator.runtimeAnimatorController = movingAnime;
                animator.speed = 1;
                this.transform.position += Vector3.right * speed * Time.deltaTime;
            }

            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                animator.speed = 0;
            }

            Jump();
        }
    }

    void Jump()
    {
        onGround = Physics2D.CircleCast(transform.position, 0.1f, Vector2.down, 0.4f, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rbody.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            onGround = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            gameoverflag = true;
            animator.runtimeAnimatorController = gameoverAnime;
        }

        if (other.gameObject.tag == "Gold")
        {
            Destroy(other.gameObject);
            FindObjectOfType<ScoreManager>().ScorePlus();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + Vector3.down * 0.4f, 0.1f);
    }
}
