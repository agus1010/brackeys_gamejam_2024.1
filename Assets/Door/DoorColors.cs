using UnityEngine;


public class DoorColors : MonoBehaviour
{
    public float threshold = 2f;
    public Material[] colors;

    public MeshRenderer meshRenderer;

    private int index = 0;
    private float deltaThreshold = 0f;


    public void ChangeToNextColor()
    {
		index += 1;
		if (index >= colors.Length)
			index = 0;
		meshRenderer.material = colors[index];
		print("CAMBIO DE COLOR");
	}


    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        deltaThreshold += Time.deltaTime;
        if (deltaThreshold >= threshold)
        {
            deltaThreshold = 0;
            ChangeToNextColor();
        }
    }
}