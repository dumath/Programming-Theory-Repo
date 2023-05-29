using UnityEngine;

public static class AdditionalMath
{
    static AdditionalMath() { }
   
    /// <summary>
    /// ������������� �������� ������ ��������� � ������.
    /// </summary>
    /// <param name="minFrom"> ����������� �������� ������� ���������.</param>
    /// <param name="maxFrom"> ������������ �������� ������� ���������. </param>
    /// <param name="minTo"> ����������� �������� ������� ���������. </param>
    /// <param name="maxTo"> ������������ �������� ������� ���������. </param>
    /// <param name="value"> ���������������� �������� ������� ���������. </param>
    /// <returns> ����������������� �������� ������� ��������� �� ������. </returns>
    public static float Lerp(float minFrom, float maxFrom, float minTo, float maxTo, float value)
    {
        return minTo + (value - minFrom) / (maxFrom - minFrom) * (maxTo - minTo);
    }

    /// <summary>
    /// ������ ���������.
    /// </summary>
    /// <param name="minStrange"> ����������� ����������. </param>
    /// <param name="maxStrange"> ������������ ����������. </param>
    /// <returns> �������� �������� ������ ���������. </returns>
    public static Vector2 Noise2D(float minStrange = 0.0f, float maxStrange = 1.0f)
    {
        Vector2 handledPoint = new Vector2();
        handledPoint.x = Random.Range(minStrange, maxStrange);
        handledPoint.y = Random.Range(minStrange, maxStrange);
        return handledPoint;
    }

    /// <summary>
    /// ��������� �����. � ������ ����������� - ������ ����� RGB!A.
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
