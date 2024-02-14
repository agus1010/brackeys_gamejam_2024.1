using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


namespace Core.Player
{
    public class InteractionController : MonoBehaviour
    {
        [SerializeField] private PhysicsRaycaster physicsRaycaster;

		public void TryInteracting(InputAction.CallbackContext callbackContext)
		{
		}
	}
}