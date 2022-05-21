using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    CharacterController _controller;
    Transform _player;

    [SerializeField]
    float _moveSpeed = 5.0f;

    [SerializeField]
    float _gravity = 5.0f;

    float _yVelocity = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("player");
        _player = playerObject.transform;
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        direction.Normalize();
        Vector3 velocity = direction * _moveSpeed;
        if (!_controller.isGrounded)
        {
            _yVelocity -= _gravity;
        }
        velocity.y = _yVelocity;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction);
        _controller.Move(velocity * Time.deltaTime);
    }
}
