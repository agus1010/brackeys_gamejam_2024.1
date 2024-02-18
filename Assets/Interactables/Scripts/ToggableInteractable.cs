using UnityEngine;

using Core.Interactables;


namespace Assets.Interactables
{
	public class ToggableInteractable : Interactable
	{
		[Header("Referennces:")]
		[SerializeField] private MeshRenderer meshRenderer;
		
		[Header("Config:")]
		public Material onMaterial;
		[SerializeField] private bool _isOn = false;
		
		public bool isOn
		{
			get => _isOn;
			set => _isOn = value;
		}

        private Material originalMaterial;

        private void Start()
		{
			if (meshRenderer == null)
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