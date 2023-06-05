using UnityEngine;

public static class AdditionalMath
{
    static AdditionalMath() { }
   
    /// <summary>
    /// Интерполирует значение одного интервала в другой.
    /// </summary>
    /// <param name="minFrom"> Минимальное значение первого интервала.</param>
    /// <param name="maxFrom"> Максимальное значение первого интервала. </param>
    /// <param name="minTo"> Минимальное значение второго интервала. </param>
    /// <param name="maxTo"> Максимальное значение второго интервала. </param>
    /// <param name="value"> Интерполуриуемое значение первого интервала. </param>
    /// <returns> Интерполированное значение первого интервала во второй. </returns>
    public static float Lerp(float minFrom, float maxFrom, float minTo, float maxTo, float value)
    {
        return minTo + (value - minFrom) / (maxFrom - minFrom) * (maxTo - minTo);
    }

    /// <summary>
    /// Тряска плоскости.
    /// </summary>
    /// <param name="minStrange"> Минимальное отклонение. </param>
    /// <param name="maxStrange"> Максимальное отклонение. </param>
    /// <returns> Конечное смещение центра плоскости. </returns>
    public static Vector2 Noise2D(float minStrange = 0.0f, float maxStrange = 1.0f)
    {
        Vector2 handledPoint = new Vector2();
        handledPoint.x = Random.Range(minStrange, maxStrange);
        handledPoint.y = Random.Range(minStrange, maxStrange);
        return handledPoint;
    }

    /// <summary>
    /// Временный метод. В случаи копирования - делать через RGB!A.
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    public static float RGBAverage(Color color) => (color.r + color.g + color.b) / 3.0f;

}

class Manager
{
    /* Manager Template*/
    public Manager Instance;

    public void Awake()
    {
        if(Instance != null)
        {
            //Delete comment. Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            //Delete comment. DontDestroyOnLoad(gameObject);
        }
    }
}
