using UnityEngine;

public class ColorGrading : MonoBehaviour
{
    //reference to material with the LUT shader
    public Material lutMaterial;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Debug.Log("OnRenderImage called");//check if message appears
    
        if (lutMaterial != null)
        {
            Graphics.Blit(source, destination, lutMaterial);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
