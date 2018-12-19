using System.Linq;

namespace Kurs_RC4.Algo
{
    public class RC4
    {
        byte[] S = new byte[256];
        int x = 0;
        int y = 0;

        public RC4(byte[] key)
        {
            Init(key);
        }

        private void Init(byte[] key)
        {
            int keyLength = key.Length;

            for (int i = 0; i < 256; i++)
            {
                S[i] = (byte)i;
            }

            int j = 0;
            for (int i = 0; i < 256; i++)
            {
                j = (j + S[i] + key[i % keyLength]) % 256;
                S.Swap(i, j);
            }
        }

        private byte KeyItem()
        {
            x = (x + 1) % 256;
            y = (y + S[x]) % 256;

            S.Swap(x, y);

            return S[(S[x] + S[y]) % 256];
        }

        public byte[] Encode(byte[] dataB, int size)
        {
            byte[] data = dataB.Take(size).ToArray();

            byte[] cipher = new byte[data.Length];

            for (int m = 0; m < data.Length; m++)
            {
                cipher[m] = (byte)(data[m] ^ KeyItem());
            }

            return cipher;
        }

        public byte[] Decode(byte[] dataB, int size)
        {
            return Encode(dataB, size);
        }
    }
}
