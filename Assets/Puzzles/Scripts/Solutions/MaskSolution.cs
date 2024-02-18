using Core.Puzzles;
using System.Linq;

using Assets.Interactables;


namespace Assets.Puzzles
{

    public class MaskSolution : PuzzleSolutionChecker
	{
		public ToggableInteractable[] masks;


		public int[] correctMasks;

        public override bool Check()
		{
            foreach (var mask in correctMasks)
            {
                    if (!masks[mask].isOn)
                    {
                    return false;
                    }
            }
            return masks.Where(m => !m.isOn).Count() == (masks.Length - correctMasks.Length);


            /*
            if ((masks[].isOn)){
                if (masks.Where(m => !m.isOn).Count() == 5)
                {
                    return true;
                }
            }
            return false;
            */
        }
		
	}
}