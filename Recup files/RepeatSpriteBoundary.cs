﻿/*FROM http://answers.unity3d.com/questions/599263/how-to-make-2d-sprite-tiled.html -> Ash Blue*/

using UnityEngine;
using System.Collections;

// @NOTE the attached sprite's position should be "top left" or the children will not align properly
// Strech out the image as you need in the sprite render, the following script will auto-correct it when rendered in the game
[RequireComponent(typeof(SpriteRenderer))]

// Generates a nice set of repeated sprites inside a streched sprite renderer
// @NOTE Vertical only, you can easily expand this to horizontal with a little tweaking
public class RepeatSpriteBoundary : MonoBehaviour
{
    SpriteRenderer sprite;

    void Awake()
    {
        // Get the current sprite with an unscaled size
        sprite = GetComponent<SpriteRenderer>();
        Vector2 spriteSize = new Vector2(sprite.bounds.size.x / transform.localScale.x, sprite.bounds.size.y / transform.localScale.y);

        // Generate a child prefab of the sprite renderer
        GameObject childPrefab = new GameObject();
        SpriteRenderer childSprite = childPrefab.AddComponent<SpriteRenderer>();
        childPrefab.transform.position = transform.position;
        childSprite.sprite = sprite.sprite;

        // Loop through and spit out repeated tiles
        GameObject child;
        int l = (int)Mathf.Round(sprite.bounds.size.x / spriteSize.x);
        for (int i = 0; i < l; i++)
        {
            child = Instantiate(childPrefab) as GameObject;
            child.transform.position = transform.position + (new Vector3(spriteSize.x - 0.1f, 0, 0) * i);
            child.transform.parent = transform;
            child.renderer.sortingLayerName = "Layer 2";
            child.renderer.sortingOrder = -100;
        }

        // Set the parent last on the prefab to prevent transform displacement
        childPrefab.transform.parent = transform;

        // Disable the currently existing sprite component since its now a repeated image
        sprite.enabled = false;
    }
}