using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs_RC4.Blom
{
    public class BlomWorker
    {
        public const int Mod = 17;

        private List<MatrixElement> _secretMatrix = new List<MatrixElement>
        {
            new MatrixElement{ Value = 1, X = 0, Y = 0 },
            new MatrixElement{ Value = 6, X = 0, Y = 1 },
            new MatrixElement{ Value = 2, X = 0, Y = 2 },
            new MatrixElement{ Value = 6, X = 1, Y = 0 },
            new MatrixElement{ Value = 3, X = 1, Y = 1 },
            new MatrixElement{ Value = 8, X = 1, Y = 2 },
            new MatrixElement{ Value = 2, X = 2, Y = 0 },
            new MatrixElement{ Value = 8, X = 2, Y = 1 },
            new MatrixElement{ Value = 2, X = 2, Y = 2 }
        };

        public List<MatrixElement> userId;

        public BlomWorker(List<MatrixElement> userId)
        {
            this.userId = userId;
        }

        public List<MatrixElement> GetPrivateKey()
        {
            return MatrixHelper.PowMatrixOnColumn(_secretMatrix, userId, Mod);
        }
    }
}
