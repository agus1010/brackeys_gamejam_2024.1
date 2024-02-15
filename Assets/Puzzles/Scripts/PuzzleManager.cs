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
			if (puzzlesProvider.puzzlesLeft == 0)
				return;

			bool puzzleSolved = puzzlesProvider.currentPuzzle.Check();
			AudioClip clip;
			if (puzzleSolved)
			{
				if (stoneDoorPrefabs.Count > 0)
				{
					stoneDoorPrefabs[0].GetComponent<Animator>().SetTrigger("Open");
					stoneDoorPrefabs.RemoveAt(0);
				}
				clip = correctSolutionClip;
				puzzlesProvider.MoveToNext();
			}
			else
			{
				clip = incorrectSolutionClip;
			}
			audioSource.clip = clip;
			audioSource.Play();
		}
	}
}