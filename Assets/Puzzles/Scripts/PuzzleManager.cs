using System.Collections.Generic;
using UnityEngine;


namespace Core.Puzzles
{
	public class PuzzleManager : MonoBehaviour
	{
		[Header("References:")]
		[SerializeField] private AudioSource audioSource;
		[SerializeField] private PuzzleSolutionProvider puzzlesProvider;
		[SerializeField] private List<GameObject> stoneDoorPrefabs;

		[Header("Config:")]
		public AudioClip correctSolutionClip;
		public AudioClip incorrectSolutionClip;


		public void TestSolution()
		{
			bool puzzleSolved = puzzlesProvider.currentPuzzle.Check();
			handleSolutionProvided
				(
					audioClip: puzzleSolved ? correctSolutionClip : incorrectSolutionClip
				);
			if (puzzleSolved)
			{
				if (stoneDoorPrefabs.Count > 0)
				{
					stoneDoorPrefabs[0].GetComponent<Animator>().SetTrigger("Open");
					stoneDoorPrefabs.RemoveAt(0);
				}
				puzzlesProvider.MoveToNext();
			}
		}


		private void handleSolutionProvided(AudioClip audioClip)
		{
			audioSource.clip = audioClip;
			audioSource.Play();
		}
	}
}