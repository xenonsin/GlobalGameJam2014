using UnityEngine;
using System.Collections;

public class PlayerControllerPokemon : MonoBehaviour
{

    private Vector2 _velocity;
    public float runSpeed = 2.0f;

    private CharacterController2D _controller;
    private Animator _animator;

    public static bool inDialog = false;

    // Use this for initialization
    void Start()
    {
        _animator = this.GetComponent<Animator>();
        _controller = GetComponent<CharacterController2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (!inDialog)
        {

            if (Input.GetAxis("Horizontal") < 0)
            {
                //Checks if facing right. If so, flip sprite.
                if (transform.localScale.x > 0f)
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

                _animator.Play(Animator.StringToHash("Walk"));
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                //Checks if facing left. If so, flip sprite.
                if (transform.localScale.x < 0f)
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

                _animator.Play(Animator.StringToHash("Walk"));
            }


            else if (Input.GetAxisRaw("Vertical") > 0)
            {
                // _animator.Play(Animator.StringToHash("RunBack"));
            }
            else if (Input.GetAxisRaw("Vertical") < 0)
            {
                // _animator.Play(Animator.StringToHash("RunForeward"));
            }
            else
            {
                _animator.Play(Animator.StringToHash("Idle"));
            }


            _velocity.x = Input.GetAxisRaw("Horizontal") * runSpeed;
            _velocity.y = Input.GetAxisRaw("Vertical") * runSpeed;

            _controller.move(_velocity * Time.deltaTime);
        }
        else
        {
            _animator.Play(Animator.StringToHash("Idle"));
        }
    }
}
