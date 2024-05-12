using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Block : MonoBehaviour
{
    //Config Params
    //[SerializeField] float BlockBreakTime;
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject BlockSparkles;
    //[SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    //cached Ref.
    Level level;

    //state variables
    [SerializeField] int timesHits; //TODO only serialized for debug process
    

    private void Start()
    {
        //This function will be used by the Level script.
        level = FindObjectOfType<Level>();
        //level.CountBreakableBlocks
        CountBreakableBlocks();

    }

    private void CountBreakableBlocks()
    {
        if (tag == "Breakable")
        {
            
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            
            HandleHit();

        }
    }

    private void HandleHit()
    {
        timesHits++;
        int maxHits = hitSprites.Length +1;
        if (timesHits >= maxHits)
        {
            //Destroy(gameObject);
            DestoryedBlock();        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHits - 1;
        if (hitSprites[spriteIndex] != null) 
        { 
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Sprite is missing from array"+ gameObject.name);
        }
    }

    private void DestoryedBlock()

    {
        //The connection is there, but the block for adding the score is on hold.
        FindObjectOfType<GameSession>().AddToScore();

        //It gets destroyed.
        Destroy(gameObject/*, BlockBreakTime*/);

        //It gets destroyed and a message also gets printed on the console.
        /*Destroy(gameObject);
        Debug.Log(collision.gameObject.name);*/

        //This function uses sound when a file is being deleted during gameplay.
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);

        level.BlockDestroyed();

        TriggerSparklesVFX();
    }
    private void TriggerSparklesVFX()
    {
        GameObject sparkles= Instantiate(BlockSparkles, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }

    
}
