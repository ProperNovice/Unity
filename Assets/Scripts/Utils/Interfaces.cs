using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interfaces
{

    public interface ISaveLoadAble
    {
        public void saveState();
        public void loadState();
        public void saveStart();
        public void loadStart();

    }

}
