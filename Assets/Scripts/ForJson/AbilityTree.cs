using System;

[Serializable]
public class AbilityTree
{
    public Swordmaster swordMaster;
    public Magicmaster magicMaster;
    public Archermaster archerMaster;
}
[Serializable]
public class Swordmaster
{
    public int dash;
    public int kick;
    public int area;
}
[Serializable]
public class Magicmaster
{
    public int chain;
    public int shield;
    public int area;
}
[Serializable]
public class Archermaster
{
    public int poison;
    public int shurikens;
    public int rain;
}
