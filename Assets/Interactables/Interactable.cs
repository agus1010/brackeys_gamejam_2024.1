using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Core.Interactables
{
	public class Interactable : MonoBehaviour, IInteractable, IPointerClickHandler
	{
		public UnityEvent<Interactable> InteractedWith;

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
