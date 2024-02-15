using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Core.Puzzles
{
	public class PuzzleManager : MonoBehaviour
	{
		[Header("References:")]
		[SerializeField] private Transform puzzlesParent;


		private List<Puzzle> puzzles;

		private void Start()
		{
			puzzles = puzzlesParent.GetComponentsInChildren<Puzzle>().ToList();
		}


		public void TestSolution()
		{
			if (puzzles.Count == 0 || !puzzles[0].Check())
				return;

			puzzles.RemoveAt(0);
		}
	}
}