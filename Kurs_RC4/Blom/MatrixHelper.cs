using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs_RC4.Blom
{
    public static class MatrixHelper
    {
        public static List<MatrixElement> PowMatrixOnColumn(List<MatrixElement> matrix, List<MatrixElement> column, int module)
        {
            if (matrix == null || column == null || matrix.Count != column.Count * column.Count)
            {
                Console.WriteLine("Error in PowMatrixOnColumn method");
                return new List<MatrixElement>();
            }

            List<MatrixElement> result = new List<MatrixElement>();

            for (int y = 0; y < column.Count; y++)
            {
                MatrixElement element = new MatrixElement { Value = 0, X = y, Y = 0 };

                for (int x = 0; x < column.Count; x++)
                {
                    element.Value += (matrix.FirstOrDefault(item => item.X == x && item.Y == y).Value * column[x].Value);
                }

                element.Value = element.Value % module;

                result.Add(element);
            }
            return result;
        }

        public static int PowRowOnColumn(List<MatrixElement> privateKey, List<MatrixElement> userId, int module)
        {
            int value = 0;

            if (privateKey == null || userId == null || privateKey.Count != userId.Count)
            {
                Console.WriteLine("Error in PowRowOnColumn method");
                return value;
            }

            for (int y = 0; y < privateKey.Count; y++)
            {
                value += privateKey[y].Value * userId[y].Value;
            }

            return value % module;
        }
    }
}
