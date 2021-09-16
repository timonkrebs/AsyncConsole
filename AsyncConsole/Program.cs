using System.Threading;
using System.Threading.Tasks;
using Microsoft.Threading;

namespace AsyncConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncPump.Run(() => Foo(true));
        }

        public static async Task Foo(bool isAsync)
        {
            var x = 1;
            await Bar(isAsync);
            x = 6;
        }

        public static async Task Bar(bool isAsync)
        {
            var y = 2;
            await Baz(isAsync);
            y = 5;
        }

        public static async Task Baz(bool isAsync)
        {
            var z = 3;
            if (isAsync)
            {
                await Task.Run(() => Thread.Sleep(1000));

                await Task.Run(() => Thread.Sleep(1000)).ConfigureAwait(false);
            }
            else
            {
                Thread.Sleep(1000);
            }
            z = 4;
        }
    }
}
