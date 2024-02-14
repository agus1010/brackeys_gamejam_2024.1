using UnityEngine;
using UnityEngine.InputSystem;


namespace Core.Player
{
    public class VisionController : MonoBehaviour
    {
        [Header("References:")]
        [SerializeField] private Camera playerCamera;
        [SerializeField] private CharacterController characterController;

        [Header("Config:")]
        public float verticalLookLimitAngle = 90f;
        public float camMovementThreshold = .01f;
        public float hSensitivity = 5f;
        public float vSensitivity = 2.5f;

        private float xRot = 0f;
        private Vector3 screenCenter = Vector3.one * .5f;
        
        private Vector3 mousePos => Mouse.current.delta.value;
        

        private void Start ()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

		private void Update()
		{
            if (mousePos.sqrMagnitude >= camMovementThreshold)
                applySightRotation(mousePos * Time.deltaTime);
		}


        private void applySightRotation(Vector2 mouseDelta)
        {
            xRot = Mathf.Clamp(xRot - mouseDelta.y * vSensitivity, -verticalLookLimitAngle, verticalLookLimitAngle);
            Quaternion targetRot = Quaternion.Euler(xRot, 0f, 0f);
            playerCamera.transform.localRotation = targetRot;
            characterController.transform.Rotate(0f, mouseDelta.x * hSensitivity, 0f);
        }
	}
}