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
		public Material offMaterial;


		private MeshRenderer meshRenderer;


		private void Start()
		{
			meshRenderer = GetComponent<MeshRenderer>();
		}

		public override void Interact()
		{
			_isOn = !_isOn;
			meshRenderer.material = _isOn? onMaterial : offMaterial;
			base.Interact();
		}
	}
}