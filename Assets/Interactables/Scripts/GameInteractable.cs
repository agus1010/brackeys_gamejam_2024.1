using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


namespace Core.Interactables
{
	public class GameInteractable : MonoBehaviour, IInteractable, IPointerClickHandler
	{
		public UnityEvent<GameInteractable> InteractedWith;


		public virtual void Interact()
		{
			InteractedWith?.Invoke(this);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			Interact();
		}
	}
}
