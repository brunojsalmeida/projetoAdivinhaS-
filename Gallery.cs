using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gallery : MonoBehaviour
{

    public RawImage image;

    public void start()
    {

        if (NativeGallery.IsMediaPickerBusy())
            return;
        // Pick a PNG image from Gallery/Photos
        // If the selected image's width and/or height is greater than 512px, down-scale the image
        PickImage(780);
    }



    private void PickImage(int maxSize)
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {
                // Create Texture from selected image
                Texture2D texture = NativeGallery.LoadImageAtPath(path, maxSize);
                image.texture = texture;
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }

                //Assign texture to a temporary quad and destroy it after 5 seconds
                //GameObject quad = GameObject.CreatePrimitive( PrimitiveType.Quad );
                //quad.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2.5f;
                //quad.transform.forward = Camera.main.transform.forward;
                //quad.transform.localScale = new Vector3( 1f, texture.height / (float) texture.width, 1f );

                //Material material = quad.GetComponent<Renderer>().material;
                //if( !material.shader.isSupported ) // happens when Standard shader is not included in the build
                //	material.shader = Shader.Find( "Legacy Shaders/Diffuse" );

                //image.texture = texture;
                //material.mainTexture = texture;
                //Destroy( quad, 5f );

                // If a procedural texture is not destroyed manually, 
                // it will only be freed after a scene change
                //Destroy( texture, 5f );
            }
        }, "Select a PNG image", "image/png");


            Debug.Log("Permission result: " + permission);
    }
}
