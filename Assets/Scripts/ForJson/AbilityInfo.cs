using System;

[Serializable]
public class AbilityInfo
{
    public Swordabilityinfo swordAbilityInfo;
    public Magicabilityinfo magicAbilityInfo;
    public Archerabilityinfo archerAbilityInfo;
}

[Serializable]
public class Swordabilityinfo
{
    public Dash dash;
    public Kick kick;
    public Area area;
}
[Serializable]
public class Dash
{
    public string _1;
    public string _2;
    public string _3;
    public string _4;
    public string _5;
}
[Serializable]
public class Kick
{
    public string _1;
    public string _2;
    public string _3;
    public string _4;
    public string _5;
}

[Serializable]
public class Area
{
    public string _1;
    public string _2;
    public string _3;
    public string _4;
    public string _5;
}
[Serializable]
public class Magicabilityinfo
{
    public Chain chain;
    public Shield shield;
    public Area1 area;
}
[Serializable]
public class Chain
{
    public string _1;
    public string _2;
    public string _3;
    public string _4;
    public string _5;
}
[Serializable]
public class Shield
{
    public string _1;
    public string _2;
    public string _3;
    public string _4;
    public string _5;
}
[Serializable]
public class Area1
{
    public string _1;
    public string _2;
    public string _3;
    public string _4;
    public string _5;
}
[Serializable]
public class Archerabilityinfo
{
    public Poison poison;
    public Shurikens shurikens;         
    public Rain rain;
}
[Serializable]
public class Poison
{
    public string _1;
    public string _2;
    public string _3;
    public string _4;
    public string _5;
}
[Serializable]
public class Shurikens
{
    public string _1;
    public string _2;
    public string _3;
    public string _4;
    public string _5;
}
[Serializable]
public class Rain
{
    public string _1;
    public string _2;
    public string _3;
    public string _4;
    public string _5;
}
