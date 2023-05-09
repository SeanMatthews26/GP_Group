using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoWayColliderScript : MonoBehaviour
{
    // public
    public bool collided;
    public bool fromFront;

    // private
    private GameObject _firstCollider;
    private GameObject _secondCollider;
    
    private bool _firstColliderCollided;
    private bool _secondColliderCollided;
    
    private float _bufferTime = 0.5f;
    private float _bufferTimer = 0f;

    private GameObject _gameController;

    private void Awake()
    {
        _firstCollider = transform.GetChild(0).transform.gameObject;
        _secondCollider = transform.GetChild(1).transform.gameObject;
        
        _gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    private void Update()
    {
        // check where player is colliding from
        if (_bufferTimer > 0f)
        {
            _bufferTimer -= Time.deltaTime;
            return;
        }
        
        if (_firstCollider.GetComponent<ColliderScript>().collided && !_secondColliderCollided)
        {
            _firstColliderCollided = true;
            collided = true;
            fromFront = true;
            _bufferTimer = _bufferTime;
        }
        else if (_secondCollider.GetComponent<ColliderScript>().collided && !_firstColliderCollided)
        {
            _secondColliderCollided = true;
            collided = true;
            fromFront = false;
            _bufferTimer = _bufferTime;
        }
        else
        {
            _firstColliderCollided = false;
            _secondColliderCollided = false;
        }

        if (!_firstColliderCollided && !_secondColliderCollided)
        {
            collided = false;
        }
        
        // change camera mode
        if (collided)
        {
            if (fromFront)
            {
                _gameController.GetComponent<GameControllerScript>().splineMode = true;
            }
            else
            {
                _gameController.GetComponent<GameControllerScript>().splineMode = false;
                
                GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
                camera.transform.localRotation = Quaternion.identity;
            }
        }
    }
}
