using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{
    [Range(0, 1)][SerializeField] private float walkMoveStopRadius = 0.5f;
    [SerializeField] private float attackMoveStopRadius = 5f;
    
    
    ThirdPersonCharacter thirdPersonCharacter;   // A reference to the ThirdPersonCharacter on the object
    CameraRaycaster cameraRaycaster;
    Vector3 currentDestination;
    
    private bool _clickMove;
    private Vector3 clickPoint;
    public static bool IsInDirectMode = false; // Static?
        
    private void Start()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        cameraRaycaster.notifyMouseClickObservers += ProcessMouseMovement;
        thirdPersonCharacter = GetComponent<ThirdPersonCharacter>();
        currentDestination = transform.position;
    }

    private void Update() 
    {
        _clickMove = Input.GetMouseButton(0);
        if (Input.GetKeyDown(KeyCode.G)) // TODO: Add to menu
        { 
            IsInDirectMode = !IsInDirectMode;
            currentDestination = transform.position;
        }
    }

    private void FixedUpdate()
    {
        if (IsInDirectMode) {
            ProcessDirectMovement();
        }
    }

    private void ProcessDirectMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Camera relative
        Vector3 camForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 movement = v * camForward + h * Camera.main.transform.right;

        thirdPersonCharacter.Move(movement, false, false);
    }

  private void ProcessMouseMovement(RaycastHit hit, int layer)
  {
        clickPoint = hit.point;

        switch ((Layer)layer) 
        {
            case Layer.Walkable:
                currentDestination = ShortDestination(clickPoint, walkMoveStopRadius);
                break;
            case Layer.Enemy:
                currentDestination = ShortDestination(clickPoint, attackMoveStopRadius);
                break;
            default:
                Debug.LogWarning("Unknown layer detected");
                return;
        }
        WalkToDestination();
  }

    private void WalkToDestination()
    {
        var playerToClickPoint = currentDestination - transform.position;
        if (playerToClickPoint.magnitude < walkMoveStopRadius) 
        {
            playerToClickPoint = Vector3.zero;
        }
        thirdPersonCharacter.Move(playerToClickPoint, false, false);
  }

    private Vector3 ShortDestination(Vector3 destination, float shortening)
    {
        var rangeToDestination = (destination - transform.position);
        Vector3 reductionVector = rangeToDestination.normalized * shortening;
        if (reductionVector.magnitude > rangeToDestination.magnitude) {
            reductionVector = rangeToDestination;
        }
        return destination - reductionVector;
    }

  void OnDrawGizmos() 
  {
      Gizmos.color = Color.black;
      Gizmos.DrawLine(transform.position, currentDestination);
      Gizmos.DrawSphere(currentDestination, 0.1f);
      Gizmos.DrawSphere(clickPoint, 0.2f);
      
  }
}

