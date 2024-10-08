using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 5f;
    [SerializeField] private float _horizontalSpeed = 3f;

    private double LeftLimit = -4.25;
    private double RightLimit = 4.25;

    public bool isJumping = false;
    public bool comingDown = false;
    public bool isSliding = false;
    public Animator _animator;

    [SerializeField] private ItemManager _itemManager;

    public LevelDistance LevelDistance;
    private void OnDisable()
    {
        _itemManager.OnDamaged();
        LevelDistance.addingDis = true;
    }

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.isPlay)
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime * _playerSpeed);

            if (Input.GetKey(KeyCode.A))
            {
                if (this.gameObject.transform.position.x > LeftLimit)
                {
                    this.transform.Translate((Vector3.left * Time.deltaTime * _horizontalSpeed));
                }
            }

            else if (Input.GetKey(KeyCode.D))
            {
                if (this.gameObject.transform.position.x < RightLimit)
                {
                    this.transform.Translate((Vector3.right * Time.deltaTime * _horizontalSpeed));
                }
            }

            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
            {
                if (isJumping == false)
                {
                    isJumping = true;
                    _animator.Play("Jump");
                    StartCoroutine(JumpSequence());
                }
            }
            else if (Input.GetKey(KeyCode.S))
            {
                if (isSliding == false)
                {
                    isSliding = true;
                    _animator.Play("Running Slide");
                    StartCoroutine(SlideSequence());
                }
            }
        }

        if (isJumping == true)
        {
            if (comingDown == false)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 5, Space.World);
            }

            if (comingDown == true)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -5, Space.World);
            }
        }

        IEnumerator JumpSequence()
        {
            yield return new WaitForSeconds(0.45f);
            comingDown = true;
            yield return new WaitForSeconds(0.45f);
            isJumping = false;
            comingDown = false;
            _animator.Play("Run");
        }

        IEnumerator SlideSequence()
        {
            yield return new WaitForSeconds(0.5f);
            Debug.Log("Slide!!!!");
            isSliding = false;
            _animator.Play("Run");
        }
    }
}