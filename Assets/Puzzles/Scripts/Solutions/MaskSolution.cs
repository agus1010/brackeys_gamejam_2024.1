using Core.Puzzles;
using System.Linq;

using Assets.Interactables;


namespace Assets.Puzzles
{
	public class MaskSolution : PuzzleSolutionChecker
	{
		public ToggableInteractable[] masks;

		public override bool Check()
			=> masks[0].isOn && masks.Where(m => !m.isOn).Count() == 7;
	}
}