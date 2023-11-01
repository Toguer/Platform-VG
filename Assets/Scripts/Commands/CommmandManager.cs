using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CommmandManager
{
    public static Queue<Command> commandQueue = new Queue<Command>();

    public struct Command
    {
        public float _timeSpanPress;
        public float _timeSpanRelease;
        public bool started;

    }

    public static void AddCommand(Command c)
    {
        commandQueue.Enqueue(c);
        Debug.Log(c._timeSpanPress +" y "+ c._timeSpanRelease);
    }

    public static bool checkCommand(float bossTime)
    {
        if (commandQueue.Count > 0)
        {
            return bossTime >= commandQueue.Peek()._timeSpanPress;
        }

        return false;
    }

    public static float jumpTime()
    {
        float t = commandQueue.Peek()._timeSpanRelease - commandQueue.Peek()._timeSpanPress;
        deleteCommand();
        return t;
    }

    static void deleteCommand()
    {
        commandQueue.Dequeue();
    }
}