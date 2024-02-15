using UnityEngine;


namespace Core.Doors
{
	public class Door : MonoBehaviour
	{
		[SerializeField] private Animator animator;
		[SerializeField] private AudioSource audioSource;

		public void Open()
		{
			animator.SetTrigger("Open");
			audioSource.Play();
		}
	}
}