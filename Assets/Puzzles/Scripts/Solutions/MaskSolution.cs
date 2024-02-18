using Core.Puzzles;

using Assets.Interactables;
using UnityEngine;

namespace Assets.Puzzles
{

    public class MaskSolution : PuzzleSolutionChecker
	{
        public Transform associatedGameObjects;

        private ToggableInteractable[] masks;


        public override bool Check()
		{
            foreach (var toggle in masks)
            {
                if ((toggle.isPartOfSolution && !toggle.isOn) || (!toggle.isPartOfSolution && toggle.isOn))
                    return false;
            }
            return true;
        }


		private void Start()
		{
            masks = associatedGameObjects.GetComponentsInChildren<ToggableInteractable>();
		}
	}
}