using System;

class Vector
{
    private double[] data;

    public Vector(double[] values)
    {
        this.data = values;
    }

    public int Size
    {
        get { return data.Length; }
    }

    public double this[int index]
    {
        get { return data[index]; }
        set { data[index] = value; }
    }

    public static Vector operator +(Vector v1, Vector v2)
    {
        int maxSize = Math.Max(v1.Size, v2.Size);
        Vector result = new Vector(new double[maxSize]);
        for (int i = 0; i < maxSize; i++)
        {
            result[i] = (i < v1.Size ? v1[i] : 0) + (i < v2.Size ? v2[i] : 0);
        }
        return result;
    }

    public static Vector operator *(Vector v, double scalar)
    {
        Vector result = new Vector(new double[v.Size]);
        for (int i = 0; i < v.Size; i++)
        {
            result[i] = v[i] * scalar;
        }
        return result;
    }

    public static bool operator ==(Vector v1, Vector v2)
    {
        if (v1.Size != v2.Size) return false;
        for (int i = 0; i < v1.Size; i++)
        {
            if (v1[i] != v2[i]) return false;
        }
        return true;
    }

    public static bool operator !=(Vector v1, Vector v2)
    {
        return !(v1 == v2);
    }
}

class Romb
{
    private double a;
    private double d1;
    private string color;

    public Romb(double a, double d1, string color)
    {
        this.a = a;
        this.d1 = d1;
        this.color = color;
    }

    public object this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return a;
                case 1: return d1;
                case 2: return color;
                default: throw new IndexOutOfRangeException("Invalid index");
            }
        }
        set
        {
            switch (index)
            {
                case 0: a = (double)value; break;
                case 1: d1 = (double)value; break;
                case 2: color = (string)value; break;
                default: throw new IndexOutOfRangeException("Invalid index");
            }
        }
    }

    public static Romb operator ++(Romb romb)
    {
        romb.a++;
        romb.d1++;
        return romb;
    }

    public static Romb operator --(Romb romb)
    {
        romb.a--;
        romb.d1--;
        return romb;
    }

    public static bool operator true(Romb romb)
    {
        return romb.a == romb.d1;
    }

    public static bool operator false(Romb romb)
    {
        return !(romb);
    }

    public static Romb operator *(Romb romb, double scalar)
    {
        romb.a *= scalar;
        romb.d1 *= scalar;
        return romb;
    }

    public static explicit operator string(Romb romb)
    {
        return $"Romb with side a: {romb.a}, diagonal d1: {romb.d1}, color: {romb.color}";
    }

    public static explicit operator Romb(string str)
    {
        throw new NotImplementedException();
    }

    public static bool operator !(Romb romb)
    {
        return romb.a != romb.d1;
    }
}

class Matrix
{
    private double[,] data;

    public Matrix(double[,] data)
    {
        this.data = data;
    }

    public int Rows
    {
        get { return data.GetLength(0); }
    }

    public int Columns
    {
        get { return data.GetLength(1); }
    }

    public double this[int row, int col]
    {
        get { return data[row, col]; }
        set { data[row, col] = value; }
    }

    public static Matrix operator +(Matrix m1, Matrix m2)
    {
        int rows = Math.Max(m1.Rows, m2.Rows);
        int cols = Math.Max(m1.Columns, m2.Columns);
        Matrix result = new Matrix(new double[rows, cols]);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = (i < m1.Rows && j < m1.Columns ? m1[i, j] : 0) +
                               (i < m2.Rows && j < m2.Columns ? m2[i, j] : 0);
            }
        }
        return result;
    }

    public static Matrix operator *(Matrix m, double scalar)
    {
        int rows = m.Rows;
        int cols = m.Columns;
        Matrix result = new Matrix(new double[rows, cols]);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = m[i, j] * scalar;
            }
        }
        return result;
    }

    public static bool operator ==(Matrix m1, Matrix m2)
    {
        if (m1.Rows != m2.Rows || m1.Columns != m2.Columns) return false;
        for (int i = 0; i < m1.Rows; i++)
        {
            for (int j = 0; j < m1.Columns; j++)
            {
                if (m1[i, j] != m2[i, j]) return false;
            }
        }
        return true;
    }

    public static bool operator !=(Matrix m1, Matrix m2)
    {
        return !(m1 == m2);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Romb romb1 = new Romb(5, 7, "red");
        Romb romb2 = new Romb(6, 6, "blue");

        Console.WriteLine(!romb1); // Виведе False, оскільки ромб1 не є квадратом
        Console.WriteLine(!romb2); // Виведе True, оскільки ромб2 є квадратом

        Vector vec1 = new Vector(new double[] { 1, 2, 3 });
        Vector vec2 = new Vector(new double[] { 4, 5 });

        Vector sum = vec1 + vec2;
        Console.Write("Sum: ");
        for (int i = 0; i < sum.Size; i++)
        {
            Console.Write(sum[i] + " ");
        }
        Console.WriteLine();

        Vector scaled = vec1 * 2.5;
        Console.Write("Scaled: ");
        for (int i = 0; i < scaled.Size; i++)
        {
            Console.Write(scaled[i] + " ");
        }
        Console.WriteLine();

        Console.WriteLine("Comparison: " + (vec1 == vec2));

        // Тестування класу Matrix
        Matrix mat1 = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
        Matrix mat2 = new Matrix(new double[,] { { 5, 6 }, { 7, 8 } });

        Matrix matSum = mat1 + mat2;
        Console.WriteLine("Matrix Sum:");
        for (int i = 0; i < matSum.Rows; i++)
        {
            for (int j = 0; j < matSum.Columns; j++)
            {
                Console.Write(matSum[i, j] + " ");
            }
            Console.WriteLine();
        }

        Matrix matScaled = mat1 * 2;
        Console.WriteLine("Matrix Scaled:");
        for (int i = 0; i < matScaled.Rows; i++)
        {
            for (int j = 0; j < matScaled.Columns; j++)
            {
                Console.Write(matScaled[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Matrix Comparison: " + (mat1 == mat2));
    }
}
