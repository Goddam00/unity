using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    Material material;
    [SerializeField] Vector2 scrollVelocity;
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {   
        if (material){
            material.mainTextureOffset += scrollVelocity * Time.deltaTime;
        }
        
        /*
        if (Input.GetKey(KeyCode.A)) 
            material.mainTextureOffset += new Vector2(scrollVelocity.x*(-1), 0) * Time.deltaTime;
        if (Input.GetKey(KeyCode.D)) 
            material.mainTextureOffset += new Vector2(scrollVelocity.x, 0) * Time.deltaTime;
        if (Input.GetKey(KeyCode.W)) 
            material.mainTextureOffset += new Vector2(0, scrollVelocity.y) * Time.deltaTime;
        if (Input.GetKey(KeyCode.S)) 
            material.mainTextureOffset += new Vector2(0, scrollVelocity.y*(-1)) * Time.deltaTime;
        */
    }
}
