using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Renderer backgroundRenderer;

    // Update is called once per frame
    void Update()
    {
        // Scroll the texture
        backgroundRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);

    }
}
