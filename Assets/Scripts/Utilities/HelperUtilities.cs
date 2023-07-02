using System.Collections;
using UnityEngine;

public static class HelperUtilities
{
    public static bool ValidateCheckEmptyStrings(Object thisObject, string fieldName, string stringToCheck)
    {
        if (stringToCheck == "")
        {
            Debug.Log(fieldName + " is empty and must contain a value in object " + thisObject.name.ToString());
            return true;
        }
        return false;
    }

    /// <summary>
    /// Null value debug check
    /// </summary>
    public static bool ValidateCheckNullValue(Object thisObject, string fieldName, UnityEngine.Object objectToCheck)
    {
        if (objectToCheck == null)
        {
            Debug.LogError(fieldName + " is null and must contain a value in object " + thisObject.name.ToString());
            return true;
        }
        return false;
    }


    public static bool ValidateCheckEnumerableValues(Object thisObject, string fieldName, IEnumerable enumarableObjectToCheck)
    {
        bool error = false;
        int count = 0;

        if (enumarableObjectToCheck != null)
        {
            Debug.Log(fieldName + " is null in object " + thisObject.name.ToString());
            return true;
        }

        foreach (var item in enumarableObjectToCheck)
        {
            if (item == null)
            {
                Debug.Log(fieldName + " has null values in object " + thisObject.name.ToString());
                error = true;
            }
            else
            {
                count++;
            }
        }

        if (count == 0)
        {
            Debug.Log(fieldName + " has no values in object " + thisObject.name.ToString());
            error = true;
        }
        return error;
    }


    public static bool ValidateCheckPositiveValue(Object thisObject, string fieldName, int valueToCheck, bool isZeroAllowed)
    {
        bool error = false;
        if (isZeroAllowed)
        {
            if (valueToCheck < 0)
            {
                Debug.LogError(fieldName + " must contain a positive value or zero in object " + thisObject.name.ToString());
                error = true;
            }
        }
        else
        {
            if (valueToCheck <= 0)
            {
                Debug.LogError(fieldName + " must contain a positive value in object " + thisObject.name.ToString());
                error = true;
            }
        }
        return error;
    }

    public static Vector3 GetSpawnPositionNearestToPlayer(Vector3 playerPosition)
    {
        Room currentRoom = GameManager.Instance.GetCurrentRoom();

        Grid grid = currentRoom.instantiatedRoom.grid;

        Vector3 nearestSpawnPosition = new Vector3(10000f, 10000f, 0);

        foreach (Vector2Int spawnPositionGrid in currentRoom.spawnPositionArray)
        {
            Vector3 spawnPositionWorld = grid.CellToWorld((Vector3Int)spawnPositionGrid);

            if (Vector3.Distance(spawnPositionWorld, playerPosition) < Vector3.Distance(nearestSpawnPosition, playerPosition))
            {
                nearestSpawnPosition = spawnPositionWorld;
            }
        }
        return nearestSpawnPosition;
    }
}
