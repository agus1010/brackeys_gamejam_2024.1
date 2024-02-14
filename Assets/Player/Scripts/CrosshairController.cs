using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

using Core.Interactables;


namespace Assets.Player
{
	public class CrosshairController : MonoBehaviour
	{
		[Header("References:")]
		[SerializeField] private InputSystemUIInputModule uiInputModule;
		[SerializeField] private Image image;

		[Header("Config:")]
		[SerializeField] private Sprite idle;
		[SerializeField] private Sprite pointingAnInteractable;

		public bool isPointingAnInteractable => uiInputModule.GetLastRaycastResult(0).gameObject?.GetComponent<IInteractable>() != null;


		private void Update()
		{
			var targetSprite = isPointingAnInteractable ? pointingAnInteractable : idle;
			if (targetSprite != image.sprite)
				image.sprite = targetSprite;
		}
	}
}