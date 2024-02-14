using UnityEngine;

namespace Core.Puzzles
{
	public abstract class PuzzleSolutionChecker : MonoBehaviour, IPuzzleSolution
	{
		public abstract bool Check();
	}
}