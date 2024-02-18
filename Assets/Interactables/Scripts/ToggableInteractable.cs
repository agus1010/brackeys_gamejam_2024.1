using UnityEngine;

using Core.Interactables;


namespace Assets.Interactables
{
	public class ToggableInteractable : Interactable
	{
		[SerializeField] private bool _isOn = false;
		public bool isOn
		{
			get => _isOn;
			set => _isOn = value;
		}
		public Material onMaterial;


		private MeshRenderer meshRenderer;
        Material originalMaterial;

        private void Start()
		{
			meshRenderer = GetComponent<MeshRenderer>();
            originalMaterial = meshRenderer.material;
        }

		public override void Interact()
		{
			_isOn = !_isOn;
			if (_isOn)
			{
				meshRenderer.material = onMaterial;
            }
			else
			{
				meshRenderer.material = originalMaterial;
			}
			base.Interact();
		}
	}
}