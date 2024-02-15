using UnityEngine;


namespace Core.Puzzles
{
	public class Puzzle : MonoBehaviour
	{
		[Header("References:")]
		[SerializeField] private PuzzleSolutionChecker solution;
		[SerializeField] private Doors.Door associatedDoor;
		[SerializeField] private AudioSource audioSource;
		[SerializeField] private GameObject[] associatedGameObjects;

		[Header("Config:")]
		public AudioClip success;
		public AudioClip failure;

		public bool solved { get; private set; } = false;


		public void Activate()
		{
			setActivationValueOfAssociateds(true);
		}

		public void Deactivate()
		{
			setActivationValueOfAssociateds(false);
		}
		
		public bool Check()
		{
			solved = solution != null? solution.Check() : true;
			if (solved)
			{
				associatedDoor.Open();
				audioSource.clip = success;
			}
			else
			{
				audioSource.clip = failure;
			}
			audioSource.Play();
			return solved;
		}


		private void setActivationValueOfAssociateds(bool value)
		{
			foreach (var go in associatedGameObjects)
				go.SetActive(value);
		}
	}
}