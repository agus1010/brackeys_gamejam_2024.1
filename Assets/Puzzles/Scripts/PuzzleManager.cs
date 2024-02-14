using UnityEngine;


namespace Core.Puzzles
{
	[RequireComponent(typeof(PuzzleSolutionChecker))]
	public class PuzzleManager : MonoBehaviour
	{
		[Header("References:")]
		[SerializeField] private PuzzleSolutionChecker solutionChecker;
		[SerializeField] private AudioSource audioSource;

		[Header("Config:")]
		public AudioClip correctSolutionClip;
		public AudioClip incorrectSolutionClip;


		public void TestSolution()
		{
			bool puzzleSolved = solutionChecker.Check();
			print(puzzleSolved);
			handleSolutionProvided
				(
					audioClip: puzzleSolved ? correctSolutionClip : incorrectSolutionClip
				);
		}


		private void handleSolutionProvided(AudioClip audioClip)
		{
			audioSource.clip = audioClip;
			audioSource.Play();
		}
	}
}