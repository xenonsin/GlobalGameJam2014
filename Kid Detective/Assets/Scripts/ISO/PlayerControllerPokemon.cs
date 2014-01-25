using UnityEngine;
using System.Collections;

public class PlayerControllerPokemon : MonoBehaviour {

    private Vector2 _velocity;
    public float runSpeed =  2.0f;

    private CharacterController2D _controller;
    private Animator _animator;
    
    public static bool inDialog = false;

	// Use this for initialization
	void Start () {
        _animator = this.GetComponent<Animator>();
        _controller = GetComponent<CharacterController2D>();
	
	}
	
	// Update is called once per frame
	void Update () {

        if (!inDialog)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                _animator.Play(Animator.StringToHash("RunRight"));
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                _animator.Play(Animator.StringToHash("RunLeft"));
            }
            else if (Input.GetAxisRaw("Vertical") > 0)
            {
                _animator.Play(Animator.StringToHash("RunBack"));
            }
            else if (Input.GetAxisRaw("Vertical") < 0)
            {
                _animator.Play(Animator.StringToHash("RunForeward"));
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
            Debug.Log("IN DIALOG!");
            _animator.Play(Animator.StringToHash("Idle"));
        }
	}
}
