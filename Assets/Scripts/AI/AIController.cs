using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public List<AIBase> aiList;
    int maxChannelledAttacks = 3, currentChannels = 0;

    void Awake()
    {
        
    }

    void Update()
    {
        
    }

    public void NotifyChannelEnd()
    {
        currentChannels--;
    }

    public bool CanChannelAttack()
{
        if(currentChannels < maxChannelledAttacks)
        {
            return true;
        }

        return false;
    }

    public void NotifyChannelStart()
    {
        currentChannels++;
    }
}
