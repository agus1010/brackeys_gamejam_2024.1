using System.Collections.Generic;
using UnityEngine;


namespace Core.Puzzles
{
	public class PuzzleManager : MonoBehaviour
	{
		[Header("References:")]
		[SerializeField] private Transform puzzlesParent;

		private Queue<Puzzle> puzzles;


		private void Start()
		{
			puzzles = new Queue<Puzzle>(puzzlesParent.GetComponentsInChildren<Puzzle>());
		}


		public void TestSolution()
		{
			if (!puzzles.TryPeek(out Puzzle current) || !current.Check())
				return;
			puzzles.Dequeue();
		}
	}
}