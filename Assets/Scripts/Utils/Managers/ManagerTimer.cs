using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTimer : MonoBehaviour
{

    private ArrayList<TimeToken> list;

    void Awake()
    {
        this.list = new ArrayList<TimeToken>();
    }

    void Update()
    {

        float timePassed = Time.deltaTime;

        foreach (TimeToken timeToken in this.list.clone())
        {

            timeToken.timePassed(timePassed);

            if (!timeToken.notify)
                continue;

            timeToken.notify = false;
            timeToken.timerAble.notify();

            if (timeToken.timesToNotify == -1)
                continue;

            this.list.remove(timeToken);

        }

    }

    public void add(float millisToNotify, Interfaces.TimerAble timerAble)
    {
        this.list.addLast(new TimeToken(millisToNotify, -1, timerAble));
    }

    public void add(float millisToNotify, int timesToNotify, Interfaces.TimerAble timerAble)
    {
        this.list.addLast(new TimeToken(millisToNotify, timesToNotify, timerAble));
    }

    private class TimeToken
    {

        public float millisToNotify, millisPassed;
        public Interfaces.TimerAble timerAble;
        public bool notify;
        public int timesToNotify;

        public TimeToken(float millisToNotify, int timesToNotify, Interfaces.TimerAble timerAble)
        {
            this.millisToNotify = millisToNotify;
            this.timerAble = timerAble;
            this.millisPassed = 0;
            this.timesToNotify = timesToNotify;
            this.notify = false;
        }

        public void timePassed(float millis)
        {

            this.millisPassed += millis;

            if (this.millisPassed < this.millisToNotify)
                return;

            this.notify = true;
            this.millisPassed -= this.millisToNotify;

            if (this.timesToNotify == -1)
                return;

            timesToNotify--;

        }

    }

}
