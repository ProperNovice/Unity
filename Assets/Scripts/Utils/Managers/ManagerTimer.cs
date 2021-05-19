using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTimer : MonoBehaviour
{

    public static ManagerTimer INSTANCE;
    private ArrayList<TimeToken> list;

    void Awake()
    {
        INSTANCE = this;
        this.list = new ArrayList<TimeToken>();
    }

    void Update()
    {

        foreach (TimeToken timeToken in this.list.clone())
        {

            timeToken.timePassed(Time.deltaTime);

            if (timeToken.timesToNotify == -1 || timeToken.timesToNotify > 0)
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

    public void remove(Interfaces.TimerAble timerAble)
    {

        foreach (TimeToken timeToken in this.list.clone())
        {

            if (!timeToken.timerAble.Equals(timerAble))
                continue;

            this.list.remove(timeToken);
            break;

        }

    }

    private class TimeToken
    {

        public float millisToNotify, millisPassed;
        public Interfaces.TimerAble timerAble;
        public int timesToNotify;

        public TimeToken(float millisToNotify, int timesToNotify, Interfaces.TimerAble timerAble)
        {
            this.millisToNotify = millisToNotify / 1000;
            this.timerAble = timerAble;
            this.millisPassed = 0;
            this.timesToNotify = timesToNotify;
        }

        public void timePassed(float millis)
        {

            this.millisPassed += millis;

            if (this.millisPassed < this.millisToNotify)
                return;

            this.timerAble.notify();
            this.millisPassed -= this.millisToNotify;

            if (this.timesToNotify == -1)
                return;

            timesToNotify--;

        }

    }

}
