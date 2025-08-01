using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    IfElse,
    WhileLoop,
    IntEnemy,
    FloatEnemy,
    LongEnemy,
    DoubleEnemy,
    Coins,
    Empty,
    BreakStatement,
    ContinueStatement,
    LogicGate,
    Debugger,
    MemoryLeak,
    SyntaxError,
    VariablePickup,
    PowerUp,
    Comment
}

[System.Serializable]
public class LevelSegment
{
    public List<TileType> elements = new List<TileType>();
}

public class WhileLoop : MonoBehaviour
{
    [Header("Level Generation Settings")]
    public int segmentCount = 10;
    public int rowsCleared = 0;

    [Header("Generated Level")]
    public List<LevelSegment> currentLevel = new List<LevelSegment>();

    void Start()
    {
        currentLevel = GenerateLevel(segmentCount, rowsCleared);
        Debug.Log("Level generated with " + currentLevel.Count + " segments.");


        for (int i = 0; i < currentLevel.Count; i++)
        {
            string line = $"Segment {i}: ";
            foreach (var tile in currentLevel[i].elements)
            {
                line += tile.ToString() + " ";
            }
            Debug.Log(line);
        }
    }

    List<LevelSegment> GenerateLevel(int segmentCount, int rowsCleared)
    {
        List<LevelSegment> level = new List<LevelSegment>();
        System.Random rng = new System.Random();

        for (int i = 0; i < segmentCount; i++)
        {
            LevelSegment segment = new LevelSegment();


            segment.elements.Add(rng.NextDouble() < 0.5 ? TileType.IfElse : TileType.WhileLoop);


            if (rng.NextDouble() < 0.2)
                segment.elements.Add(TileType.LogicGate);


            int enemyCount = Mathf.Clamp(1 + rowsCleared / 5, 1, 4);
            bool hasLongOrDouble = false;

            for (int e = 0; e < enemyCount; e++)
            {
                float roll = rng.Next(0, 100);
                TileType enemyType;

                if (!hasLongOrDouble && roll > 75 && rowsCleared > 10)
                {
                    hasLongOrDouble = true;
                    enemyType = rng.Next(0, 2) == 0 ? TileType.LongEnemy : TileType.DoubleEnemy;
                }
                else if (roll > 50)
                {
                    enemyType = TileType.FloatEnemy;
                }
                else
                {
                    enemyType = TileType.IntEnemy;
                }

                segment.elements.Add(enemyType);
            }


            if (rowsCleared > 15 && rng.NextDouble() < 0.2)
                segment.elements.Add(TileType.MemoryLeak);

            if (rng.NextDouble() < 0.15)
                segment.elements.Add(TileType.SyntaxError);


            if (rng.NextDouble() < 0.25)
                segment.elements.Add(TileType.VariablePickup);

            if (rng.NextDouble() < 0.15)
                segment.elements.Add(TileType.PowerUp);

            if (rng.NextDouble() < 0.3)
                segment.elements.Add(TileType.Coins);


            if (rng.NextDouble() < 0.1)
                segment.elements.Add(TileType.Debugger);

            if (rng.NextDouble() < 0.1)
                segment.elements.Add(TileType.BreakStatement);

            if (rng.NextDouble() < 0.05)
                segment.elements.Add(TileType.ContinueStatement);


            if (rng.NextDouble() < 0.1)
                segment.elements.Add(TileType.Comment);

            if (rng.NextDouble() < 0.1)
                segment.elements.Add(TileType.Empty);

            level.Add(segment);
        }

        return level;
    }
}