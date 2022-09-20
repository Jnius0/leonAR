using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//structure to stock 2 strings for the poster scenes and links mapping
[Serializable]
public class DoubleString
{
    public string scene;
    public string link;
}

//poster scenes and links mapping dictionnary
[Serializable]
public class TripleStringDictionary : SerializableDictionary<string, DoubleString> { }
