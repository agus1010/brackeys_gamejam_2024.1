using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Core.Player
{
    public class MovementController : MonoBehaviour
    {
        [Header("References:")]
        [SerializeField] private CharacterController characterController;

        [Header("Config:")]
        public float maxSpeed = 10f;
        [Range(0.001f, 5f)] public float maxSpeedAccelerationInSeconds = 1f;

		private float currentSpeed = 0f;
        private Vector2 hDirection;
        

        public void MoveInDirection(InputAction.CallbackContext callbackContext)
        {
            MoveInDirection(callbackContext.ReadValue<Vector2>());
        }

        public void MoveInDirection(Vector2 horizontalDirection)
        {
            hDirection = new Vector2
                (
					x: horizontalDirection.x != 0f? Mathf.Sign(horizontalDirection.x) : 0f,
                    y: horizontalDirection.y != 0f? Mathf.Sign(horizontalDirection.y) : 0f
                );
        }


        private float accTimeDelta = 0f;
		private void Update()
		{
			if (hDirection != Vector2.zero)
            {
                float accProp = Mathf.Clamp(accTimeDelta, 0, maxSpeedAccelerationInSeconds) / maxSpeedAccelerationInSeconds;
                currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, accProp);
                if (accProp < 1)
                    accTimeDelta = Mathf.Clamp(accTimeDelta + Time.deltaTime, 0f, maxSpeedAccelerationInSeconds);

                Vector3 forward = transform.TransformDirection(Vector3.forward);
                Vector3 right = transform.TransformDirection(Vector3.right);

                float xSpeed = currentSpeed * hDirection.x;
                float zSpeed = currentSpeed * hDirection.y;

                Vector3 moveDirection = (forward * zSpeed) + (right * xSpeed);

                characterController.Move(moveDirection * Time.deltaTime);
            }
            else
            {
                if (currentSpeed > 0)
                {
                    accTimeDelta = 0f;
                    currentSpeed = 0f;
                    characterController.Move(Vector3.zero);
                }
            }
		}
	}
}