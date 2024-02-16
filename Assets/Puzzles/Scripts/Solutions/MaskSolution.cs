using Core.Puzzles;
using System.Linq;

using Assets.Interactables;


namespace Assets.Puzzles
{
	public class MaskSolution : PuzzleSolutionChecker
	{
		public ToggableInteractable[] masks;

		public int correctMask = 0;

		public override bool Check()
			=> masks[correctMask].isOn && masks.Where(m => !m.isOn).Count() == 7;
	}
}