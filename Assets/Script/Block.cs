using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    // configuration parameters
    [SerializeField] AudioClip breakSounds;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;
    //cached reference
    Level level;

    //state Variables
    [SerializeField] int timesHit; // TODO only serialized for debug purposes

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable" && collision.gameObject.tag == "Ball")
        {
            HandleHit();
        }
    }

    public void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {          
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {  
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex] != null)
        { 
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array" + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        PlayBlockDestroyVFX();
        TriggersSparklesVFX();
        Destroy(gameObject);
        level.BlockDestroy();
    }

    private void PlayBlockDestroyVFX()
    {
        FindObjectOfType<GameStatus>().addToScore();
        AudioSource.PlayClipAtPoint(breakSounds, Camera.main.transform.position);
    }

    private void TriggersSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
