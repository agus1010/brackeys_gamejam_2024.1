using UnityEngine;

namespace Core.Puzzles
{
	public class PuzzleSolutionChecker : MonoBehaviour, IPuzzleSolution
	{
		public virtual bool Check()
		{
			return true;
		}
	}
}