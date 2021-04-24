using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interfaces
{

    public interface SaveLoadAble
    {
        public void saveState();
        public void loadState();
        public void saveStart();
        public void loadStart();

    }

    public interface TimerAble
    {

        public void notify();

    }

}
