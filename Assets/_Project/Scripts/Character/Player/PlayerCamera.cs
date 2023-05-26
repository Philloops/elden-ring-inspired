using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nu11ity
{
    public class PlayerCamera : Singleton<PlayerCamera>
    {
        public PlayerManager player;
        public Camera cameraObject;
        [SerializeField] Transform cameraPivotTransform;

        // CHANGE THESE TO TWEAK THE CAMERA PERFORMANCE
        [Header("Camera Settings")]
        private float cameraSmoothSpeed = 1; // THE BIGGER THIS NUMBER, LONGER IT'LL TAKE FOR CAMERA TO REACH ITS POSITION DURING MOVEMENT
        [SerializeField] float leftAndRightRotationSpeed = 220;
        [SerializeField] float upAndDownRotationSpeed = 220;
        [SerializeField] float minimumPivot = -30; // THE LOWEST POINT YOU ARE ABLE TO LOOK DOWN
        [SerializeField] float maximumPivot = 60; // THE HIGHEST POINT YOU ARE ABLE TO LOOK UP
        [SerializeField] float cameraCollisionRadius = 0.2f;
        [SerializeField] LayerMask collideWithLayers;

        [Header("Camera Values")]
        private Vector3 cameraVelocity;
        private Vector3 cameraObjectPosition; // USED FOR CAMERA COLLISIONS (MOVES THE CAMERA OBJECT TO THIS POSITION UPON COLLIDING)
        [SerializeField] float leftAndRightLookAngle;
        [SerializeField] float upAndDownLookAngle;
        private float cameraZPosition; // VALUES USED FOR CAMERA COLLISION
        private float targetCameraZPosition; // VALUES USED FOR CAMERA COLLISION

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            cameraZPosition = cameraObject.transform.localPosition.z;
        }

        public void HandleAllCameraActions()
        {
            if(player != null)
            {
                HandleFollowTarget();
                HandleRotations();
                HandleCollisions();
            }
        }

        private void HandleFollowTarget()
        {
            Vector3 targetCameraPosition = Vector3.SmoothDamp(transform.position, player.transform.position, ref cameraVelocity, cameraSmoothSpeed * Time.deltaTime);
            transform.position = targetCameraPosition;
        }

        private void HandleRotations()
        {
            // IF LOCKED ON, FORCE ROTATION TOWARDS TARGET
            // ELSE ROTATE REGULARLY

            // ROTATE LEFT AND RIGHT BASED ON HORIZONTAL MOVEMENT ON THE RIGHT JOYSTICK
            leftAndRightLookAngle += (PlayerInputManager.Instance.cameraHorizontalInput * leftAndRightRotationSpeed) * Time.deltaTime;
            // ROTATE UP AND DOWN BASED ON THE VERICAL MOVEMENT ON THE RIGHT JOYSTICK
            upAndDownLookAngle -= (PlayerInputManager.instance.cameraVerticalInput * upAndDownRotationSpeed) * Time.deltaTime;
            // CLAMP THE UP AND DOWN LOOK ANGLE BETWEEN A MIN AND MAX VALUE
            upAndDownLookAngle = Mathf.Clamp(upAndDownLookAngle, minimumPivot, maximumPivot);


            Vector3 cameraRotation = Vector3.zero;
            Quaternion targetRotation;

            // ROTATE THIS GAMEOBJECT LEFT AND RIGHT
            cameraRotation.y = leftAndRightLookAngle;
            targetRotation = Quaternion.Euler(cameraRotation);
            transform.rotation = targetRotation;

            // ROTATE THIS PIVOT GAMEOBJECT UP AND DOWN
            cameraRotation = Vector3.zero;
            cameraRotation.x = upAndDownLookAngle;
            targetRotation = Quaternion.Euler(cameraRotation);
            cameraPivotTransform.localRotation = targetRotation;
        }

        private void HandleCollisions()
        {
            targetCameraZPosition = cameraZPosition;

            RaycastHit hit;
            // DIRECTION FOR COLLISION CHECK
            Vector3 direction = cameraObject.transform.position - cameraPivotTransform.position;
            direction.Normalize();

            // WE CHECK IF THERE IS AN OBJECT IN FRONT OF OUR DESIRED DIRECTION ^ (SEE ABOVE)
            if(Physics.SphereCast(cameraPivotTransform.position, cameraCollisionRadius, direction, out hit, Mathf.Abs(targetCameraZPosition), collideWithLayers))
            {
                // IF THERE IS, WE GET OUR DISTANCE FROM IT
                float distanceFromHitObject = Vector3.Distance(cameraPivotTransform.position, hit.point);
                // WE THEN EQUATE OUR TARGET Z POSITION TO THE FOLLOWING 
                targetCameraZPosition = -(distanceFromHitObject - cameraCollisionRadius);
            }

            // IF OUR TARGET POSITION IS LESS THAN OUR COLLISION RADIUS, WE SUBTRACT OUR COLLISION RADIUS (MAKING IT SNAP BACK)
            if(Mathf.Abs(targetCameraZPosition) < cameraCollisionRadius)
            {
                targetCameraZPosition = -cameraCollisionRadius;
            }

            // WE THEN APPLY OUR FINAL POSITION USING A LERP OVER A TIME OF 0.2F
            cameraObjectPosition.z = Mathf.Lerp(cameraObject.transform.localPosition.z, targetCameraZPosition, 0.2f);
            cameraObject.transform.localPosition = cameraObjectPosition;
        }
    }
}
