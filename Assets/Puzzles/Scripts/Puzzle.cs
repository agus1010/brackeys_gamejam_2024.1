using UnityEngine;


namespace Core.Puzzles
{
	public class Puzzle : MonoBehaviour
	{
		[Header("References:")]
		[SerializeField] private PuzzleSolutionChecker solution;
		[SerializeField] private Doors.Door associatedDoor;
		[SerializeField] private AudioSource audioSource;

		[Header("Config:")]
		public AudioClip success;
		public AudioClip failure;

		public bool solved { get; private set; } = false;

		
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
	}
}