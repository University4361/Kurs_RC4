using Kurs_RC4.Blom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs_RC4
{
    public class User
    {
        private BlomWorker blomWorker;
        public List<MatrixElement> UserId;
        public List<MatrixElement> PrivateKey;

        public string Name { get; }

        public User(List<MatrixElement> userId, string name)
        {
            this.UserId = userId;
            Name = name;
            blomWorker = new BlomWorker(userId);

            ShowId();
            SetupPrivateKey();
        }

        private void ShowId()
        {
            string userIdStr = string.Empty;

            foreach (var item in UserId)
            {
                userIdStr += $"{item.Value} ";
            }

            Console.WriteLine($"User {Name} initialized with id: {userIdStr}");
        }

        private void SetupPrivateKey()
        {
            PrivateKey = blomWorker.GetPrivateKey(); // get key by Blom

            string privateKeyStr = string.Empty;

            foreach (var item in PrivateKey)
            {
                privateKeyStr += $"{item.Value}{item.X}{item.Y}";
            }

            string privateStr = string.Empty;

            foreach (var item in PrivateKey)
            {
                privateStr += $"{item.Value} ";
            }

            Console.WriteLine($"User {Name} has private key: {privateStr}");
        }

        public void SendMessageTo(User toUser, string message)
        {
            Console.WriteLine($"{Name} send message '{message}' to {toUser.Name}");

            var sessionKey = MatrixHelper.PowRowOnColumn(PrivateKey, toUser.UserId, BlomWorker.Mod);
            byte[] sessionKeyBytes = Encoding.ASCII.GetBytes(sessionKey.ToString());

            RC4 encoder = new RC4(sessionKeyBytes);
            string messageStr = message;
            byte[] messageBytes = Encoding.ASCII.GetBytes(messageStr);
            byte[] result = encoder.Encode(messageBytes, messageBytes.Length);

            Console.WriteLine($"Encoded text by {Name}:");

            foreach (byte item in result)
                Console.Write($"{item} ");

            Console.WriteLine();

            toUser.ProcessMessage(result, UserId);
        }

        public void ProcessMessage(byte[] message, List<MatrixElement> id)
        {
            var sessionKey = MatrixHelper.PowRowOnColumn(PrivateKey, id, BlomWorker.Mod);
            byte[] sessionKeyBytes = Encoding.ASCII.GetBytes(sessionKey.ToString());

            RC4 decoder = new RC4(sessionKeyBytes);
            byte[] decryptedBytes = decoder.Decode(message, message.Length);
            string decryptedString = Encoding.ASCII.GetString(decryptedBytes);

            Console.WriteLine($"Decoded text by {Name}:");

            Console.WriteLine(decryptedString);
        }
    }
}
