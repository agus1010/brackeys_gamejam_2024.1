using UnityEngine;
using UnityEngine.EventSystems;


namespace Core.Interactables
{
	public class Interactable : MonoBehaviour, IInteractable, IPointerClickHandler
	{
		public virtual void Interact()
		{
			print("INTERACTION");
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			Interact();
		}
	}
}
