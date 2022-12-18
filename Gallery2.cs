using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gallery2 : MonoBehaviour
{

    public RawImage imageA;
    public RawImage imageB;
    public RawImage imageC;
    public RawImage imageD;

    public InputField question;

    public void startA()
    {

        if (NativeGallery.IsMediaPickerBusy())
            return;
        // Pick a PNG image from Gallery/Photos
        // If the selected image's width and/or height is greater than 512px, down-scale the image
        PickImage(780);
    }

    public void startB()
    {

        if (NativeGallery.IsMediaPickerBusy())
            return;
        // Pick a PNG image from Gallery/Photos
        // If the selected image's width and/or height is greater than 512px, down-scale the image
        PickImageB(780);
    }

    public void startC()
    {

        if (NativeGallery.IsMediaPickerBusy())
            return;
        // Pick a PNG image from Gallery/Photos
        // If the selected image's width and/or height is greater than 512px, down-scale the image
        PickImageC(780);
    }

    public void startD()
    {

        if (NativeGallery.IsMediaPickerBusy())
            return;
        // Pick a PNG image from Gallery/Photos
        // If the selected image's width and/or height is greater than 512px, down-scale the image
        PickImageD(780);
    }

    private void PickImage(int maxSize)
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {
                // Create Texture from selected image
                Texture2D textureA = NativeGallery.LoadImageAtPath(path, maxSize);
                imageA.texture = textureA;
                QuizImageMultiply.textureA = textureA;
                if (textureA == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }
            }
        }, "Select a PNG image", "image/png");
    }
    private void PickImageB(int maxSizeB)
    {
        NativeGallery.Permission permissionB = NativeGallery.GetImageFromGallery((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {
                    // Create Texture from selected image
                    Texture2D textureB = NativeGallery.LoadImageAtPath(path, maxSizeB);
                imageB.texture = textureB;
                QuizImageMultiply.textureB = textureB;
                if (textureB == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }
                }
        }, "Select a PNG image", "image/png");

       // Debug.Log("Permission result: " + permission);
    }

    private void PickImageC(int maxSizeC)
    {
        NativeGallery.Permission permissionB = NativeGallery.GetImageFromGallery((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {
                // Create Texture from selected image
                Texture2D textureC = NativeGallery.LoadImageAtPath(path, maxSizeC);
                imageC.texture = textureC;
                QuizImageMultiply.textureC = textureC;
                if (textureC == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }
            }
        }, "Select a PNG image", "image/png");

        // Debug.Log("Permission result: " + permission);
    }

    private void PickImageD(int maxSizeD)
    {
        NativeGallery.Permission permissionB = NativeGallery.GetImageFromGallery((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {
                // Create Texture from selected image
                Texture2D textureD = NativeGallery.LoadImageAtPath(path, maxSizeD);
                imageD.texture = textureD;
                QuizImageMultiply.textureD = textureD;
                if (textureD == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }
            }
        }, "Select a PNG image", "image/png");

        // Debug.Log("Permission result: " + permission);
    }


    public void MarkCorrect(string value) {
        QuizImageMultiply.correct = value;
    }

    public void SaveQuiz(Button button) {
        // button.interactable = false;
        QuizQuestion.question = question.text;
        QuizQuestion.ClearOptions();
    }

}
