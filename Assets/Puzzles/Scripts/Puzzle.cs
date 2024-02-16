using UnityEngine;


namespace Core.Puzzles
{
	public class Puzzle : MonoBehaviour
	{
		[Header("References:")]
		[SerializeField] private PuzzleSolutionChecker solution;
		[SerializeField] private Doors.Door associatedDoor;
		[SerializeField] private AudioSource audioSource;
		[SerializeField] private Transform associatedGameObjectsParent;

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
			for (int i = 0; i < associatedGameObjectsParent.childCount; i++)
				associatedGameObjectsParent.GetChild(i).gameObject.SetActive(value);
		}
	}
}