using UnityEngine;


namespace Core.Puzzles
{
	public class PuzzleManager : MonoBehaviour
	{
		[Header("References:")]
		[SerializeField] private PuzzleSolutionChecker solutionChecker;
		[SerializeField] private AudioSource audioSource;
		[SerializeField] private Animator animator;

		[Header("Config:")]
		public AudioClip correctSolutionClip;
		public AudioClip incorrectSolutionClip;


		public void TestSolution()
		{
			bool puzzleSolved = solutionChecker.Check();
			handleSolutionProvided
				(
					audioClip: puzzleSolved ? correctSolutionClip : incorrectSolutionClip
				);
			if (puzzleSolved)
			{
				animator.SetTrigger("Open");
				animator.GetComponent<Collider>().isTrigger = true;
			}
		}


		private void handleSolutionProvided(AudioClip audioClip)
		{
			audioSource.clip = audioClip;
			audioSource.Play();

		}
	}
}