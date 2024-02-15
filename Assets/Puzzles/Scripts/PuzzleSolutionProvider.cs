using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Core.Puzzles
{
	public class PuzzleSolutionProvider : MonoBehaviour
	{
		[SerializeField] private List<PuzzleSolutionChecker> puzzles;

		public int puzzlesLeft => puzzles.Count;
		public PuzzleSolutionChecker currentPuzzle => puzzles.FirstOrDefault();


		public void MoveToNext()
		{
			if (puzzlesLeft > 0)
				puzzles.RemoveAt(0);
		}
	}
}