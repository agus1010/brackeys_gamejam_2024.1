using Core.Puzzles;
using System.Linq;

using Assets.Interactables;


namespace Assets.Puzzles
{

    public class MaskSolution : PuzzleSolutionChecker
	{
		public ToggableInteractable[] masks;


		public int correctMask1 = 0;
        public int correctMask2 = 0;
        public int correctMask3 = 0;

        public override bool Check()
		{
            if ((masks[correctMask1].isOn) && (masks[correctMask2].isOn) && (masks[correctMask3].isOn)){
                if (masks.Where(m => !m.isOn).Count() == 5)
                {
                    return true;
                }
            }
            return false;
        }
		
	}
}