using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Core.Puzzles
{
	public class PuzzleManager : MonoBehaviour
	{
		[Header("References:")]
		[SerializeField] private Transform puzzlesParent;

		private Stack<Puzzle> puzzles;


		private void Start()
		{
			puzzles = new Stack<Puzzle>(puzzlesParent.GetComponentsInChildren<Puzzle>().Reverse());
		}


		public void TestSolution()
		{
			if (!puzzles.TryPeek(out Puzzle current) || !current.Check())
				return;
			puzzles.Pop();
		}
	}
}