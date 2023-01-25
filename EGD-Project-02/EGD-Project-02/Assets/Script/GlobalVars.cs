using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVars
{
    public static readonly int rows = 5;
    public static readonly int columns = 9;

    private static float rayPointOpacity = (255f / 3f) / 255f;
    public static readonly Color rayPointCorrectColor = new Color(1, 160f / 255f, 243f / 255f, rayPointOpacity);
    public static readonly Color rayPointWrongColor = new Color( 0, 0, 0, rayPointOpacity);
    public static readonly Color rayPointNoneColor = new Color( 0, 0, 0, 0);

    public static readonly char rayPointChar = '■';
    public static readonly char boarderChar = '□';
    public static readonly char noPointChar = ' ';

    public static readonly char[][] mapKey =
    {
        //           0    1    2    3    4    5    6    7    8
        new char[]{ ' ', ' ', ' ', ' ', ' ', ' ', '□', ' ', ' '},  // 1
        new char[]{ ' ', '□', '□', '□', '□', '□', '■', '□', ' '},  // 2
        new char[]{ '□', '■', '■', '■', '■', '■', '□', '■', '□'},  // 3
        new char[]{ '□', '■', '□', '■', '□', '□', '■', '□', ' '},  // 4
        new char[]{ ' ', '□', ' ', '□', ' ', ' ', '□', ' ', ' '},  // 5
    };

    public static readonly char[][] mapTestRayCast =
    {
        //           0    1    2    3    4    5    6    7    8
        new char[]{ '■', '■', '■', '■', '■', '■', '■', '■', '■'},  // 1
        new char[]{ '■', '■', '■', '■', '■', '■', '■', '■', '■'},  // 2
        new char[]{ '■', '■', '■', '■', '■', '■', '■', '■', '■'},  // 3
        new char[]{ '■', '■', '■', '■', '■', '■', '■', '■', '■'},  // 4
        new char[]{ '■', '■', '■', '■', '■', '■', '■', '■', '■'},  // 5
    };

    public static readonly char[][] mapDoor =
    {
        //           0    1    2    3    4    5    6    7    8
        new char[]{ '■', '□', '□', '■', '■', '■', '□', '□', '■'},  // 1
        new char[]{ ' ', '□', '■', '□', '□', '□', '■', '□', '□'},  // 2
        new char[]{ ' ', '□', '■', '□', ' ', '□', '■', '□', ' '},  // 3
        new char[]{ ' ', '□', '■', '□', ' ', '□', '■', '□', ' '},  // 4
        new char[]{ ' ', '□', '■', '□', ' ', '□', '■', '□', ' '},  // 5
    };

    public static readonly char[][] mapTemplate =
    {
        //           0    1    2    3    4    5    6    7    8
        new char[]{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},  // 1
        new char[]{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},  // 2
        new char[]{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},  // 3
        new char[]{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},  // 4
        new char[]{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},  // 5
    };

    public static readonly Dictionary<string, char[][]> maps = new Dictionary<string, char[][]>
    {
        {
            "key", mapKey
        },
        {
            "door", mapDoor
        },
        {
            "template", mapTemplate
        }
    };
}
