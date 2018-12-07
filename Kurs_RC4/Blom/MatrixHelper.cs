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
            List<MatrixElement> result = new List<MatrixElement>();

            for (int y = 0; y < column.Count; y++)
            {
                int value = 0;

                for (int x = 0; x < column.Count; x++)
                {
                    value += (matrix.FirstOrDefault(item => item.X == x && item.Y == y).Value * column[x].Value);
                }

                result.Add(new MatrixElement { Value = value % module, X = y, Y = 0 });
                
            }
            return result;
        }

        internal static int PowRowOnColumn(List<MatrixElement> privateKey, List<MatrixElement> userId, int module)
        {
            int value = 0;

            for (int y = 0; y < privateKey.Count; y++)
            {
                value += privateKey[y].Value * userId[y].Value;
            }

            return value % module;
        }
    }
}
